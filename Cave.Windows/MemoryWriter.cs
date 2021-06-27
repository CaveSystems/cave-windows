using Cave.IO;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a shared memory writer (multiple read single writer)
    /// </summary>
    public class MemoryWriter : IDisposable
    {
        /// <summary>
        /// The container information pointer
        /// </summary>
        public IntPtr ContainerInfoPointer { get; }

        MemoryContainerInfo containerInfo;
        int nextPacketNumber = -1;
        readonly bool FreeMemory;

        /// <summary>Gets the container information.</summary>
        /// <returns></returns>
        public MemoryContainerInfo GetContainerInfo() => (MemoryContainerInfo)Marshal.PtrToStructure(ContainerInfoPointer, typeof(MemoryContainerInfo));

        /// <summary>Sets the container information.</summary>
        /// <param name="newPosition">The new position.</param>
        /// <exception cref="ArgumentException">Position has to be 8 byte aligned!</exception>
        /// <exception cref="ArgumentOutOfRangeException">Position</exception>
        void SetContainerInfo(int newPosition)
        {
            if (newPosition % 8 != 0) throw new ArgumentException("Position has to be 8 byte aligned!");
            if (newPosition > containerInfo.Length) throw new ArgumentOutOfRangeException(nameof(newPosition));
            containerInfo.Position = newPosition;
            Marshal.StructureToPtr(containerInfo, ContainerInfoPointer, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryWriter"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">Name of the container.</param>
        /// <param name="size">Size of the data.</param>
        public MemoryWriter(uint id, string name, int size)
        {
            containerInfo = new MemoryContainerInfo()
            {
                ID = id,
                Data = Marshal.AllocHGlobal(size),
                WriterID = DefaultRNG.UInt32,
                Position = 0,
                Name = name,
                Length = size,
            };
            ContainerInfoPointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MemoryContainerInfo)));
            FreeMemory = true;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryWriter"/> class.
        /// </summary>
        /// <param name="containerInfoPointer">The container information pointer.</param>
        /// <exception cref="ArgumentNullException">Pointer</exception>
        /// <exception cref="ArgumentException">Length has to be 8 byte aligned!</exception>
        /// <exception cref="Exception">
        /// There is already a writer connected to the container!
        /// or
        /// Multiple writer access is not allowed at memory containers!
        /// </exception>
        public MemoryWriter(IntPtr containerInfoPointer)
        {
            if (disposedValue) throw new ObjectDisposedException("MemoryWriter");
            var id = DefaultRNG.UInt32;
            ContainerInfoPointer = containerInfoPointer;
            containerInfo = GetContainerInfo();
            if (containerInfo.Data == IntPtr.Zero) throw new ArgumentNullException(nameof(containerInfoPointer));
            if (containerInfo.Length % 8 != 0) throw new ArgumentException("Length has to be 8 byte aligned!");
            if (containerInfo.WriterID != 0) throw new Exception("There is already a writer connected to the container!");
            containerInfo.WriterID = id;
            SetContainerInfo(0);
            var checkContainerInfo = GetContainerInfo();
            if (!Equals(checkContainerInfo, containerInfo)) throw new Exception("Multiple writer access is not allowed at memory containers!");
        }

        /// <summary>Writes the specified structure.</summary>
        /// <typeparam name="T">structure type to use</typeparam>
        /// <param name="item">The structure.</param>
        /// <exception cref="Exception">Struct is too big to fit into the container. Try increasing the Container.Length</exception>
        public void Write<T>(T item) where T: struct
        {
            if (disposedValue) throw new ObjectDisposedException("MemoryWriter");
            var packetSize = Marshal.SizeOf(item);
            if (packetSize + 8 > containerInfo.Length) throw new Exception("Struct is too big to fit into the container. Try increasing the Container.Length");
            Marshal.WriteInt32(containerInfo.Data, containerInfo.Position, nextPacketNumber);
            var remainder = packetSize % 8;
            if (remainder > 0) packetSize += 8 - remainder;
            Marshal.WriteInt32(containerInfo.Data, containerInfo.Position + 4, packetSize);
            if (containerInfo.Position + 8 + packetSize > containerInfo.Length)
            {
                Marshal.StructureToPtr(item, containerInfo.Data, true);
                SetContainerInfo(packetSize);
            }
            else
            {
                Marshal.StructureToPtr(item, new IntPtr(containerInfo.Data.ToInt64() + 8), true);
                SetContainerInfo((containerInfo.Position + 8 + packetSize) % containerInfo.Length);
            }
            if (--nextPacketNumber < -0xFFFF) nextPacketNumber = -1;
        }

        /// <summary>Closes this instance and frees all pointers.</summary>
        public void Close()
        {
            //signal all readers the exit
            var info = containerInfo;
            info.WriterID = 0;
            info.ID = 0;
            info.Name = "";
            Marshal.StructureToPtr(info, ContainerInfoPointer, true);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Close();
                }
                if (FreeMemory)
                {
                    //wait for one second
                    Thread.Sleep(1000);
                    Marshal.FreeHGlobal(containerInfo.Data);
                    Marshal.FreeHGlobal(ContainerInfoPointer);
                }
                disposedValue = true;
            }
        }

        /// <summary>Finalizes an instance of the <see cref="MemoryWriter"/> class.</summary>
        ~MemoryWriter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
