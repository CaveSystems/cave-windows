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
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MEMORY_BASIC_INFORMATION_32
    {
        /// <summary>Address of queried memory page.</summary>
        public uint BaseAddress;
        /// <summary>Base address of allocation. It's different (typically less) to BaseAddress when user allocate more then one page length memory block, and change attributes of a part of allocated block.</summary>
        public uint AllocationBase;
        /// <summary>Access type on memory allocation</summary>
        public MEM_PROTECT AllocationProtect;
        /// <summary>Size of queried region, in bytes.</summary>
        public uint RegionSize;
        /// <summary>State of memory block</summary>
        public MEM_STATE State;
        /// <summary>Current protection of queried memory block.</summary>
        public MEM_PROTECT Protect;
        /// <summary> Type of queried memory block</summary>
        public MEM_TYPE Type;
    }

    /// <summary>
    /// Contains information about a range of pages in the virtual address space of a process. The VirtualQuery and VirtualQueryEx functions use this structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MEMORY_BASIC_INFORMATION_64
    {
        /// <summary>Address of queried memory page.</summary>
        public ulong BaseAddress;
        /// <summary>Base address of allocation. It's different (typically less) to BaseAddress when user allocate more then one page length memory block, and change attributes of a part of allocated block.</summary>
        public ulong AllocationBase;
        /// <summary></summary>
        public MEM_PROTECT AllocationProtect;

        /// <summary>
        /// Do not use
        /// </summary>
        [Obsolete("May not be used")]
        public uint Alignment1;

        /// <summary>Size of queried region, in bytes.</summary>
        public ulong RegionSize;
        /// <summary>State of memory block</summary>
        public MEM_STATE State;
        /// <summary>Current protection of queried memory block.</summary>
        public MEM_PROTECT Protect;
        /// <summary> Type of queried memory block</summary>
        public MEM_TYPE Type;

        /// <summary>
        /// Do not use
        /// </summary>
        [Obsolete("May not be used")]
        public uint Alignment2;
    }
}
