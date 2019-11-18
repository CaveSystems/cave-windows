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
    /// microsoft windows process specific access rights
    /// </summary>
    
    [Flags]
    public enum ACCESS_PROCESS : uint
    {
        /// <summary>right to terminate the process</summary>
        TERMINATE = 0x0001,

        /// <summary>right to create a thread</summary>
        CREATE_THREAD = 0x0002,

        /// <summary>right to set the session id of the process</summary>
        SET_SESSIONID = 0x0004,

        /// <summary></summary>
        VM_OPERATION = 0x0008,

        /// <summary>right to read the virtual memory of the process</summary>
        VM_READ = 0x0010,

        /// <summary>right to write the virtual memory of the process</summary>
        VM_WRITE = 0x0020,

        /// <summary></summary>
        DUP_HANDLE = 0x0040,

        /// <summary>right to create a process</summary>
        CREATE_PROCESS = 0x0080,

        /// <summary>right to set the quota of the process</summary>
        SET_QUOTA = 0x0100,

        /// <summary></summary>
        SET_INFORMATION = 0x0200,

        /// <summary>right to query information about a process</summary>
        QUERY_INFORMATION = 0x0400,

        /// <summary>right to suspend and resume a process</summary>
        SUSPEND_RESUME = 0x0800,

        /// <summary></summary>
        QUERY_LIMITED_INFORMATION = 0x1000,

        /// <summary>full access rights for nt..xp processes</summary>
        ALaCCESS_NT = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFF),

        /// <summary>full access rights for vista+ processes</summary>
        ALaCCESS_VISTA = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFFF),
    }
}
