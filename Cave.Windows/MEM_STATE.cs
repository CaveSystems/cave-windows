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


namespace Cave.Windows
{
    /// <summary>
    /// process memory state
    /// </summary>
    
    public enum MEM_STATE : uint
    {
        /// <summary>
        /// Reserves a range of the process's virtual address space and allocates physical storage in memory or in the paging file on disk.
        /// </summary>
        ALLOCATE_NEW = COMMIT | RESERVE,

        /// <summary>
        /// Allocates memory charges (from the overall size of memory and the paging files on disk) for the specified reserved memory pages. The function also guarantees that when the caller later initially accesses the memory, the contents will be zero. Actual physical pages are not allocated unless/until the virtual addresses are actually accessed.
        /// To reserve and commit pages in one step, call VirtualAllocEx with COMMIT | RESERVE.
        /// Attempting to commit a specific address range by specifying COMMIT without RESERVE and a non-NULL lpAddress fails unless the entire range has already been reserved. The resulting error code is ERROR_INVALID_ADDRESS.
        /// An attempt to commit a page that is already committed does not cause the function to fail. This means that you can commit pages without first determining the current commitment state of each page.
        /// </summary>
        COMMIT = 0x1000,

        /// <summary></summary>
        FREE = 0x10000,

        /// <summary>
        /// Reserves a range of the process's virtual address space without allocating any actual physical storage in memory or in the paging file on disk.
        /// You commit reserved pages by calling VirtualAllocEx again with MEM_COMMIT. To reserve and commit pages in one step, call VirtualAllocEx with COMMIT | RESERVE.
        /// Other memory allocation functions, such as malloc and LocalAlloc, cannot use reserved memory until it has been released.
        /// </summary>
        RESERVE = 0x2000,

        /// <summary>
        /// Decommits the specified region of committed pages. After the operation, the pages are in the reserved state.
        /// The function does not fail if you attempt to decommit an uncommitted page. This means that you can decommit a range of pages without first determining their current commitment state.
        /// Do not use this value with RELEASE.
        /// </summary>
        DECOMMIT = 0x4000,

        /// <summary>
        /// Releases the specified region of pages. After the operation, the pages are in the free state.
        /// If you specify this value, dwSize must be 0 (zero), and lpAddress must point to the base address returned by the VirtualAllocEx function when the region is reserved. The function fails if either of these conditions is not met.
        /// If any pages in the region are committed currently, the function first decommits, and then releases them.
        /// The function does not fail if you attempt to release pages that are in different states, some reserved and some committed. This means that you can release a range of pages without first determining the current commitment state.
        /// Do not use this value with DECOMMIT.
        /// </summary>
        RELEASE = 0x8000,

        /// <summary>
        /// Indicates that data in the memory range specified by lpAddress and dwSize is no longer of interest. The pages should not be read from or written to the paging file. However, the memory block will be used again later, so it should not be decommitted. This value cannot be used with any other value.
        /// </summary>
        RESET = 0x80000,

        /// <summary>
        /// MEM_RESET_UNDO should only be called on an address range to which MEM_RESET was successfully applied earlier. It indicates that the data in the specified memory range specified by lpAddress and dwSize is of interest to the caller and attempts to reverse the effects of MEM_RESET. If the function succeeds, that means all data in the specified address range is intact. If the function fails, at least some of the data in the address range has been replaced with zeroes.
        /// </summary>
        RESET_UNDO = 0x1000000,
    }
}
