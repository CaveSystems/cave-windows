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
    /// The RedrawWindow function updates the specified rectangle or region in a window's client area.
    /// </summary>
    [Flags]
    public enum RDW : int
    {
        /// <summary>
        /// Invalidates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is invalidated.
        /// </summary>
        INVALIDATE = 0x0001,
        /// <summary>
        /// Causes a WM_PAINT message to be posted to the window regardless of whether any portion of the window is invalid.
        /// </summary>
        INTERNALPAINT = 0x0002,
        /// <summary>
        /// Causes the window to receive a WM_ERASEBKGND message when the window is repainted. The INVALIDATE flag must also be specified; otherwise, ERASE has no effect.
        /// </summary>
        ERASE = 0x0004,
        /// <summary>
        /// Validates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is validated. This flag does not affect internal WM_PAINT messages.
        /// </summary>
        VALIDATE = 0x0008,
        /// <summary>
        /// Suppresses any pending internal WM_PAINT messages. This flag does not affect WM_PAINT messages resulting from a non-NULL update area.
        /// </summary>
        NOINTERNALPAINT = 0x0010,
        /// <summary>
        /// Suppresses any pending WM_ERASEBKGND messages.
        /// </summary>
        NOERASE = 0x0020,
        /// <summary>
        /// Excludes child windows, if any, from the repainting operation.
        /// </summary>
        NOCHILDREN = 0x0040,
        /// <summary>
        /// Includes child windows, if any, in the repainting operation.
        /// </summary>
        ALLCHILDREN = 0x0080,
        /// <summary>
        /// Causes the affected windows (as specified by the ALLCHILDREN and NOCHILDREN flags) to receive WM_NCPAINT, WM_ERASEBKGND, and WM_PAINT messages, if necessary, before the function returns.
        /// </summary>
        UPDATENOW = 0x0100,
        /// <summary>
        /// Causes the affected windows (as specified by the ALLCHILDREN and NOCHILDREN flags) to receive WM_NCPAINT and WM_ERASEBKGND messages, if necessary, before the function returns. WM_PAINT messages are received at the ordinary time.
        /// </summary>
        ERASENOW = 0x0200,
        /// <summary>
        /// Causes any part of the nonclient area of the window that intersects the update region to receive a WM_NCPAINT message. The INVALIDATE flag must also be specified; otherwise, FRAME has no effect. The WM_NCPAINT message is typically not sent during the execution of RedrawWindow unless either UPDATENOW or ERASENOW is specified.
        /// </summary>
        FRAME = 0x0400,
        /// <summary>
        /// Suppresses any pending WM_NCPAINT messages. This flag must be used with VALIDATE and is typically used with NOCHILDREN. NOFRAME should be used with care, as it could cause parts of a window to be painted improperly.
        /// </summary>
        NOFRAME = 0x0800,
    }
}
