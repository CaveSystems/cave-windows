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
    /// Provides formatting options for <see cref="KERNEL32.SafeNativeMethods.FormatMessage"/>
    /// </summary>
    public enum FORMAT_MESSAGE
    {
        /// <summary>
        /// The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated buffer at the address specified by lpBuffer. The lpBuffer parameter is a pointer to an LPTSTR; you must cast the pointer to an LPTSTR (for example, (LPTSTR)lpBuffer). The nSize parameter specifies the minimum number of TCHARs to allocate for an output message buffer. The caller should use the LocalFree function to free the buffer when it is no longer needed.
        /// If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call to GetLastError will return ERROR_MORE_DATA.
        /// This value is not available for use when compiling Windows Store apps.
        /// </summary>
        ALLOCATE_BUFFER = 0x00000100,

        /// <summary>
        /// The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the arguments.
        /// This flag cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the va_list structure.
        /// </summary>
        ARGUMENT_ARRAY = 0x00002000,

        /// <summary>
        /// The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource handle is NULL, the current process's application image file will be searched. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.
        /// If the module has no message table resource, the function fails with ERROR_RESOURCE_TYPE_NOT_FOUND.
        /// </summary>
        FROM_HMODULE = 0x00000800,

        /// <summary>
        /// The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The message definition may contain insert sequences, just as the message text in a message table resource may. This flag cannot be used with FORMAT_MESSAGE_FROM_HMODULE or FORMAT_MESSAGE_FROM_SYSTEM.
        /// </summary>
        FROM_STRING = 0x00000400,

        /// <summary>
        /// The function should search the system message-table resource(s) for the requested message. If this flag is specified with FORMAT_MESSAGE_FROM_HMODULE, the function searches the system message table if the message is not found in the module specified by lpSource. This flag cannot be used with FORMAT_MESSAGE_FROM_STRING.
        /// If this flag is specified, an application can pass the result of the GetLastError function to retrieve the message text for a system-defined error.
        /// </summary>
        FROM_SYSTEM = 0x00001000,

        /// <summary>
        /// Insert sequences in the message definition are to be ignored and passed through to the output buffer unchanged. This flag is useful for fetching a message for later formatting. If this flag is set, the Arguments parameter is ignored.
        /// </summary>
        IGNORE_INSERTS = 0x00000200,

        /// <summary>
        /// The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks in the message definition text into the output buffer. The function generates no new line breaks.
        /// </summary>
        MAX_WIDTH_MASK = 0x000000FF,
    }
}
