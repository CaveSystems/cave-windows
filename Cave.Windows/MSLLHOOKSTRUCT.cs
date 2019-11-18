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
    /// The MSLLHOOKSTRUCT structure contains information about a low-level keyboard input event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MSLLHOOKSTRUCT
    {
        /// <summary>
        /// Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
        /// </summary>
        public POINT pt;
        /// <summary>
        /// If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.
        /// The low-order word is reserved. A positive value indicates that the wheel was rotated forward,
        /// away from the user; a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as WHEEL_DELTA, which is 120.
        ///If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
        /// or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released,
        /// and the low-order word is reserved. This value can be one or more of the following values. Otherwise, mouseData is not used.
        ///XBUTTON1
        ///The first X button was pressed or released.
        ///XBUTTON2
        ///The second X button was pressed or released.
        /// </summary>
        public int mouseData;
        /// <summary>
        /// Specifies the event-injected flag. An application can use the following value to test the mouse flags. Value Purpose
        ///LLMHF_INJECTED Test the event-injected flag.
        ///0
        ///Specifies whether the event was injected. The value is 1 if the event was injected; otherwise, it is 0.
        ///1-15
        ///Reserved.
        /// </summary>
        public int flags;
        /// <summary>
        /// Specifies the time stamp for this message.
        /// </summary>
        public int time;
        /// <summary>
        /// Specifies extra information associated with the message.
        /// </summary>
        public int dwExtraInfo;
    }
}
