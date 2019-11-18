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
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Provides Win32 exceptions retrieved by KERNEL32.GetLastError()
    /// </summary>
    public class Win32ErrorException : Exception
    {
        /// <summary>
        /// Obtains a message for the specified Win32 error code by calling <see cref="KERNEL32.SafeNativeMethods.FormatMessage"/>
        /// </summary>
        /// <param name="errorCode">Win32 <see cref="ErrorCode"/></param>
        /// <returns>Returns a message</returns>
        public static string GetMessage(ErrorCode errorCode)
        {
            StringBuilder result = new StringBuilder(KERNEL32.DefaultStructBufferSize);
            uint count = KERNEL32.SafeNativeMethods.FormatMessage(FORMAT_MESSAGE.IGNORE_INSERTS | FORMAT_MESSAGE.FROM_SYSTEM | FORMAT_MESSAGE.ARGUMENT_ARRAY, IntPtr.Zero, errorCode, 0, result, (uint)result.Capacity, IntPtr.Zero);
            if (count != 0)
            {
                return result.ToString();
            }
            else
            {
                return string.Format("Unknown Win32 error code {0}", errorCode);
            }
        }

        /// <summary>
        /// Obtains the errorcode used to generate this exception
        /// </summary>
        public ErrorCode ErrorCode { get; }

        /// <summary>
        /// Creates a new exception with a message retrieved by using the last win32 error code retrieved by <see cref="Marshal.GetLastWin32Error()"/>
        /// </summary>
        public Win32ErrorException() : this((ErrorCode)Marshal.GetLastWin32Error()) { }

        /// <summary>
        /// Creates a new exception with a message retrieved by using the specified error code
        /// </summary>
        /// <param name="errorCode">The Win32 error code</param>
        public Win32ErrorException(ErrorCode errorCode) : base(GetMessage(errorCode)) { ErrorCode = errorCode; }

        /// <summary>
        /// Creates a new exception with a message retrieved by using the specified error code
        /// </summary>
        /// <param name="errorCode">The Win32 error code</param>
        public Win32ErrorException(int errorCode) : this((ErrorCode)errorCode) { }
    }
}
