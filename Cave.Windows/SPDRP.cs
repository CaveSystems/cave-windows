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
    /// Device registry property codes
    /// </summary>
    public enum SPDRP
    {
        /// <summary>
        /// The function retrieves a REG_SZ string that contains the description of a device.
        /// </summary>
        DEVICEDESC = 0,

        /// <summary>
        /// The function retrieves a REG_MULTI_SZ string that contains the list of hardware IDs for a device. For information about hardware IDs, see Device Identification Strings.
        /// </summary>
        HARDWAREID = 1,

        /// <summary>
        /// The function retrieves a REG_MULTI_SZ string that contains the list of compatible IDs for a device. For information about compatible IDs, see Device Identification Strings.
        /// </summary>
        COMPATIBLEIDS = 2,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the service name for a device.
        /// </summary>
        SERVICE = 4,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the device setup class of a device.
        /// </summary>
        CLASS = 7,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the GUID that represents the device setup class of a device.
        /// </summary>
        CLASSGUID = 8,

        /// <summary>
        /// The function retrieves a string that identifies the device's software key (sometimes called the driver key). For more information about driver keys, see Registry Trees and Keys for Devices and Drivers.
        /// </summary>
        DRIVER = 9,

        /// <summary>
        /// The function retrieves a bitwise OR of a device's configuration flags in a DWORD value. The configuration flags are represented by the CONFIGFLAG_Xxx bitmasks that are defined in Regstr.h.
        /// </summary>
        CONFIGFLAGS = 0xA,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the name of the device manufacturer.
        /// </summary>
        MFG = 0xB,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the friendly name of a device.
        /// </summary>
        FRIENDLYNAME = 0xC,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the hardware location of a device.
        /// </summary>
        LOCATION_INFORMATION = 0xD,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the name that is associated with the device's PDO. For more information, see IoCreateDevice.
        /// </summary>
        PHYSICAL_DEVICE_OBJECT_NAME = 0xE,

        /// <summary>
        /// The function retrieves a bitwise OR of the following CM_DEVCAP_Xxx flags in a DWORD. The device capabilities that are represented by these flags correspond to the device capabilities that are represented by the members of the DEVICE_CAPABILITIES structure. The CM_DEVCAP_Xxx constants are defined in Cfgmgr32.h.
        /// </summary>
        CAPABILITIES = 0xF,

        /// <summary>
        /// The function retrieves a DWORD value set to the value of the UINumber member of the device's DEVICE_CAPABILITIES structure.
        /// </summary>
        UI_NUMBER = 0x10,

        /// <summary>
        /// The function retrieves a REG_MULTI_SZ string that contains the names of a device's upper filter drivers.
        /// </summary>
        UPPERFILTERS = 0x11,

        /// <summary>
        /// The function retrieves a REG_MULTI_SZ string that contains the names of a device's lower-filter drivers.
        /// </summary>
        LOWERFILTERS = 0x12,

        /// <summary>
        /// The function retrieves the GUID for the device's bus type.
        /// </summary>
        BUSTYPEGUID = 0x13,

        /// <summary>
        /// The function retrieves the device's legacy bus type as an INTERFACE_TYPE value (defined in Wdm.h and Ntddk.h).
        /// </summary>
        LEGACYBUSTYPE = 0x14,

        /// <summary>
        /// The function retrieves the device's bus number.
        /// </summary>
        BUSNUMBER = 0x15,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the name of the device's enumerator.
        /// </summary>
        ENUMERATOR_NAME = 0x16,

        /// <summary>
        /// The function retrieves a SECURITY_DESCRIPTOR structure for a device.
        /// </summary>
        SECURITY = 0x17,

        /// <summary>
        /// The function retrieves a REG_SZ string that contains the device's security descriptor. The format of security descriptor strings is described in Microsoft Windows SDK documentation.
        /// </summary>
        SECURITY_SDS = 0x18,

        /// <summary>
        /// The function retrieves a DWORD value that represents the device's type. For more information, see Specifying Device Types.
        /// </summary>
        DEVTYPE = 0x19,

        /// <summary>
        /// The function retrieves a DWORD value that indicates whether a user can obtain exclusive use of the device. The returned value is one if exclusive use is allowed, or zero otherwise. For more information, see IoCreateDevice.
        /// </summary>
        EXCLUSIVE = 0x1A,

        /// <summary>
        /// The function retrieves a bitwise OR of a device's characteristics flags in a DWORD. For a description of these flags, which are defined in Wdm.h and Ntddk.h, see the DeviceCharacteristics parameter of the IoCreateDevice function.
        /// </summary>
        CHARACTERISTICS = 0x1B,

        /// <summary>
        /// The function retrieves the device's address.
        /// </summary>
        ADDRESS = 0x1C,

        /// <summary>
        /// The function retrieves a format string (REG_SZ) used to display the UINumber value.
        /// </summary>
        UI_NUMBER_DESC_FORMAT = 0x1D,

        /// <summary>
        /// (Windows XP and later) The function retrieves a CM_POWER_DATA structure that contains the device's power management information.
        /// </summary>
        DEVICE_POWER_DATA = 0x1E,

        /// <summary>
        /// (Windows XP and later) The function retrieves the device's current removal policy as a DWORD that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </summary>
        REMOVAL_POLICY = 0x1F,

        /// <summary>
        /// (Windows XP and later) The function retrieves the device's hardware- specified  default removal policy as a DWORD that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </summary>
        REMOVAL_POLICY_HW_DEFAULT = 0x20,

        /// <summary>
        /// (Windows XP and later) The function retrieves the device's override removal policy (if it exists) from the registry, as a DWORD that contains one of the CM_REMOVAL_POLICY_Xxx values that are defined in Cfgmgr32.h.
        /// </summary>
        REMOVAL_POLICY_OVERRIDE = 0x21,

        /// <summary>
        /// (Windows XP and later) The function retrieves a DWORD value that indicates the installation state of a device. The installation state is represented by one of the CM_INSTALL_STATE_Xxx values that are defined in Cfgmgr32.h. The CM_INSTALL_STATE_Xxx values correspond to the DEVICE_INSTALL_STATE enumeration values.
        /// </summary>
        INSTALL_STATE = 0x22,

        /// <summary>
        /// (Windows Server 2003 and later) The function retrieves a REG_MULTI_SZ string that represents the location of the device in the device tree.
        /// </summary>
        LOCATION_PATHS = 0x23,

        /// <summary>
        /// Base ContainerID
        /// </summary>
        BASE_CONTAINERID = 0x24,
    }
}
