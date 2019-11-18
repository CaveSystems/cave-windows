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

using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// This structure that holds the network resource data. It is returned during enumeration of resources on the network and during enumeration of currently connected resources.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NETRESOURCE
    {
        /// <summary>
        /// The scope of the enumeration.
        /// </summary>
        public SCOPE Scope;
        /// <summary>
        /// The type of resource.
        /// </summary>
        public RESOURCETYPE Type;
        /// <summary>
        /// The display options for the network object in a network browsing user interface
        /// </summary>
        public RESOURCEDISPLAYTYPE DisplayType;
        /// <summary>
        /// A set of bit flags describing how the resource can be used.
        /// </summary>
        public RESOURCEUSAGE Usage;
        /// <summary>
        /// If the dwScope member is equal to RESOURCE_CONNECTED or RESOURCE_REMEMBERED, this member is a pointer to a null-terminated character string that specifies the name of a local device
        /// </summary>
        public string LocalName;
        /// <summary>
        /// If the entry is a network resource, this member is a pointer to a null-terminated character string that specifies the remote network name.
        /// </summary>
        public string RemoteName;
        /// <summary>
        /// A pointer to a NULL-terminated string that contains a comment supplied by the network provider.
        /// </summary>
        public string Comment;
        /// <summary>
        /// A pointer to a NULL-terminated string that contains the name of the provider that owns the resource. This member can be NULL if the provider name is unknown. To retrieve the provider name, you can call the  WNetGetProviderName function.
        /// </summary>
        public string Provider;
    }
}