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
    /// Provides Configuration Manager Error Codes
    /// </summary>
    public enum CM_ERROR : uint
    {
        /// <summary>
        /// Device is working properly.
        /// </summary>
        NoError = 0,

        /// <summary>
        /// Device is not configured correctly.
        /// </summary>
        ConfigurationError = 1,

        /// <summary>
        /// Windows cannot load the driver for this device.
        /// </summary>
        NoDriver = 2,

        /// <summary>
        /// Driver for this device might be corrupted, or the system may be low on memory or other resources.
        /// </summary>
        DriverCorruptOrLowResources = 3,

        /// <summary>
        /// Device is not working properly. One of its drivers or the registry might be corrupted.
        /// </summary>
        DriverError =4,

        /// <summary>
        /// Driver for the device requires a resource that Windows cannot manage.
        /// </summary>
        DriverResourceUnavailable=5,

        /// <summary>
        /// Boot configuration for the device conflicts with other devices.
        /// </summary>
        BootConflict = 6,

        /// <summary>
        /// Cannot filter.
        /// </summary>
        FilterError = 7,

        /// <summary>
        /// Driver loader for the device is missing.
        /// </summary>
        MissingDriverLoader = 8,

        /// <summary>
        /// Device is not working properly. The controlling firmware is incorrectly reporting the resources for the device.
        /// </summary>
        NotWorking = 9,

        /// <summary>
        /// Device cannot start.
        /// </summary>
        CannotStart = 10,

        /// <summary>
        /// Device failed.
        /// </summary>
        Failed = 11,

        /// <summary>
        /// Device cannot find enough free resources to use.
        /// </summary>
        NotEnoughResources = 12,

        /// <summary>
        /// Windows cannot verify the device resources.
        /// </summary>
        ResourceVerificationError = 13,

        /// <summary>
        /// Device cannot work properly until the computer is restarted.
        /// </summary>
        RestartRequired = 14,

        /// <summary>
        /// Device is not working properly due to a possible re-enumeration problem.
        /// </summary>
        ReEnumerationProblem = 15,

        /// <summary>
        /// Windows cannot identify all of the resources that the device uses.
        /// </summary>
        ResourceIdentificationError =16,

        /// <summary>
        /// Device is requesting an unknown resource type.
        /// </summary>
        UnknownResourceRequest = 17,

        /// <summary>
        /// Device drivers must be reinstalled.
        /// </summary>
        DriverReinstallationRequired = 18,

        /// <summary>
        /// Failure using the VxD loader.
        /// </summary>
        VxDLoaderError = 19,

        /// <summary>
        /// Registry might be corrupted.
        /// </summary>
        RegistryCorrupted = 20,

        /// <summary>
        /// System failure. If changing the device driver is ineffective, see the hardware documentation. Windows is removing the device.
        /// </summary>
        SystemFailureDeviceRemoved = 21,

        /// <summary>
        /// Device is disabled.
        /// </summary>
        DeviceDisabled = 22,

        /// <summary>
        /// System failure. If changing the device driver is ineffective, see the hardware documentation.
        /// </summary>
        SystemFailure = 23,

        /// <summary>
        /// Device is not present, not working properly, or does not have all of its drivers installed.
        /// </summary>
        DeviceNotPresentOrDriverMissing = 24,

        /// <summary>
        /// Windows is still setting up the device.
        /// </summary>
        SettingUp1 = 25,

        /// <summary>
        /// Windows is still setting up the device.
        /// </summary>
        SettingUp2 = 26,

        /// <summary>
        /// Device does not have valid log configuration.
        /// </summary>
        InvalidLog=27,

        /// <summary>
        /// Device drivers are not installed.
        /// </summary>
        NoDriverFound = 28,

        /// <summary>
        /// Device is disabled. The device firmware did not provide the required resources.
        /// </summary>
        DeviceDisabledResourceError = 29,

        /// <summary>
        /// Device is using an IRQ resource that another device is using.
        /// </summary>
        IRQConflict = 30,

        /// <summary>
        /// Device is not working properly. Windows cannot load the required device drivers.
        /// </summary>
        CannotLoadDriver = 31,
    }
}
