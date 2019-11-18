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

#if !NETSTANDARD20

using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a wrapper for SysListView32 controls
    /// </summary>
    public class SysListView32 : IDisposable
    {
        const uint LVM_FIRST = 0x1000;
        const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        const uint LVM_GETITEM = LVM_FIRST + 75;
        const uint LVIF_TEXT = 0x0001;

        [StructLayout(LayoutKind.Sequential)]
        private struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        IntPtr ControlHandle;
        int ProcessID;
        IntPtr ProcessHandle;
        IntPtr ForeignItemBuffer;
        IntPtr ForeignTextBuffer;
        IntPtr LocalBuffer;

        /// <summary>
        /// Creates a new SysListView32 instance
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="controlHandle"></param>
        public SysListView32(IntPtr processHandle, IntPtr controlHandle)
        {
            string className = USER32.GetClassName(controlHandle);
            if (className != "SysListView32") throw new ArgumentException("Control is not a SysListView32");
            ControlHandle = controlHandle;
            USER32.GetWindowThreadProcessId(controlHandle, out ProcessID);
            ProcessHandle = processHandle;

            ForeignTextBuffer = KERNEL32.SafeNativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, 512, MEM_STATE.ALLOCATE_NEW, MEM_PROTECT.PAGE_READWRITE);
            ForeignItemBuffer = KERNEL32.SafeNativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, 512, MEM_STATE.ALLOCATE_NEW, MEM_PROTECT.PAGE_READWRITE);
            LocalBuffer = Marshal.AllocHGlobal(512);
        }

        /// <summary>
        /// Releases all unmanaged resources
        /// </summary>
        ~SysListView32()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes all managed and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            Dispose(false);
        }

        void Dispose(bool finalizing)
        {
            if (ForeignItemBuffer != IntPtr.Zero)
            {
                KERNEL32.SafeNativeMethods.VirtualFreeEx(ProcessHandle, ForeignItemBuffer, 0, MEM_STATE.RELEASE);
                ForeignItemBuffer = IntPtr.Zero;
            }
            if (ForeignTextBuffer != IntPtr.Zero)
            {
                KERNEL32.SafeNativeMethods.VirtualFreeEx(ProcessHandle, ForeignTextBuffer, 0, MEM_STATE.RELEASE);
                ForeignTextBuffer = IntPtr.Zero;
            }
            if (LocalBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(LocalBuffer);
                LocalBuffer = IntPtr.Zero;
            }
            if (!finalizing) GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Obtains the cell text of the specified cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetCellText(int row, int column)
        {
            LVITEM lvi = new LVITEM();
            lvi.mask = LVIF_TEXT;
            lvi.cchTextMax = 512;
            lvi.iItem = row;
            lvi.iSubItem = column;
            lvi.pszText = ForeignTextBuffer;
            Marshal.StructureToPtr(lvi, LocalBuffer, false);
            IntPtr l_Written;
            //write to foreign process memory
            if (!KERNEL32.SafeNativeMethods.WriteProcessMemory(ProcessHandle, ForeignItemBuffer, LocalBuffer, new IntPtr(512), out l_Written))
            {
                throw new Exception("Could not write to foreign process.");
            }
            //tell control go give me the content
            USER32.SendMessage(ControlHandle, LVM_GETITEM, IntPtr.Zero, ForeignItemBuffer);
            //read the result
            IntPtr l_Read;
            if (!KERNEL32.SafeNativeMethods.ReadProcessMemory(ProcessHandle, ForeignTextBuffer, LocalBuffer, new IntPtr(512), out l_Read))
            {
                throw new Exception("Could not read from foreign process.");
            }
            return Marshal.PtrToStringAuto(LocalBuffer);
        }

        /// <summary>
        /// Obtains the row count
        /// </summary>
        public int RowCount
        {
            get
            {
                return USER32.SendMessage(ControlHandle, LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero).ToInt32();
            }
        }

        /// <summary>
        /// Controls the text of the control
        /// </summary>
        public string Text
        {
            get
            {
                return USER32.GetWindowText(ControlHandle);
            }
        }
    }
}

#endif