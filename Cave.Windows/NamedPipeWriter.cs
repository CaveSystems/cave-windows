#if !NET20

using Cave.IO;
using System;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a writer (server) for named pipe communication
    /// </summary>
    public class NamedPipeWriter : IDisposable
    {
        NamedPipeServerStream stream;
        DataWriter writer;
        int nextPacketNumber = -1;
        IAsyncResult connectionResult;
        Exception exception;

        void AsyncWaitConnection()
        {
            if (connectionResult != null) return;
            connectionResult = stream.BeginWaitForConnection(delegate
            {
                try { stream.EndWaitForConnection(connectionResult); }
                catch (Exception ex) { exception = ex; }
                connectionResult = null;
            }, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPipeWriter"/> class.
        /// </summary>
        /// <param name="name">Name of the pipe.</param>
        public NamedPipeWriter(string name)
            : this(new NamedPipeServerStream(name, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPipeWriter"/> class.
        /// </summary>
        /// <param name="stream">The pipe stream.</param>
        /// <exception cref="ArgumentException">Invalid TransmissionMode!</exception>
        public NamedPipeWriter(NamedPipeServerStream stream)
        {
            if (stream.TransmissionMode != PipeTransmissionMode.Byte) throw new ArgumentException("Invalid TransmissionMode!");
            this.stream = stream;
            writer = new DataWriter(this.stream);
            AsyncWaitConnection();
        }

        /// <summary>Writes the specified structure.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The structure.</param>
        public void Write<T>(T item) where T:struct
        {
            if (exception != null)
            {
                var ex = exception;
                exception = null;
                throw ex;
            }
            if (!stream.IsConnected)
            {
                if (connectionResult != null) return;
                AsyncWaitConnection();
            }            
            writer.Write(nextPacketNumber);
            var packetSize = Marshal.SizeOf(item);
            var remainder = packetSize % 8;
            if (remainder > 0) packetSize += 8 - remainder;
            writer.Write(packetSize);
            var buffer = new byte[packetSize];
            MarshalStruct.Write(item, buffer, 0);
            writer.Write(buffer);
            if (--nextPacketNumber < -0xFFFF) nextPacketNumber = -1;
            writer.Flush();
        }

        /// <summary>Disposes this instance.</summary>
        public void Dispose()
        {
            if (stream == null) throw new ObjectDisposedException("NamedPipeWriter");
            writer.Close();
            writer = null; 
            stream = null;
            GC.SuppressFinalize(this);
        }
    }
}

#endif
