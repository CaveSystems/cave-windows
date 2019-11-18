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
    /// Provides DIF codes used at device installation requests, class installers and co-installers.
    /// </summary>
    public enum DIF : uint
    {
        /// <summary>
        /// A DIF_SELECTDEVICE request allows an installer to participate in selecting the driver for a device.
        /// </summary>
        SELECTDEVICE = 1,

        /// <summary>
        /// A DIF_INSTALLDEVICE request allows an installer to perform tasks before and/or after the device is installed.
        /// </summary>
        INSTALLDEVICE = 2,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request.
        /// </summary>
        ASSIGNRESOURCES = 3,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows.
        /// </summary>
        PROPERTIES = 4,

        /// <summary>
        /// A DIF_REMOVE request notifies an installer that Windows is about to remove a device and gives the installer an opportunity to prepare for the removal.
        /// </summary>
        REMOVE = 5,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request unless the vendor provides non-PnP devices that must be detected by the installer.
        /// </summary>
        FIRSTTIMESETUP = 6,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request. Send comments about this topic to Microsoft
        /// </summary>
        FOUNDDEVICE = 7,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows. Send comments about this topic to Microsoft
        /// </summary>
        SELECTCLASSDRIVERS = 8,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows. Send comments about this topic to Microsoft
        /// </summary>
        VALIDATECLASSDRIVERS = 9,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request. Send comments about this topic to Microsoft
        /// </summary>
        INSTALLCLASSDRIVERS = 10,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request. Send comments about this topic to Microsoft
        /// </summary>
        CALCDISKSPACE = 11,

        /// <summary>
        /// A DIF_DESTROYPRIVATEDATA request directs a class installer to free any memory or resources it allocated and stored in the ClassInstallReserved field of the SP_DEVINSTALL_PARAMS structure.
        /// </summary>
        DESTROYPRIVATEDATA = 12,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows.
        /// </summary>
        VALIDATEDRIVER = 13,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows.
        /// </summary>
        MOVEDEVICE = 14,

        /// <summary>
        /// A DIF_DETECT request directs an installer to detect non-PnP devices of a particular class and add the devices to the device information set. This request is used for non-PnP devices.
        /// </summary>
        DETECT = 15,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows.
        /// For PnP devices, Windows uses the DIF_NEWDEVICEWIZARD_XXX requests instead, such as DIF_NEWDEVICEWIZARD_FINISHINSTALL.
        /// </summary>
        INSTALLWIZARD = 16,

        /// <summary>
        /// This DIF code is obsolete and no longer supported in Microsoft Windows 2000 and later versions of Windows.
        /// Windows uses the DIF_NEWDEVICEWIZARD_XXX requests instead, such as DIF_NEWDEVICEWIZARD_FINISHINSTALL.
        /// </summary>
        DESTROYWIZARDDATA = 17,

        /// <summary>
        /// A DIF_PROPERTYCHANGE request notifies the installer that the device's properties are changing. The device is being enabled, disabled, started, stopped, or some item on a property page has changed. This DIF request gives the installer an opportunity to participate in the change.
        /// </summary>
        PROPERTYCHANGE = 18,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request.
        /// </summary>
        ENABLECLASS = 19,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request.
        /// </summary>
        DETECTVERIFY = 20,

        /// <summary>
        /// A DIF_INSTALLDEVICEFILES request allows an installer to participate in copying the files to support a device or to make a list of the files for a device. The device files include files for the selected driver, any device interfaces, and any co-installers.
        /// </summary>
        INSTALLDEVICEFILES = 21,

        /// <summary>
        /// A DIF_UNREMOVE request notifies the installer that Windows is about to reinstate a device in a given hardware profile and gives the installer an opportunity to participate in the operation. Windows only sends this request for non-PnP devices.
        /// </summary>
        UNREMOVE = 22,

        /// <summary>
        /// A DIF_SELECTBESTCOMPATDRV request allows an installer to select the best driver from the device information element's compatible driver list.
        /// </summary>
        SELECTBESTCOMPATDRV = 23,

        /// <summary>
        /// A DIF_ALLOW_INSTALL request asks the installers for a device whether Windows can proceed to install the device.
        /// </summary>
        ALLOW_INSTALL = 24,

        /// <summary>
        /// The DIF_REGISTERDEVICE request allows an installer to participate in registering a newly created device instance with the PnP manager. Windows sends this DIF request for non-PnP devices.
        /// </summary>
        REGISTERDEVICE = 25,

        /// <summary>
        /// A DIF_NEWDEVICEWIZARD_PRESELECT request allows an installer to supply wizard pages that Windows displays to the user before it displays the select-driver page. This request is only used during manual installation of non-PnP devices.
        /// </summary>
        NEWDEVICEWIZARD_PRESELECT = 26,

        /// <summary>
        /// A DIF_NEWDEVICEWIZARD_SELECT request allows an installer to supply custom wizard page(s) that replace the standard select-driver page. This request is only used during manual installation of non-PnP devices.
        /// </summary>
        NEWDEVICEWIZARD_SELECT = 27,

        /// <summary>
        /// A DIF_NEWDEVICEWIZARD_PREANALYZE request allows an installer to supply wizard pages that Windows displays to the user before it displays the analyze page. This request is only used during manual installation of non-PnP devices.
        /// </summary>
        NEWDEVICEWIZARD_PREANALYZE = 28,

        /// <summary>
        /// A DIF_NEWDEVICEWIZARD_POSTANALYZE request allows an installer to supply wizard pages that Windows displays to the user after the device node (devnode) is registered but before Windows installs the drivers for the device. This request is only used during manual installation of non-PnP devices.
        /// </summary>
        NEWDEVICEWIZARD_POSTANALYZE = 29,

        /// <summary>
        /// A DIF_NEWDEVICEWIZARD_FINISHINSTALL request allows an installer to supply finish-install wizard pages that Windows displays to the user after a device is installed but before Windows displays the standard finish page. Windows sends this request when it installs Plug and Play (PnP) devices and when an administrator uses the Add Hardware Wizard to install non-PnP devices.
        /// </summary>
        NEWDEVICEWIZARD_FINISHINSTALL = 30,

        /// <summary>
        /// A DIF_INSTALLINTERFACES request allows an installer to participate in the registration of the device interfaces for a device.
        /// </summary>
        INSTALLINTERFACES = 32,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request.
        /// </summary>
        DETECTCANCEL = 33,

        /// <summary>
        /// A DIF_REGISTER_COINSTALLERS request allows an installer to participate in the registration of device co-installers.
        /// </summary>
        REGISTER_COINSTALLERS = 34,

        /// <summary>
        /// A DIF_ADDPROPERTYPAGE_ADVANCED request allows an installer to supply one or more custom property pages for a device.
        /// </summary>
        ADDPROPERTYPAGE_ADVANCED = 35,

        /// <summary>
        /// This DIF code is reserved for system use. Vendor-supplied installers must not handle this request.
        /// </summary>
        ADDPROPERTYPAGE_BASIC = 36,

        /// <summary>
        /// The DIF_TROUBLESHOOTER request allows an installer to start a troubleshooter for a device or to return CHM and HTM troubleshooter files for Windows to start.
        /// </summary>
        TROUBLESHOOTER = 38,

        /// <summary>
        /// A DIF_POWERMESSAGEWAKE request allows an installer to supply custom text that Windows displays on the power management properties page of the device properties.
        /// </summary>
        POWERMESSAGEWAKE = 39,
    }
}
