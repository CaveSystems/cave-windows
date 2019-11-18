#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License MSPL
/*
    This file contains some sourcecode that uses Microsoft Windows API calls
    to provide functionality that is part of the underlying operating system.
    The API calls and their documentation are copyrighted work of Microsoft
    and/or its suppliers. Use of the Software is governed by the terms of the
    MICROSOFT LIMITED PUBLIC LICENSE.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE.MSPL file
    found at the installation directory or the distribution package.
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
#endregion License
#region Authors & Contributors
/*
   Information source:
     Microsoft Corporation

   Implementation:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion

using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a list of all running process ids
    /// </summary>
    public class PROCESSLIST : IEnumerable, IDisposable
    {
        IntPtr m_ListPointer;
        int m_Count = 0;
        int[] m_Items = null;
        int m_Size = 65536;

        /// <summary>
        ///
        /// </summary>
        public PROCESSLIST()
        {
            m_ListPointer = Marshal.AllocHGlobal(m_Size);
            Update();
        }

        /// <summary>
        /// Cleans up
        /// </summary>
        ~PROCESSLIST()
        {
            FreeHandle();
        }

        void FreeHandle()
        {
            if (m_ListPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(m_ListPointer);
                m_ListPointer = IntPtr.Zero;
            }
        }

        /// <summary>
        /// updates the process id list and returns the number of processes in the list
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int len;
            if (!PSAPI.EnumProcesses(m_ListPointer, 32768, out len))
            {
                if (len > m_Size)
                {
                    m_Size = len * 2;
                    Marshal.FreeHGlobal(m_ListPointer);
                    m_ListPointer = Marshal.AllocHGlobal(m_Size);
                    return Update();
                }
                throw new Win32ErrorException();
            }
            m_Count = len / 4;
            m_Items = null;
            return m_Count;
        }

        /// <summary>
        /// Obtains all process ids currently existing
        /// </summary>
        public int[] Items
        {
            get
            {
                if (m_Items == null)
                {
                    int[] result = new int[m_Count];
                    Marshal.Copy(m_ListPointer, result, 0, m_Count);
                    m_Items = result;
                }
                return m_Items;
            }
        }

        /// <summary>
        /// returns the number of process ids currently in the list. The process count is updated with <see cref="Update"/>
        /// </summary>
        public int Count { get { return m_Count; } }

        #region IEnumerable Member

        /// <summary>
        /// Obtains a Process ID enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        #endregion

        #region IDisposable Member

        /// <summary>
        /// frees all resources needed to provide the process list
        /// </summary>
        public void Dispose()
        {
            FreeHandle();
            //surpress finalizer
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
