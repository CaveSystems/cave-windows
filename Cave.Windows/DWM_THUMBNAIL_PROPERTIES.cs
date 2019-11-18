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
using Cave.Media.Structs;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Specifies Desktop Window Manager (DWM) thumbnail properties.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {
        /// <summary>
        /// A bitwise combination of DWM thumbnail constant values that indicate which members are set.
        /// </summary>
        public DWM_TNP Flags;

        /// <summary>
        /// The rectangle in the destination window the thumbnail will be rendered.
        /// </summary>
        public RECT Destination;

        /// <summary>
        /// The rectangle that specifies the region of the source window to use as the thumbnail. By default, the entire window is used as the thumbnail.
        /// </summary>
        public RECT Source;

        /// <summary>
        /// The opacity with which to render the thumbnail. 0 is fully transparent while 255 is fully opaque. The default value is 255.
        /// </summary>
        public byte Opacity;

        /// <summary>
        /// TRUE to make the thumbnail visible; FALSE to make the thumbnail invisible. The default is FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Visible;

        /// <summary>
        /// TRUE to use only the thumbnail source's client area; otherwise, FALSE. The default is FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool SourceClientAreaOnly;
    }
}
