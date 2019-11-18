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
    /// The window sizing and positioning flags. 
    /// </summary>
    [Flags]
    public enum SWP : int
    {
        /// <summary>
        /// Default value = 0
        /// </summary>
        DEFAULT = 0,

        /// <summary>
        /// Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        NOSIZE = 0x0001,

        /// <summary>
        /// Retains the current position (ignores X and Y parameters).
        /// </summary>
        NOMOVE = 0x0002,

        /// <summary>
        /// Retains the current Z order (ignores the hWndInsertAfter parameter).
        /// </summary>
        NOZORDER = 0x0004,

        /// <summary>
        /// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent window uncovered as a result of the window being moved. When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
        /// </summary>
        NOREDRAW = 0x0008,

        /// <summary>
        /// Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
        /// </summary>
        NOACTIVATE = 0x0010,

        /// <summary>
        /// Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. If this flag is not  specified , WM_NCCALCSIZE is sent only when the window's size is being changed.
        /// </summary>
        FRAMECHANGED = 0x0020,
        
        /// <summary>
        /// Displays the window.
        /// </summary>
        SHOWWINDOW = 0x0040,

        /// <summary>
        /// Hides the window.
        /// </summary>
        HIDEWINDOW = 0x0080,
        
        /// <summary>
        /// Discards the entire contents of the client area. If this flag is not  specified , the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
        /// </summary>
        NOCOPYBITS = 0x0100,

        /// <summary>
        /// Does not change the owner window's position in the Z order.
        /// </summary>
        NOOWNERZORDER = 0x0200,

        /// <summary>
        /// Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
        /// </summary>
        NOSENDCHANGING = 0x0400,

        /// <summary>
        /// Draws a frame (defined in the window's class description) around the window.
        /// </summary>
        DRAWFRAME = FRAMECHANGED,

        /// <summary>
        /// Same as the SWP_NOOWNERZORDER flag.
        /// </summary>
        NOREPOSITION = NOOWNERZORDER,
        
        /// <summary>
        /// Prevents generation of the WM_SYNCPAINT message. 
        /// </summary>
        DEFERERASE = 0x2000,
        
        /// <summary>
        /// If the calling thread and the thread that owns the window are attached to different input queues, the system posts the request to the thread that owns the window. This prevents the calling thread from blocking its execution while other threads process the request. 
        /// </summary>
        ASYNCWINDOWPOS = 0x4000,
    }
}
