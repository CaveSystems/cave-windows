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
    /// Commands used by the ShowWindow function that sets the specified window's show state.
    /// </summary>
    public enum SW : int
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        HIDE = 0,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        SHOWNORMAL = 1,
        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
        /// </summary>
        NORMAL = SHOWNORMAL,
        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SHOWMINIMIZED = 2,
        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SHOWMAXIMIZED = 3,
        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        MAXIMIZE = 3,
        /// <summary>
        /// Displays a window in its most recent size and position. This value is similar to SHOWNORMAL, except the window is not actived.
        /// </summary>
        SHOWNOACTIVATE = 4,
        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        SHOW = 5,
        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        MINIMIZE = 6,
        /// <summary>
        /// Displays the window as a minimized window. This value is similar to SHOWMINIMIZED, except the window is not activated.
        /// </summary>
        SHOWMINNOACTIVE = 7,
        /// <summary>
        /// Displays the window in its current size and position. This value is similar to SHOW, except the window is not activated.
        /// </summary>
        SHOWNA = 8,
        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
        /// </summary>
        RESTORE = 9,
        /// <summary>
        /// Sets the show state based on the  value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
        /// </summary>
        SHOWDEFAULT = 10,
        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        FORCEMINIMIZE = 11,
    }
}
