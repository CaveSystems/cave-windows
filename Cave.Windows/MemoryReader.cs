using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a shared memory reader (multiple read single writer)
    /// </summary>
    public class MemoryReader
    {
        /// <summary>
        /// The container information pointer
        /// </summary>
        public IntPtr ContainerInfoPointer { get; }

        int readPosition = 0;
        int nextPacketNumber = -1;

        /// <summary>Gets the container information.</summary>
        /// <returns></returns>
        public MemoryContainerInfo GetContainerInfo() => (MemoryContainerInfo)Marshal.PtrToStructure(ContainerInfoPointer, typeof(MemoryContainerInfo));

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryReader" /> class.
        /// </summary>
        /// <param name="containerInfoPointer">The container information pointer.</param>
        /// <exception cref="ArgumentNullException">Pointer</exception>
        /// <exception cref="ArgumentException">Length has to be 8 byte aligned!</exception>
        public MemoryReader(IntPtr containerInfoPointer)
        {
            ContainerInfoPointer = containerInfoPointer;
            var containerInfo = GetContainerInfo();
            if (containerInfo.Data == IntPtr.Zero) throw new ArgumentNullException(nameof(containerInfoPointer));
            if (containerInfo.Length % 8 != 0) throw new ArgumentException("Length has to be 8 byte aligned!");
        }

        /// <summary>Gets the available.</summary>
        /// <value>The available.</value>
        public uint Available
        {
            get
            {
                var containerInfo = GetContainerInfo();
                var writePosition = containerInfo.Position;
                if (readPosition < writePosition)
                {
                    return (uint)(writePosition - readPosition);
                }
                if (readPosition > writePosition)
                {
                    return (uint)(containerInfo.Length - readPosition + writePosition);
                }
                return 0;
            }
        }

        /// <summary>
        /// Flags for reading
        /// </summary>
        public enum Flags
        {
            /// <summary>The allow resync if writer is faster than reader</summary>
            AllowResync = 1,

            /// <summary>Blocking operation mode (blocks until data can be read)</summary>
            Blocking = 2,
        }

        /// <summary>Reads the specified struct</summary>
        /// <typeparam name="T">struct type to read</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Packet number mismatch, its likely we got an overflow at the ringbuffer! You can use Resync to read subsequent data...</exception>
        /// <exception cref="ArgumentException">Packet size does not match structure size!</exception>
        public bool Read<T>(out T result, Flags flags) where T: struct
        {
            if (0 != (flags & Flags.Blocking))
            {
                while (!Read(out result, flags & ~Flags.Blocking)) { Thread.Sleep(1); }
                return true;
            }

            var containerInfo = GetContainerInfo();
            result = new T();
            var valueSize = Marshal.SizeOf(result);
            if (valueSize + 8 > Available) return false;
            var packetNumber = Marshal.ReadInt32(containerInfo.Data, readPosition);
            var packetSize = Marshal.ReadInt32(containerInfo.Data, readPosition + 4);
            if (packetNumber != nextPacketNumber)
            {
                if (0 == (flags & Flags.AllowResync))
                {
                    throw new Exception("Packet number mismatch, its likely we got an overflow at the ringbuffer! You can use Resync to read subsequent data...");
                }

                //do resync
                while (Available > 8)
                {
                    packetNumber = Marshal.ReadInt32(containerInfo.Data, readPosition);
                    packetSize = Marshal.ReadInt32(containerInfo.Data, readPosition + 4);

                    if ((packetNumber < -0xFFFF) || (packetSize > containerInfo.Length))
                    {
                        Debug.WriteLine("Resync needed at memory container.");
                        readPosition = (readPosition + 4) % containerInfo.Length;
                        continue;
                    }

                    if (packetSize != valueSize)
                    {
                        Debug.WriteLine($"Skipping packet with size {packetSize} at memory container.");
                        readPosition = (int)((readPosition + 8 + packetSize) % containerInfo.Length);
                    }
                }
            }
            if (packetSize != valueSize) throw new ArgumentException("Packet size does not match structure size!");
            if (containerInfo.Length - readPosition > packetSize + 8)
            {
                //packet not completed ?
                if (containerInfo.Position <= packetSize) return false;
                //read packet at buffer start
                Marshal.PtrToStructure(containerInfo.Data, result);
                readPosition = packetSize;
            }
            else
            {
                //full packet
                Marshal.PtrToStructure(new IntPtr(containerInfo.Data.ToInt64() + readPosition + 8), result);
                readPosition = (int)((readPosition + 8 + packetSize) % containerInfo.Length);
            }
            if (--nextPacketNumber < -0xFFFF) nextPacketNumber = -1;
            return true;
        }

        /// <summary>Closes this instance.</summary>
        public void Close()
        {
        }
    }
}
