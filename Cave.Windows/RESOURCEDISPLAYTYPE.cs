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
    /// The display options for the network object in a network browsing user interface
    /// </summary>
    public enum RESOURCEDISPLAYTYPE : int
    {
        /// <summary>
        /// The object should be displayed as a domain.
        /// </summary>
        RESOURCEDISPLAYTYPE_DOMAIN = 0x1,
        /// <summary>
        /// The method used to display the object does not matter.
        /// </summary>
        RESOURCEDISPLAYTYPE_GENERIC = 0x0,
        /// <summary>
        /// The object should be displayed as a server.
        /// </summary>
        RESOURCEDISPLAYTYPE_SERVER = 0x2,
        /// <summary>
        /// The object should be displayed as a share.
        /// </summary>
        RESOURCEDISPLAYTYPE_SHARE = 0x3,
        /// <summary>
        /// The object should be displayed as a file.
        /// </summary>
        RESOURCEDISPLAYTYPE_FILE = 0x4,
        /// <summary>
        /// The object should be displayed as a group.
        /// </summary>
        RESOURCEDISPLAYTYPE_GROUP = 0x5,
        /// <summary>
        /// The object should be displayed as a network.
        /// </summary>
        RESOURCEDISPLAYTYPE_NETWORK = 0x6,
        /// <summary>
        /// The object should be displayed as a logical root for the entire network.
        /// </summary>
        RESOURCEDISPLAYTYPE_ROOT = 0x7,
        /// <summary>
        /// The object should be displayed as a administrative share.
        /// </summary>
        RESOURCEDISPLAYTYPE_SHAREADMIN = 0x8,
        /// <summary>
        /// The object should be displayed as a directory.
        /// </summary>
        RESOURCEDISPLAYTYPE_DIRECTORY = 0x9,
        /// <summary>
        /// The object should be displayed as a tree. This display type was used for a NetWare Directory Service (NDS) tree by the NetWare Workstation service supported on Windows XP and earlier.
        /// </summary>
        RESOURCEDISPLAYTYPE_TREE = 0xA,
        /// <summary>
        /// The object should be displayed as a Netware Directory Service container. This display type was used by the NetWare Workstation service supported on Windows XP and earlier.
        /// </summary>
        RESOURCEDISPLAYTYPE_NDSCONTAINER = 0xA,
    }
}
