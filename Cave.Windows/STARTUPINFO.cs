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
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct STARTUPINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public int cb;

        /// <summary>
        /// Reserved; must be NULL.
        /// </summary>
        public string lpReserved;
        
        /// <summary>
        /// The name of the desktop, or the name of both the desktop and window station for this process. A backslash in the string indicates that the string includes both the desktop and window station names. For more information, see Thread Connection to a Desktop.
        /// </summary>
        public string lpDesktop;

        /// <summary>
        /// For console processes, this is the title displayed in the title bar if a new console window is created. If NULL, the name of the executable file is used as the window title instead. This parameter must be NULL for GUI or console processes that do not create a new console window.
        /// </summary>
        public string lpTitle;

        /// <summary>
        /// If dwFlags specifies STARTF_USEPOSITION, this member is the x offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// </summary>
        public uint dwX;

        /// <summary>
        /// If dwFlags specifies STARTF_USEPOSITION, this member is the y offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// </summary>
        public uint dwY;

        /// <summary>
        /// If dwFlags specifies STARTF_USESIZE, this member is the width of the window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// </summary>
        public uint dwXSize;

        /// <summary>
        /// If dwFlags specifies STARTF_USESIZE, this member is the height of the window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// </summary>
        public uint dwYSize;

        /// <summary>
        /// If dwFlags specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
        /// </summary>
        public uint dwXCountChars;

        /// <summary>
        /// If dwFlags specifies STARTF_USECOUNTCHARS, if a new console window is created in a console process, this member specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
        /// </summary>
        public uint dwYCountChars;

        /// <summary>
        /// If dwFlags specifies STARTF_USEFILLATTRIBUTE, this member is the initial text and background colors if a new console window is created in a console application. Otherwise, this member is ignored.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public CONSOLECOLOR dwFillAttribute;

        /// <summary>
        /// A bitfield that determines whether certain STARTUPINFO members are used when the process creates a window. This member can be one or more of the following values.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public STARTF dwFlags;

        /// <summary>
        /// If dwFlags specifies STARTF_USESHOWWINDOW, this member can be any of the values that can be specified in the nCmdShow parameter for the ShowWindow function, except for SW_SHOWDEFAULT. Otherwise, this member is ignored.
        /// </summary>
        public short wShowWindow;

        /// <summary>
        /// Reserved for use by the C Run-time; must be zero.
        /// </summary>
        public short cbReserved2;

        /// <summary>
        /// Reserved for use by the C Run-time; must be NULL.
        /// </summary>
        public IntPtr lpReserved2;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard input handle for the process. If STARTF_USESTDHANDLES is not specified, the default for standard input is the keyboard buffer.
        /// </summary>
        public IntPtr hStdInput;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard output handle for the process. Otherwise, this member is ignored and the default for standard output is the console window's buffer.
        /// </summary>
        public IntPtr hStdOutput;

        /// <summary>
        /// If dwFlags specifies STARTF_USESTDHANDLES, this member is the standard error handle for the process. Otherwise, this member is ignored and the default for standard error is the console window's buffer.
        /// </summary>
        public IntPtr hStdError;
    }

    
}
