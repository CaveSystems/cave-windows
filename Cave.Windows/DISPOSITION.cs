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
    /// microsoft windows creation disposition<br />
    /// For devices other than files, this parameter is usually set to OPEN_EXISTING.
    /// </summary>
    public enum DISPOSITION : int
    {
        /// <summary>
        /// Creates a new file, only if it does not already exist.
        /// If the specified file exists, the function fails and the last-error code is set to ERROR_FILE_EXISTS (80).
        /// If the specified file does not exist and is a valid path to a writable location, a new file is created.
        /// </summary>
        CREATE_NEW = 1,

        /// <summary>
        /// Creates a new file, always.
        /// If the specified file exists and is writable, the function overwrites the file, the function succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183).
        /// If the specified file does not exist and is a valid path, a new file is created, the function succeeds, and the last-error code is set to zero.
        /// </summary>
        CREATE_ALWAYS = 2,

        /// <summary>
        /// Opens a file or device, only if it exists.
        /// If the specified file or device does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        /// For more information about devices, see the Remarks section.
        /// </summary>
        OPEN_EXISTING = 3,

        /// <summary>
        /// Opens a file, always.
        /// If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS (183).
        /// If the specified file does not exist and is a valid path to a writable location, the function creates a file and the last-error code is set to zero.
        /// </summary>
        OPEN_ALWAYS = 4,

        /// <summary>
        /// Opens a file and truncates it so that its size is zero bytes, only if it exists.
        /// If the specified file does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        /// The calling process must open the file with the GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
        /// </summary>
        TRUNCATE_EXISTING = 5,
    }
}
