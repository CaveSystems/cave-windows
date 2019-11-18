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
    /// Device Node Status Flags
    /// </summary>
    [Flags]
    public enum DN : ulong //BitSize depends on architecture
    {
        /// <summary>
        /// Was enumerated by ROOT
        /// </summary>
        ROOT_ENUMERATED = 0x1,

        /// <summary>
        /// Has Register_Device_Driver
        /// </summary>
        DRIVER_LOADED = 0x2,

        /// <summary>
        /// Has Register_Enumerator
        /// </summary>
        ENUM_LOADED = 0x4,

        /// <summary>
        /// Is currently configured
        /// </summary>
        STARTED = 0x8,

        /// <summary>
        /// Manually installed
        /// </summary>
        MANUAL = 0x10,

        /// <summary>
        /// May need reenumeration
        /// </summary>
        NEED_TO_ENUM = 0x20,

        /// <summary>
        /// Has received a config (Win9x only)
        /// </summary>
        NOT_FIRST_TIME = 0x40,

        /// <summary>
        /// Enum generates hardware ID
        /// </summary>
        HARDWARE_ENUM = 0x80,

        /// <summary>
        /// Lied about can reconfig once (Win9x only)
        /// </summary>
        LIAR = 0x100,

        /// <summary>
        /// Not CM_Create_DevNode lately (Win9x only)
        /// </summary>
        HAS_MASK = 0x200,

        /// <summary>
        /// Need device installer
        /// </summary>
        HAS_PROBLEM = 0x400,

        /// <summary>
        /// Is filtered
        /// </summary>
        FILTERED = 0x800,

        /// <summary>
        /// Has been moved (Win9x only)
        /// </summary>
        MOVED = 0x1000,

        /// <summary>
        /// Can be rebalanced
        /// </summary>
        DISABLEABLE = 0x2000,

        /// <summary>
        /// Can be removed
        /// </summary>
        REMOVABLE = 0x4000,

        /// <summary>
        /// Has a private problem
        /// </summary>
        PRIVATE_PROBLEM = 0x8000,

        /// <summary>
        /// Multi function parent
        /// </summary>
        MF_PARENT = 0x10000,

        /// <summary>
        /// Multi function child
        /// </summary>
        MF_CHILD = 0x20000,

        /// <summary>
        /// DevInst is being removed
        /// </summary>
        WILL_BE_REMOVED = 0x40000,

        /// <summary>
        /// Has received a config enumerate
        /// </summary>
        NOT_FIRST_TIMEE = 0x80000,

        /// <summary>
        /// When child is stopped, free resources
        /// </summary>
        STOP_FREE_RES = 0x100000,

        /// <summary>
        /// Don't skip during rebalance
        /// </summary>
        REBAcANDIDATE = 0x200000,

        /// <summary>
        /// This devnode's log_confs do not have same resources
        /// </summary>
        BAD_PARTIAL = 0x400000,

        /// <summary>
        /// This devnode's is an NT enumerator
        /// </summary>
        NT_ENUMERATOR = 0x800000,

        /// <summary>
        /// This devnode's is an NT driver
        /// </summary>
        NT_DRIVER = 0x1000000,

        /// <summary>
        /// Devnode need lock resume processing
        /// </summary>
        NEEDS_LOCKING = 0x2000000,

        /// <summary>
        /// Devnode can be the wakeup device
        /// </summary>
        ARM_WAKEUP = 0x4000000,

        /// <summary>
        /// APM aware enumerator
        /// </summary>
        APM_ENUMERATOR = 0x8000000,

        /// <summary>
        /// APM aware driver
        /// </summary>
        APM_DRIVER = 0x10000000,

        /// <summary>
        /// Silent install
        /// </summary>
        SILENT_INSTALL = 0x20000000,

        /// <summary>
        /// No show in device manager
        /// </summary>
        NO_SHOW_IN_DM = 0x40000000,

        /// <summary>
        /// Had a problem during preassignment of boot log conf
        /// </summary>
        BOOT_LOG_PROB = 0x80000000
    }
}
