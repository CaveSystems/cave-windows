#region CopyRight 2018
/*
    Copyright (c) 2016-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:

 */
#endregion

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
        /// <summary>Gets the name of the log source.</summary>
        /// <value>The name of the log source.</value>
        public string LogSourceName { get { return "NamedPipeReader"; } }

        DataReader m_Reader;
        NamedPipeClientStream m_Stream;
        int m_NextPacketNumber = -1;

        void Connect()
        {
            if (!m_Stream.IsConnected)
            {
                m_Stream.Connect(1000);
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
            m_Stream = stream;
            m_Reader = new DataReader(m_Stream);
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
            if (!m_Stream.IsConnected)
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
            
            int packetNumber = m_Reader.ReadInt32();
            int packetSize;
            result = new T();
            int valueSize = Marshal.SizeOf(result);
            if (packetNumber != m_NextPacketNumber)
            {
                Debug.WriteLine("Resync required at named pipe!");
                if (0 == (flags & Flags.AllowResync))
                {
                    throw new Exception("Packet number mismatch, its likely we lost synchronization! You can use Resync to read subsequent data...");
                }

                //do resync
                while (true)
                {
                    packetNumber = m_Reader.ReadInt32();
                    if (packetNumber < -0xFFFF)
                    {
                        Debug.WriteLine("Skipping invalid data");
                        continue;
                    }

                    packetSize = m_Reader.ReadInt32();
                    if (packetSize != valueSize)
                    {
                        Debug.WriteLine($"Skipping packet with size {packetSize} at named pipe.");
                        m_Reader.ReadBytes(packetSize);
                    }
                }
            }
            else
            {
                packetSize = m_Reader.ReadInt32();
                if (packetSize != valueSize) throw new ArgumentException("Packet size does not match structure size!");
            }

            byte[] data = m_Reader.ReadBytes(packetSize);
            result = MarshalStruct.GetStruct<T>(data);
            if (--m_NextPacketNumber < -0xFFFF) m_NextPacketNumber = -1;
            return true;
        }

        /// <summary>Disposes this instance.</summary>
        public void Dispose()
        {
            if (m_Stream == null) throw new ObjectDisposedException("NamedPipeReader");
            m_Reader.Close(); m_Reader = null; m_Stream = null;
        }
    }
}
#endif
