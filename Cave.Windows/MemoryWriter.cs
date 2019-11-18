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

        MemoryContainerInfo m_ContainerInfo;
        int m_NextPacketNumber = -1;
        bool m_FreeMemory;

        /// <summary>Gets the container information.</summary>
        /// <returns></returns>
        public MemoryContainerInfo GetContainerInfo()
        {
            return (MemoryContainerInfo)Marshal.PtrToStructure(ContainerInfoPointer, typeof(MemoryContainerInfo));
        }

        /// <summary>Sets the container information.</summary>
        /// <param name="newPosition">The new position.</param>
        /// <exception cref="ArgumentException">Position has to be 8 byte aligned!</exception>
        /// <exception cref="ArgumentOutOfRangeException">Position</exception>
        void SetContainerInfo(int newPosition)
        {
            if (newPosition % 8 != 0) throw new ArgumentException("Position has to be 8 byte aligned!");
            if (newPosition > m_ContainerInfo.Length) throw new ArgumentOutOfRangeException(nameof(newPosition));
            m_ContainerInfo.Position = newPosition;
            Marshal.StructureToPtr(m_ContainerInfo, ContainerInfoPointer, true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryWriter"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">Name of the container.</param>
        /// <param name="size">Size of the data.</param>
        public MemoryWriter(uint id, string name, int size)
        {
            m_ContainerInfo = new MemoryContainerInfo()
            {
                ID = id,
                Data = Marshal.AllocHGlobal(size),
                WriterID = DefaultRNG.UInt32,
                Position = 0,
                Name = name,
                Length = size,
            };
            ContainerInfoPointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(MemoryContainerInfo)));
            m_FreeMemory = true;
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
            if (m_DisposedValue) throw new ObjectDisposedException("MemoryWriter");
            uint ID = DefaultRNG.UInt32;
            ContainerInfoPointer = containerInfoPointer;
            m_ContainerInfo = GetContainerInfo();
            if (m_ContainerInfo.Data == IntPtr.Zero) throw new ArgumentNullException("Pointer");
            if (m_ContainerInfo.Length % 8 != 0) throw new ArgumentException("Length has to be 8 byte aligned!");
            if (m_ContainerInfo.WriterID != 0) throw new Exception("There is already a writer connected to the container!");
            m_ContainerInfo.WriterID = ID;
            SetContainerInfo(0);
            MemoryContainerInfo checkContainerInfo = GetContainerInfo();
            if (!Equals(checkContainerInfo, m_ContainerInfo)) throw new Exception("Multiple writer access is not allowed at memory containers!");
        }

        /// <summary>Writes the specified structure.</summary>
        /// <typeparam name="T">structure type to use</typeparam>
        /// <param name="item">The structure.</param>
        /// <exception cref="Exception">Struct is too big to fit into the container. Try increasing the Container.Length</exception>
        public void Write<T>(T item) where T: struct
        {
            if (m_DisposedValue) throw new ObjectDisposedException("MemoryWriter");
            int l_PacketSize = Marshal.SizeOf(item);
            if (l_PacketSize + 8 > m_ContainerInfo.Length) throw new Exception("Struct is too big to fit into the container. Try increasing the Container.Length");
            Marshal.WriteInt32(m_ContainerInfo.Data, m_ContainerInfo.Position, m_NextPacketNumber);
            int remainder = l_PacketSize % 8;
            if (remainder > 0) l_PacketSize += 8 - remainder;
            Marshal.WriteInt32(m_ContainerInfo.Data, m_ContainerInfo.Position + 4, l_PacketSize);
            if (m_ContainerInfo.Position + 8 + l_PacketSize > m_ContainerInfo.Length)
            {
                Marshal.StructureToPtr(item, m_ContainerInfo.Data, true);
                SetContainerInfo(l_PacketSize);
            }
            else
            {
                Marshal.StructureToPtr(item, new IntPtr(m_ContainerInfo.Data.ToInt64() + 8), true);
                SetContainerInfo((m_ContainerInfo.Position + 8 + l_PacketSize) % m_ContainerInfo.Length);
            }
            if (--m_NextPacketNumber < -0xFFFF) m_NextPacketNumber = -1;
        }

        /// <summary>Closes this instance and frees all pointers.</summary>
        public void Close()
        {
            //signal all readers the exit
            MemoryContainerInfo info = m_ContainerInfo;
            info.WriterID = 0;
            info.ID = 0;
            info.Name = "";
            Marshal.StructureToPtr(info, ContainerInfoPointer, true);
        }

        #region IDisposable Support
        private bool m_DisposedValue = false;

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_DisposedValue)
            {
                if (disposing)
                {
                    Close();
                }
                if (m_FreeMemory)
                {
                    //wait for one second
                    Thread.Sleep(1000);
                    Marshal.FreeHGlobal(m_ContainerInfo.Data);
                    Marshal.FreeHGlobal(ContainerInfoPointer);
                }
                m_DisposedValue = true;
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
