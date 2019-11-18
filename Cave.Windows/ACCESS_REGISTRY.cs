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
    /// Provides access flags for the microsoft windows registry
    /// </summary>
    
    [Flags]
    public enum ACCESS_REGISTRY : int
    {
        /// <summary>
        /// query value allowed
        /// </summary>
        KEY_QUERY_VALUE = 0x1,

        /// <summary>
        /// set value allowed
        /// </summary>
        KEY_SET_VALUE = 0x2,

        /// <summary>
        /// create sub key allowed
        /// </summary>
        KEY_CREATE_SUB_KEY = 0x4,

        /// <summary>
        /// enumerate sub keys allowed
        /// </summary>
        KEY_ENUMERATE_SUB_KEYS = 0x8,

        /// <summary>
        /// notifications abount content/subkey changes allowed
        /// </summary>
        KEY_NOTIFY = 0x10,

        /// <summary>
        /// link creation allowed
        /// </summary>
        KEY_CREATE_LINK = 0x20,

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 64-bit registry view
        /// </summary>
        KEY_WOW64_64KEY = 0x100,

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 32-bit registry view.
        /// </summary>
        KEY_WOW64_32KEY = 0x200,

        /// <summary>
        /// combines all default read rights
        /// </summary>
        KEY_READ = ACCESS.STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY,

        /// <summary>
        /// combines all default write rights
        /// </summary>
        KEY_WRITE = ACCESS.STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY,

        /// <summary>
        /// same as <see cref="KEY_READ"/>
        /// </summary>
        KEY_EXECUTE = KEY_READ,

        /// <summary>
        /// full access allowed
        /// </summary>
        KEY_ALL_ACCESS = ACCESS.STANDARD_RIGHTS_REQUIRED | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY | KEY_CREATE_LINK,
    }
}
