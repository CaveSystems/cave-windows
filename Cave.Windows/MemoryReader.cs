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

        int m_ReadPosition = 0;
        int m_NextPacketNumber = -1;

        /// <summary>Gets the container information.</summary>
        /// <returns></returns>
        public MemoryContainerInfo GetContainerInfo()
        {
            return (MemoryContainerInfo)Marshal.PtrToStructure(ContainerInfoPointer, typeof(MemoryContainerInfo));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryReader" /> class.
        /// </summary>
        /// <param name="containerInfoPointer">The container information pointer.</param>
        /// <exception cref="ArgumentNullException">Pointer</exception>
        /// <exception cref="ArgumentException">Length has to be 8 byte aligned!</exception>
        public MemoryReader(IntPtr containerInfoPointer)
        {
            ContainerInfoPointer = containerInfoPointer;
            MemoryContainerInfo containerInfo = GetContainerInfo();
            if (containerInfo.Data == IntPtr.Zero) throw new ArgumentNullException("Pointer");
            if (containerInfo.Length % 8 != 0) throw new ArgumentException("Length has to be 8 byte aligned!");
        }

        /// <summary>Gets the available.</summary>
        /// <value>The available.</value>
        public uint Available
        {
            get
            {
                MemoryContainerInfo containerInfo = GetContainerInfo();
                int l_WritePosition = containerInfo.Position;
                if (m_ReadPosition < l_WritePosition)
                {
                    return (uint)(l_WritePosition - m_ReadPosition);
                }
                if (m_ReadPosition > l_WritePosition)
                {
                    return (uint)(containerInfo.Length - m_ReadPosition + l_WritePosition);
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

            MemoryContainerInfo containerInfo = GetContainerInfo();
            result = new T();
            int valueSize = Marshal.SizeOf(result);
            if (valueSize + 8 > Available) return false;
            int l_PacketNumber = Marshal.ReadInt32(containerInfo.Data, m_ReadPosition);
            int packetSize = Marshal.ReadInt32(containerInfo.Data, m_ReadPosition + 4);
            if (l_PacketNumber != m_NextPacketNumber)
            {
                if (0 == (flags & Flags.AllowResync))
                {
                    throw new Exception("Packet number mismatch, its likely we got an overflow at the ringbuffer! You can use Resync to read subsequent data...");
                }

                //do resync
                while (Available > 8)
                {
                    l_PacketNumber = Marshal.ReadInt32(containerInfo.Data, m_ReadPosition);
                    packetSize = Marshal.ReadInt32(containerInfo.Data, m_ReadPosition + 4);

                    if ((l_PacketNumber < -0xFFFF) || (packetSize > containerInfo.Length))
                    {
                        Debug.WriteLine("Resync needed at memory container.");
                        m_ReadPosition = (m_ReadPosition + 4) % containerInfo.Length;
                        continue;
                    }

                    if (packetSize != valueSize)
                    {
                        Debug.WriteLine($"Skipping packet with size {packetSize} at memory container.");
                        m_ReadPosition = (int)((m_ReadPosition + 8 + packetSize) % containerInfo.Length);
                    }
                }
            }
            if (packetSize != valueSize) throw new ArgumentException("Packet size does not match structure size!");
            if (containerInfo.Length - m_ReadPosition > packetSize + 8)
            {
                //packet not completed ?
                if (containerInfo.Position <= packetSize) return false;
                //read packet at buffer start
                Marshal.PtrToStructure(containerInfo.Data, result);
                m_ReadPosition = packetSize;
            }
            else
            {
                //full packet
                Marshal.PtrToStructure(new IntPtr(containerInfo.Data.ToInt64() + m_ReadPosition + 8), result);
                m_ReadPosition = (int)((m_ReadPosition + 8 + packetSize) % containerInfo.Length);
            }
            if (--m_NextPacketNumber < -0xFFFF) m_NextPacketNumber = -1;
            return true;
        }

        /// <summary>Closes this instance.</summary>
        public void Close()
        {
        }
    }
}
