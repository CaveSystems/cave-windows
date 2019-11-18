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

#if !NETSTANDARD20

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Specifies Desktop Window Manager (DWM) blur behind properties.
    /// </summary>    
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {
        /// <summary>
        /// A bitwise combination of DWM Blur Behind Constants values indicating which members are set.
        /// </summary>
        public DWM_BB Flags;

        /// <summary>
        /// TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Enable;

        /// <summary>
        /// The region within the client area to apply the blur behind. A NULL value will apply the blur behind the entire client area.
        /// </summary>
        IntPtr m_Region;

        /// <summary>
        /// TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool TransitionOnMaximized;

        /// <summary>
        /// Sets a new Region
        /// </summary>
        /// <param name="graphics">The Graphics on which this Region is drawn. </param>
        /// <param name="region">The Region to set</param>
        public void SetRegion(Graphics graphics, Region region)
        {
            m_Region = region.GetHrgn(graphics);
        }

        /// <summary>
        /// Obtains the Region
        /// </summary>
        /// <returns></returns>
        public Region GetRegion()
        {
            return Region.FromHrgn(m_Region);
        }
    }
}
#endif