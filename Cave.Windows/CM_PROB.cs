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
    /// The following table lists the errors reported by Device Manager on Windows 2000 and later versions of Windows. These error codes are defined in Cfg.h.
    /// BitSize depends on architecture
    /// </summary>
    public enum CM_PROB
    {
        /// <summary>
        /// There is a device on the system for which there is no ConfigFlags registry entry. This means no driver is installed. Typically this means an INF file could not be found.
        /// </summary>
        NOT_CONFIGURED = 1,

        /// <summary>
        /// Service load failed
        /// </summary>
        DEVLOADER_FAILED = 2,

        /// <summary>
        /// Running out of memory − the system is probably running low on system memory.
        /// </summary>
        OUT_OF_MEMORY = 3,

        /// <summary>
        /// Entry is of wrong type
        /// </summary>
        ENTRY_IS_WRONG_TYPE = 4,

        /// <summary>
        /// Lacked arbitrator
        /// </summary>
        LACKED_ARBITRATOR = 5,

        /// <summary>
        /// Boot config conflict
        /// </summary>
        BOOT_CONFIG_CONFLICT = 6,

        /// <summary>
        /// Failed filter 
        /// </summary>
        FAILED_FILTER = 7,

        /// <summary>
        /// Devloader not found
        /// </summary>
        DEVLOADER_NOT_FOUND = 8,

        /// <summary>
        /// Invalid device IDs have been detected.
        /// </summary>
        INVALID_DATA = 9,

        /// <summary>
        /// The device failed to start.
        /// </summary>
        FAILED_START = 10,

        /// <summary>
        /// Liar
        /// </summary>
        LIAR = 11,

        /// <summary>
        /// Two devices have been assigned the same I/O ports, the same interrupt, or the same DMA channel (either by the BIOS, the operating system, or a combination of the two).
        /// </summary>
        NORMAL_CONFLICT = 12,

        /// <summary>
        /// Not verified
        /// </summary>
        NOT_VERIFIED = 13,

        /// <summary>
        /// The system must be restarted.
        /// </summary>
        NEED_RESTART = 14,

        /// <summary>
        /// Reenumeration
        /// </summary>
        REENUMERATION = 15,

        /// <summary>
        /// The device is only partially configured.
        /// </summary>
        PARTIAL_LOG_CONF = 16,

        /// <summary>
        /// Unknown resource
        /// </summary>
        UNKNOWN_RESOURCE = 17,

        /// <summary>
        /// Drivers must be reinstalled.
        /// </summary>
        REINSTALL = 18,

        /// <summary>
        /// A registry problem was detected.
        /// </summary>
        REGISTRY = 19,

        /// <summary>
        /// VXDLDR
        /// </summary>
        VXDLDR = 20,

        /// <summary>
        /// The system will remove the device.
        /// </summary>
        WILL_BE_REMOVED = 21,

        /// <summary>
        /// The device is disabled.
        /// </summary>
        DISABLED = 22,

        /// <summary>
        /// Deavloader not ready
        /// </summary>
        DEVLOADER_NOT_READY = 23,

        /// <summary>
        /// The device does not seem to be present.
        /// </summary>
        DEVICE_NOT_THERE = 24,

        /// <summary>
        /// Moved
        /// </summary>
        MOVED = 25,

        /// <summary>
        /// Too early
        /// </summary>
        TOO_EARLY = 26,

        /// <summary>
        /// Not valid log conf
        /// </summary>
        NO_VALID_LOG_CONF = 27,

        /// <summary>
        /// The device's drivers are not installed.
        /// </summary>
        FAILED_INSTALL = 28,

        /// <summary>
        /// The device is disabled.
        /// </summary>
        HARDWARE_DISABLED = 29,

        /// <summary>
        /// Cant chare irq
        /// </summary>
        CANT_SHARE_IRQ = 30,

        /// <summary>
        /// A driver's attempt to add a device failed.
        /// </summary>
        FAILED_ADD = 31,

        /// <summary>
        /// The driver has been disabled.
        /// </summary>
        DISABLED_SERVICE = 32,

        /// <summary>
        /// Resource translation failed for the device.
        /// </summary>
        TRANSLATION_FAILED = 33,

        /// <summary>
        /// The device requires a forced configuration.
        /// </summary>
        NO_SOFTCONFIG = 34,

        /// <summary>
        /// The MPS table is bad and has to be updated.
        /// </summary>
        BIOS_TABLE = 35,

        /// <summary>
        /// The IRQ translation failed for the device.
        /// </summary>
        IRQ_TRANSLATION_FAILED = 36,

        /// <summary>
        /// The driver returned failure from its DriverEntry routine.
        /// </summary>
        FAILED_DRIVER_ENTRY = 37,

        /// <summary>
        /// The driver could not be loaded because a previous instance is still loaded.
        /// </summary>
        DRIVER_FAILED_PRIOR_UNLOAD = 38,

        /// <summary>
        /// The driver could not be loaded.
        /// </summary>
        DRIVER_FAILED_LOAD = 39,

        /// <summary>
        /// Information in the registry's service key for the driver is invalid.
        /// </summary>
        DRIVER_SERVICE_KEY_INVALID = 40,

        /// <summary>
        /// A driver was loaded but Windows cannot find the device.
        /// </summary>
        LEGACY_SERVICE_NO_DEVICES = 41,

        /// <summary>
        /// A duplicate device was detected.
        /// </summary>
        DUPLICATE_DEVICE = 42,

        /// <summary>
        /// A driver has reported a device failure.
        /// </summary>
        FAILED_POST_START = 43,

        /// <summary>
        /// The device has been stopped.
        /// </summary>
        HALTED = 44,

        /// <summary>
        /// The device is not present.
        /// </summary>
        PHANTOM = 45,

        /// <summary>
        /// The device is not available because the system is shutting down.
        /// </summary>
        SYSTEM_SHUTDOWN = 46,

        /// <summary>
        /// The device has been prepared for ejection.
        /// </summary>
        HELD_FOR_EJECT = 47,

        /// <summary>
        /// The system will not load the driver because it is listed in the Windows Driver Protection database supplied by Windows Update.
        /// </summary>
        DRIVER_BLOCKED = 48,

        /// <summary>
        /// The registry is too large.
        /// </summary>
        REGISTRY_TOO_LARGE = 49,

        /// <summary>
        /// Device properties cannot be set.
        /// </summary>
        SETPROPERTIES_FAILED = 50,

        /// <summary>
        /// The device did not start because it has a dependency on another device that has not started.
        /// </summary>
        WAITING_ON_DEPENDENCY = 51,

        /// <summary>
        /// The device did not start on a 64-bit version of Windows because it has a driver that is not digitally signed. For more information about how to sign drivers, see Driver Signing.
        /// </summary>
        UNSIGNED_DRIVER = 52,
    }
}
