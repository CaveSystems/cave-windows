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

namespace Cave.Windows
{
    /// <summary>
    /// Memory Protection Constants
    /// </summary>
    
    [Flags]
    public enum MEM_PROTECT : uint
    {
        /// <summary>
        /// Disables all access to the committed region of pages. An attempt to read from, write to, or execute the committed region results in an access violation.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        PAGE_NOACCESS = 0x01,
        /// <summary>
        /// Enables read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation. If Data Execution Prevention is enabled, an attempt to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READONLY = 0x02,
        /// <summary>
        /// Enables read-only or read/write access to the committed region of pages. If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// </summary>
        PAGE_READWRITE = 0x04,
        /// <summary>
        /// Enables read-only or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process. The private page is marked as PAGE_READWRITE, and the change is written to the new page. If Data Execution Prevention is enabled, attempting to execute code in the committed region results in an access violation.
        /// This flag is not supported by the VirtualAlloc or VirtualAllocEx functions.
        /// </summary>
        PAGE_WRITECOPY = 0x08,
        /// <summary>
        /// Enables execute access to the committed region of pages. An attempt to read from or write to the committed region results in an access violation.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        PAGE_EXECUTE = 0x10,
        /// <summary>
        /// Enables execute or read-only access to the committed region of pages. An attempt to write to the committed region results in an access violation.
        /// Windows Server 2003 and Windows XP:  This attribute is not supported by the CreateFileMapping function until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        PAGE_EXECUTE_READ = 0x20,
        /// <summary>
        /// Enables execute, read-only, or read/write access to the committed region of pages.
        /// Windows Server 2003 and Windows XP:  This attribute is not supported by the CreateFileMapping function until Windows XP with SP2 and Windows Server 2003 with SP1.
        /// </summary>
        PAGE_EXECUTE_READWRITE = 0x40,
        /// <summary>
        /// Enables execute, read-only, or copy-on-write access to a mapped view of a file mapping object. An attempt to write to a committed copy-on-write page results in a private copy of the page being made for the process. The private page is marked as PAGE_EXECUTE_READWRITE, and the change is written to the new page.
        /// This flag is not supported by the VirtualAlloc or VirtualAllocEx functions.
        /// Windows Vista, Windows Server 2003, and Windows XP:  This attribute is not supported by the CreateFileMapping function until Windows Vista with SP1 and Windows Server 2008.
        /// </summary>
        PAGE_EXECUTE_WRITECOPY = 0x80,
        /// <summary>
        /// Pages in the region become guard pages. Any attempt to access a guard page causes the system to raise a STATUS_GUARD_PAGE_VIOLATION exception and turn off the guard page status. Guard pages thus act as a one-time access alarm. For more information, see Creating Guard Pages.
        /// When an access attempt leads the system to turn off guard page status, the underlying page protection takes over.
        /// If a guard page exception occurs during a system service, the service typically returns a failure status indicator.
        /// This value cannot be used with PAGE_NOACCESS.
        /// This flag is not supported by the CreateFileMapping function.
        /// </summary>
        PAGE_GUARD = 0x100,
        /// <summary>
        /// Sets all pages to be non-cachable. Applications should not use this attribute except when explicitly required for a device. Using the interlocked functions with memory that is mapped with SEC_NOCACHE can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The PAGE_NOCACHE flag cannot be used with the PAGE_GUARD, PAGE_NOACCESS, or PAGE_WRITECOMBINE flags.
        /// The PAGE_NOCACHE flag can be used only when allocating private memory with the VirtualAlloc, VirtualAllocEx, or VirtualAllocExNuma functions. To enable non-cached memory access for shared memory, specify the SEC_NOCACHE flag when calling the CreateFileMapping function.
        /// </summary>
        PAGE_NOCACHE = 0x200,
        /// <summary>
        /// Sets all pages to be write-combined.
        /// Applications should not use this attribute except when explicitly required for a device. Using the interlocked functions with memory that is mapped as write-combined can result in an EXCEPTION_ILLEGAL_INSTRUCTION exception.
        /// The PAGE_WRITECOMBINE flag cannot be specified with the PAGE_NOACCESS, PAGE_GUARD, and PAGE_NOCACHE flags.
        /// The PAGE_WRITECOMBINE flag can be used only when allocating private memory with the VirtualAlloc, VirtualAllocEx, or VirtualAllocExNuma functions. To enable write-combined memory access for shared memory, specify the SEC_WRITECOMBINE flag when calling the CreateFileMapping function.
        /// Windows Server 2003 and Windows XP:  This flag is not supported until Windows Server 2003 with SP1.
        /// </summary>
        PAGE_WRITECOMBINE = 0x400,
    }
}
