#if !NET20

using Cave.IO;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a reader (client) for named pipe communication
    /// </summary>
    public class NamedPipeReader : IDisposable
    {
        DataReader reader;
        NamedPipeClientStream stream;
        int nextPacketNumber = -1;

        void Connect()
        {
            if (!stream.IsConnected)
            {
                stream.Connect(1000);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPipeReader"/> class.
        /// </summary>
        /// <param name="name">Name of the pipe.</param>
        public NamedPipeReader(string name)
            : this(new NamedPipeClientStream(".", name, PipeDirection.In, PipeOptions.Asynchronous))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPipeReader"/> class.
        /// </summary>
        /// <param name="stream">The pipe stream.</param>
        public NamedPipeReader(NamedPipeClientStream stream)
        {
            this.stream = stream;
            reader = new DataReader(this.stream);
            Connect();
        }

        /// <summary>
        /// Flags for reading
        /// </summary>
        public enum Flags
        {
            /// <summary>No flags</summary>
            None = 0,

            /// <summary>The allow resync if connection got lost</summary>
            AllowResync = 1,
            
            //Blocking = 2,
        }

        /// <summary>Reads the specified structure.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Lost connection!
        /// or
        /// Packet number mismatch, its likely we lost synchronization! You can use Resync to read subsequent data...
        /// </exception>
        /// <exception cref="ArgumentException">Packet size does not match structure size!</exception>
        public bool Read<T>(out T result, Flags flags) where T : struct
        {
            if (!stream.IsConnected)
            {
                if (0 != (flags & Flags.AllowResync))
                {
                    Connect();
                }
                else
                {
                    throw new Exception("Lost connection!");
                }
            }
            
            var packetNumber = reader.ReadInt32();
            int packetSize;
            result = new T();
            var valueSize = Marshal.SizeOf(result);
            if (packetNumber != nextPacketNumber)
            {
                Debug.WriteLine("Resync required at named pipe!");
                if (0 == (flags & Flags.AllowResync))
                {
                    throw new Exception("Packet number mismatch, its likely we lost synchronization! You can use Resync to read subsequent data...");
                }

                //do resync
                while (true)
                {
                    packetNumber = reader.ReadInt32();
                    if (packetNumber < -0xFFFF)
                    {
                        Debug.WriteLine("Skipping invalid data");
                        continue;
                    }

                    packetSize = reader.ReadInt32();
                    if (packetSize != valueSize)
                    {
                        Debug.WriteLine($"Skipping packet with size {packetSize} at named pipe.");
                        reader.ReadBytes(packetSize);
                    }
                }
            }
            else
            {
                packetSize = reader.ReadInt32();
                if (packetSize != valueSize) throw new ArgumentException("Packet size does not match structure size!");
            }

            var data = reader.ReadBytes(packetSize);
            result = MarshalStruct.GetStruct<T>(data);
            if (--nextPacketNumber < -0xFFFF) nextPacketNumber = -1;
            return true;
        }

        /// <summary>Disposes this instance.</summary>
        public void Dispose()
        {
            if (stream == null) throw new ObjectDisposedException("NamedPipeReader");
            reader.Close(); 
            reader = null; 
            stream = null;
            GC.SuppressFinalize(this);
        }
    }
}

#endif
