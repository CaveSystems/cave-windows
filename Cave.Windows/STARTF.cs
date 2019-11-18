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
    /// Bitfield that determines whether certain STARTUPINFO members are used when the process creates a window. 
    /// </summary>
    [Flags]
    public enum STARTF
    {
        /// <summary>
        /// The wShowWindow member contains additional information.
        /// </summary>
        USESHOWWINDOW=0x00000001,

        /// <summary>
        /// The dwXSize and dwYSize members contain additional information.
        /// </summary>
        USESIZE=0x00000002,

        /// <summary>
        /// The dwX and dwY members contain additional information.
        /// </summary>
        USEPOSITION=0x00000004,

        /// <summary>
        /// The dwXCountChars and dwYCountChars members contain additional information.
        /// </summary>
        USECOUNTCHARS=0x00000008,

        /// <summary>
        /// The dwFillAttribute member contains additional information.
        /// </summary>
        USEFILLATTRIBUTE=0x00000010,

        /// <summary>
        /// Indicates that the process should be run in full-screen mode, rather than in windowed mode.
        /// </summary>
        RUNFULLSCREEN=0x00000020,

        /// <summary>
        /// Indicates that the cursor is in feedback mode for two seconds after CreateProcess is called. The Working in Background cursor is displayed (see the Pointers tab in the Mouse control panel utility).
        /// </summary>
        FORCEONFEEDBACK = 0x00000040,
        
        /// <summary>
        /// Indicates that the feedback cursor is forced off while the process is starting. The Normal Select cursor is displayed.
        /// </summary>
        FORCEOFFFEEDBACK=0x00000080,

        /// <summary>
        /// The hStdInput, hStdOutput, and hStdError members contain additional information.
        /// If this flag is specified when calling one of the process creation functions, the handles must be inheritable and the function's bInheritHandles parameter must be set to TRUE. For more information, see Handle Inheritance.
        /// </summary>
        USESTDHANDLES=0x00000100,

        /// <summary>
        /// The hStdInput member contains additional information.
        /// </summary>
        USEHOTKEY=0x00000200,

        /// <summary>
        /// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process. This is typically set by the shell when a .lnk file pointing to the launched application is invoked. Most applications will not need to set this value.
        /// </summary>
        TITLEISLINKNAME=0x00000800,

        /// <summary>
        /// The lpTitle member contains an AppUserModelID. This identifier controls how the taskbar and Start menu present the application, and enables it to be associated with the correct shortcuts and Jump Lists. Generally, applications will use the SetCurrentProcessExplicitAppUserModelID and GetCurrentProcessExplicitAppUserModelID functions instead of setting this flag. For more information, see Application User Model IDs.
        /// </summary>
        TITLEISAPPID=0x00001000,

        /// <summary>
        /// Indicates that any windows created by the process cannot be pinned on the taskbar.
        /// </summary>
        PREVENTPINNING = 0x00002000,

    }
}
