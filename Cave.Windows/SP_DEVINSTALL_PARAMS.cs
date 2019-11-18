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
    /// An SP_DEVINSTALL_PARAMS structure contains device installation parameters associated with a particular device information element or associated globally with a device information set.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_DEVINSTALL_PARAMS
    {
        /// <summary>
        /// The size, in bytes, of the SP_DEVINSTALL_PARAMS structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// Flags that control installation and user interface operations. Some flags can be set before sending the device installation request while other flags are set automatically during the processing of some requests. Flags can be a combination of the following values.
        /// </summary>
        //TODO DI_* FLAGS ENUM http://msdn.microsoft.com/en-us/library/windows/hardware/ff552346%28v=vs.85%29.aspx
        public uint Flags;

        /// <summary>
        /// Additional flags that provide control over installation and user interface operations. Some flags can be set before calling the device installer functions while other flags are set automatically during the processing of some functions.
        /// </summary>
        //TODO DI_FLAGSEX_* FLAGS ENUM
        public uint FlagsEx;

        /// <summary>
        /// Window handle that will own the user interface dialogs related to this device.
        /// </summary>
        public IntPtr hwndParent;

        /// <summary>
        /// Callback used to handle events during file copying. An installer can use a callback, for example, to perform special processing when committing a file queue.
        /// </summary>
        public IntPtr InstallMsgHandler;

        /// <summary>
        /// Private data that is used by the InstallMsgHandler callback.
        /// </summary>
        public IntPtr InstallMsgHandlerContext;

        /// <summary>
        /// A handle to a caller-supplied file queue where file operations should be queued but not committed.
        /// </summary>
        public IntPtr FileQueue;

        /// <summary>
        /// A pointer for class-installer data. Co-installers must not use this field.
        /// </summary>
        public IntPtr ClassInstallReserved;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public uint Reserved;

        /// <summary>
        /// This path is used by the SetupDiBuildDriverInfoList function.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = KERNEL32.MAX_PATH)]
        public string DriverPath;
    }
}
