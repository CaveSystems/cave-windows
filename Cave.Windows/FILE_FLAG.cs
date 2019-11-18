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
    /// Microsoft windows file attributes<br />
    /// The file or device attributes and flags, NORMAL being the most common default value for files.
    /// </summary>
    [Flags]
    public enum FILE_FLAG : uint
    {
        /// <summary>
        /// no flags given
        /// </summary>
        NONE = 0,

        /// <summary>
        /// The file is read only. Applications can read the file, but cannot write to or delete it.
        /// FILE_ATTRIBUTE_READONLY
        /// </summary>
        READONLY = 0x01,

        /// <summary>
        /// The file is hidden. Do not include it in an ordinary directory listing. FILE_ATTRIBUTE_HIDDEN
        /// </summary>
        HIDDEN = 0x02,

        /// <summary>
        /// The file is part of or used exclusively by an operating system.
        /// FILE_ATTRIBUTE_SYSTEM
        /// </summary>
        SYSTEM = 0x04,

        /// <summary>
        /// The handle that identifies a directory. FILE_ATTRIBUTE_DIRECTORY
        /// </summary>
        DIRECTORY = 0x10,

        /// <summary>
        /// The file should be archived. Applications use this attribute to mark files for backup or removal. FILE_ATTRIBUTE_ARCHIVE
        /// </summary>
        ARCHIVE = 0x20,

        /// <summary>
        /// This value is reserved for system use. FILE_ATTRIBUTE_DEVICE
        /// </summary>
        DEVICE = 0x40,

        /// <summary>
        /// The file does not have other attributes set. This attribute is valid only if used alone. FILE_ATTRIBUTE_NORMAL
        /// </summary>
        NORMAL = 0x80,

        /// <summary>
        /// A file that is being used for temporary storage. File systems avoid writing data back to mass storage if sufficient cache memory is available, because typically, an application deletes a temporary file after the handle is closed. In that scenario, the system can entirely avoid writing the data. Otherwise, the data is written after the handle is closed.
        /// For more information, see the Caching Behavior section of this topic.
        /// FILE_ATTRIBUTE_TEMPORARY
        /// </summary>
        TEMPORARY = 0x100,

        /// <summary>
        /// A file that is a sparse file. FILE_ATTRIBUTE_SPARSE_FILE
        /// </summary>
        SPARSE = 0x200,

        /// <summary>
        /// A file or directory that has an associated reparse point, or a file that is a symbolic link.
        /// FILE_ATTRIBUTE_REPARSE_POINT
        /// </summary>
        REPARSE_POINT = 0x400,

        /// <summary>
        /// A file or directory that is compressed. For a file, all of the data in the file is compressed. For a directory, compression is the default for newly created files and subdirectories. FILE_ATTRIBUTE_COMPRESSED
        /// </summary>
        COMPRESSED = 0x800,

        /// <summary>
        /// The data of a file is not immediately available. This attribute indicates that file data is physically moved to offline storage. This attribute is used by Remote Storage, the hierarchical storage management software. Applications should not arbitrarily change this attribute.
        /// FILE_ATTRIBUTE_OFFLINE
        /// </summary>
        OFFLINE = 0x1000,

        /// <summary>
        /// The file or directory is not to be indexed by the content indexing service.
        /// FILE_ATTRIBUTE_NOT_CONTENT_INDEXED
        /// </summary>
        NOT_INDEXED = 0x2000, 

        /// <summary>
        /// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means that encryption is the default for newly created files and subdirectories. For more information, see File Encryption.
        /// This flag has no effect if FILE_ATTRIBUTE_SYSTEM is also specified. 
        /// FILE_ATTRIBUTE_ENCRYPTED
        /// </summary>
        ENCRYPTED = 0x4000,

        /// <summary>
        /// The directory or user data stream is configured with integrity (only supported on ReFS volumes). It is not included in an ordinary directory listing. The integrity setting persists with the file if it's renamed. If a file is copied the destination file will have integrity set if either the source file or destination directory have integrity set. 
        /// FILE_ATTRIBUTE_INTEGRITY_STREAM
        /// </summary>
        INTEGRITY_STREAM = 0x8000,

        /// <summary>
        /// This value is reserved for system use.
        /// FILE_ATTRIBUTE_VIRTUAL
        /// </summary>
        VIRTUAL = 0x10000,

        /// <summary>
        /// The user data stream not to be read by the background data integrity scanner (AKA scrubber). When set on a directory it only provides inheritance. This flag is only supported on Storage Spaces and ReFS volumes. It is not included in an ordinary directory listing. 
        /// FILE_ATTRIBUTE_NO_SCRUB_DATA
        /// </summary>
        NO_SCRUB_DATA = 0x20000,

        /// <summary>
        /// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file security checks when the process has SE_BACKUname and SE_RESTORE_NAME privileges. For more information, see Changing Privileges in a Token.
        /// You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a file handle. For more information, see the Remarks section.
        /// FILE_FLAG_BACKUP_SEMANTICS
        /// </summary>
        BACKUP_SEMANTICS = 0x02000000,

        /// <summary>
        /// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other open or duplicated handles.
        /// If there are existing open handles to a file, the call fails unless they were all opened with the FILE_SHARE_DELETE share mode.
        /// Subsequent open requests for the file fail, unless the FILE_SHARE_DELETE share mode is specified.
        /// FILE_FLAG_DELETE_ON_CLOSE
        /// </summary>
        DELETE_ON_CLOSE = 0x04000000,

        /// <summary>
        /// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching or memory mapped files.
        /// There are strict requirements for successfully working with files opened with CreateFile using the FILE_FLAG_NO_BUFFERING flag, for details see File Buffering.
        /// FILE_FLAG_NO_BUFFERING
        /// </summary>
        NO_BUFFERING = 0x20000000,

        /// <summary>
        /// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local storage. This flag is for use by remote storage systems.
        /// FILE_FLAG_OPEN_NO_RECALL
        /// </summary>
        OPEN_NO_RECALL = 0x00100000,

        /// <summary>
        /// Normal reparse point processing will not occur; CreateFile will attempt to open the reparse point. When a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational.
        /// This flag cannot be used with the CREATE_ALWAYS flag.
        /// If the file is not a reparse point, then this flag is ignored.
        /// FILE_FLAG_OPEN_REPARSE_POINT
        /// </summary>
        OPEN_REPARSE_POINT = 0x00200000,

        /// <summary>
        /// The file or device is being opened or created for asynchronous I/O.
        /// When subsequent I/O operations are completed on this handle, the event specified in the OVERLAPPED structure will be set to the signaled state.
        /// If this flag is specified, the file can be used for simultaneous read and write operations.
        /// If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions specify an OVERLAPPED structure.
        /// FILE_FLAG_OVERLAPPED
        /// </summary>
        OVERLAPPED = 0x40000000,

        /// <summary>
        /// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file systems that support that naming. Use care when using this option, because files created with this flag may not be accessible by applications that are written for MS-DOS or 16-bit Windows.
        /// FILE_FLAG_POSIX_SEMANTICS
        /// </summary>
        POSIX_SEMANTICS = 0x0100000,

        /// <summary>
        /// Access is intended to be random. The system can use this as a hint to optimize file caching.
        /// This flag has no effect if the file system does not support cached I/O and NO_BUFFERING.
        /// FILE_FLAG_RANDOM_ACCESS
        /// </summary>
        RANDOM_ACCESS = 0x10000000,

        /// <summary>
        /// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
        /// This flag should not be used if read-behind (that is, backwards scans) will be used.
        /// This flag has no effect if the file system does not support cached I/O and NO_BUFFERING.
        /// FILE_FLAG_SEQUENTIAL_SCAN
        /// </summary>
        SEQUENTIAL_SCAN = 0x08000000,

        /// <summary>
        /// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a redirected USB device) cannot be opened by processes running in session 0. This flag has no effect for callers not in session 0. This flag is supported only on server editions of Windows.
        /// FILE_FLAG_SESSION_AWARE
        /// </summary>
        SESSION_AWARE = 0x00800000,

        /// <summary>
        /// Write operations will not go through any intermediate cache, they will go directly to disk.
        /// FILE_FLAG_WRITE_THROUGH
        /// </summary>
        WRITE_THROUGH = 0x80000000,

        /// <summary>
        /// FILE_FLAG_FIRST_PIPE_INSTANCE
        /// </summary>
        FIRST_PIPE_INSTANCE = 0x00080000,
    }
}
