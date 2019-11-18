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
    /// Registry Key Security and Access Rights
    /// </summary>
    public enum REGKEYACCESS : int
    {
        /// <summary>
        /// Required to create a subkey of a registry key.
        /// </summary>
        KEY_CREATE_SUB_KEY = 0x4,

        /// <summary>
        /// Combines the STANDARD_RIGHTS_REQUIRED, KEY_QUERY_VALUE, KEY_SET_VALUE, KEY_CREATE_SUB_KEY, KEY_ENUMERATE_SUB_KEYS, KEY_NOTIFY, and KEY_CREATE_LINK access rights.
        /// </summary>
        KEY_ALaCCESS = 0xF003F,

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        KEY_CREATE_LINK =(0x0020),

        /// <summary>
        /// Required to enumerate the subkeys of a registry key.
        /// </summary>
        KEY_ENUMERATE_SUB_KEYS =(0x0008),

        /// <summary>
        /// Equivalent to KEY_READ.
        /// </summary>
        KEY_EXECUTE =(0x20019),

        /// <summary>
        /// Required to request change notifications for a registry key or for subkeys of a registry key.
        /// </summary>
        KEY_NOTIFY =(0x0010),

        /// <summary>
        /// Required to query the values of a registry key.
        /// </summary>
        KEY_QUERY_VALUE =(0x0001),

        /// <summary>
        /// Combines the STANDARD_RIGHTS_READ, KEY_QUERY_VALUE, KEY_ENUMERATE_SUB_KEYS, and KEY_NOTIFY values.
        /// </summary>
        KEY_READ =(0x20019),

        /// <summary>
        /// Required to create, delete, or set a registry value.
        /// </summary>
        KEY_SET_VALUE =(0x0002),

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 32-bit registry view. For more information, see Accessing an Alternate Registry View.
        /// </summary>
        KEY_WOW64_32KEY =(0x0200),

        /// <summary>
        /// Indicates that an application on 64-bit Windows should operate on the 64-bit registry view. For more information, see Accessing an Alternate Registry View.
        /// </summary>
        KEY_WOW64_64KEY =(0x0100),

        /// <summary>
        /// Combines the STANDARD_RIGHTS_WRITE, KEY_SET_VALUE, and KEY_CREATE_SUB_KEY access rights.
        /// </summary>
        KEY_WRITE =(0x20006),
    }
}
