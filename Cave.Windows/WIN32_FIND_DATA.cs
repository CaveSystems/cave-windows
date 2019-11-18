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

using System.IO;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Contains information about the file that is found by the FindFirstFile, FindFirstFileEx, or FindNextFile function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 4+8+8+8+8+4+4+260+14, Pack = 1)]
    public struct WIN32_FIND_DATA
    {
        /// <summary>
        /// The file attributes of a file.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public FileAttributes FileAttributes;

        /// <summary>
        /// A <see cref="FILETIME"/> structure that specifies when a file or directory was created.
        /// </summary>
        public FILETIME CreationTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.For a file, the structure specifies when the file was last read from, written to, or for executable files, run.
        /// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last access time, this member is zero.
        /// On the FAT file system, the specified date for both files and directories is correct, but the time of day is always set to midnight.
        /// </summary>
        public FILETIME LastAccessTime;

        /// <summary>
        /// A <see cref="FILETIME"/> structure.
        /// For a file, the structure specifies when the file was last written to, truncated, or overwritten, for example, when WriteFile or SetEndOfFile are used. The date and time are not updated when file attributes or security descriptors are changed.
        /// For a directory, the structure specifies when the directory is created. If the underlying file system does not support last write time, this member is zero.
        /// </summary>
        public FILETIME LastWriteTime;

        /// <summary>
        /// A <see cref="FILESIZE"/> structure representing the size of the file or 0 for directories.
        /// </summary>
        public FILESIZE FileSize;

        /// <summary>
        /// If the FileAttributes member includes the FILE_ATTRIBUTE_REPARSE_POINT attribute, this member specifies the reparse point tag.
        /// Otherwise, this value is undefined and should not be used.
        /// </summary>
        public uint Reserved0;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public uint Reserved1;

        /// <summary>
        /// The name of the file. (This is again subject to the MAX_PATH limitation!)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_PATH)]
        public string FileName;

        /// <summary>
        /// An alternative name for the file.
        /// This name is in the classic 8.3 file name format.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_SHORT_NAME)]
        public string Alternate;
    }
}
