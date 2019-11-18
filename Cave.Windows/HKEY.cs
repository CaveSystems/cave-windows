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
    /// Windows handles to registry hives
    /// </summary>
    
    public enum HKEY : int
    {
        /// <summary>
        /// Defines the types (or classes) of documents and the properties associated with those types. This field reads the Windows registry base key HKEY_CLASSES_ROOT.
        /// </summary>
        CLASSES_ROOT = unchecked((int)0x80000000),

        /// <summary>
        /// Contains information about the current user preferences. This field reads the Windows registry base key HKEY_CURRENT_USER
        /// </summary>
        CURRENT_USER = unchecked((int)0x80000001),

        /// <summary>
        /// Contains the configuration data for the local machine. This field reads the Windows registry base key HKEY_LOCAL_MACHINE.
        /// </summary>
        LOCAL_MACHINE = unchecked((int)0x80000002),

        /// <summary>
        /// Contains information about the default user configuration. This field reads the Windows registry base key HKEY_USERS.
        /// </summary>
        USERS = unchecked((int)0x80000003),

        /// <summary>
        /// Contains performance information for software components. This field reads the Windows registry base key HKEY_PERFORMANCE_DATA.
        /// </summary>
        PERFORMANCE_DATA = unchecked((int)0x80000004),

        /// <summary>
        /// Contains configuration information pertaining to the hardware that is not specific to the user. This field reads the Windows registry base key HKEY_CURRENT_CONFIG.
        /// </summary>
        CURRENT_CONFIG = unchecked((int)0x80000005),

        /// <summary>
        /// Obsolete. Contains dynamic registry data. This field reads the Windows registry base key HKEY_DYN_DATA.
        /// </summary>
        [Obsolete]
        DYN_DATA = unchecked((int)0x80000006),
    }
}
