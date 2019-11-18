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
    /// thread-specific access rights.
    /// </summary>
    
    [Flags]
    public enum ACCESS_THREAD : uint
    {
        /// <summary>right to terminate a thread</summary>
        TERMINATE = (0x0001),

        /// <summary>right to suspend and resume a thread</summary>
        SUSPEND_RESUME = (0x0002),

        /// <summary>right to retrieve the threadcontext</summary>
        GET_CONTEXT = (0x0008),

        /// <summary>right to set the threadcontext</summary>
        SET_CONTEXT = (0x0010),

        /// <summary>right to set the threadinformation</summary>
        SET_INFORMATION = (0x0020),

        /// <summary>right to retrieve the threadinformation</summary>
        QUERY_INFORMATION = (0x0040),

        /// <summary></summary>
        SET_THREAD_TOKEN = (0x0080),

        /// <summary></summary>
        IMPERSONATE = (0x0100),

        /// <summary></summary>
        DIRECT_IMPERSONATION = (0x0200),

        /// <summary></summary>
        SET_LIMITED_INFORMATION = (0x0400),

        /// <summary></summary>
        THREAD_QUERY_LIMITED_INFORMATION = (0x0800),

        /// <summary>full access rights for nt..xp threads</summary>
        ALL_ACCESS_NT = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0x3FF),

        /// <summary>full access rights for vista+ threads</summary>
        ALL_ACCESS_VISTA = (ACCESS.STANDARD_RIGHTS_REQUIRED | ACCESS.SYNCHRONIZE | 0xFFFF),
    }
}
