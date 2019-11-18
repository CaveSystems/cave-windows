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
    /// Provides state change actions
    /// </summary>
    public enum DICS : uint
    {
        /// <summary>
        /// Loads the drivers for the device and starts the device, if possible. If the function cannot start the device, it sets the DI_NEEDREBOOT flag for the device which indicates to the initiator of the property change request that they must prompt the user to restart the computer.
        /// </summary>
        ENABLE = 1,

        /// <summary>
        /// Disables the device. If the device can be disabled but this function cannot disable the device dynamically, this function marks the device to be disabled the next time that the computer restarts.
        /// </summary>
        DISABLE = 2,

        /// <summary>
        /// Removes and reconfigures the device so that the new properties can take effect. This flag typically indicates that a user has changed a property on a device manager property page for the device. The PnP manager directs the drivers for the device to remove their device objects and then the PnP manager reconfigures and restarts the device.
        /// </summary>
        PROPCHANGE = 3,

        /// <summary>
        /// The device is being started (if the request is for the currently active hardware profile).
        /// </summary>
        START = 4,

        /// <summary>
        /// The device is being stopped. The driver stack will be unloaded and the CSCONFIGFLAG_DO_NOT_START flag will be set for the device.
        /// </summary>
        STOP = 5
    }
}
