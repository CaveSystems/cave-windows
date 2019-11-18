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
        /// <summary>Gets the name of the log source.</summary>
        /// <value>The name of the log source.</value>
        public string LogSourceName { get { return "NamedPipeWriter"; } }

        NamedPipeServerStream m_Stream;
        DataWriter m_Writer;
        int m_NextPacketNumber = -1;
        IAsyncResult m_ConnectionResult;
        Exception m_Exception;

        void AsyncWaitConnection()
        {
            if (m_ConnectionResult != null) return;
            m_ConnectionResult = m_Stream.BeginWaitForConnection(delegate
            {
                try { m_Stream.EndWaitForConnection(m_ConnectionResult); }
                catch (Exception ex) { m_Exception = ex; }
                m_ConnectionResult = null;
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
            m_Stream = stream;
            m_Writer = new DataWriter(m_Stream);
            AsyncWaitConnection();
        }

        /// <summary>Writes the specified structure.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The structure.</param>
        public void Write<T>(T item) where T:struct
        {
            if (m_Exception != null)
            {
                Exception ex = m_Exception;
                m_Exception = null;
                throw ex;
            }
            if (!m_Stream.IsConnected)
            {
                if (m_ConnectionResult != null) return;
                AsyncWaitConnection();
            }            
            m_Writer.Write(m_NextPacketNumber);
            int packetSize = Marshal.SizeOf(item);
            int remainder = packetSize % 8;
            if (remainder > 0) packetSize += 8 - remainder;
            m_Writer.Write(packetSize);
            byte[] buffer = new byte[packetSize];
            MarshalStruct.Write(item, buffer, 0);
            m_Writer.Write(buffer);
            if (--m_NextPacketNumber < -0xFFFF) m_NextPacketNumber = -1;
            m_Writer.Flush();
        }

        /// <summary>Disposes this instance.</summary>
        public void Dispose()
        {
            if (m_Stream == null) throw new ObjectDisposedException("NamedPipeWriter");
            m_Writer.Close(); m_Writer = null; m_Stream = null;
        }
    }
}
#endif