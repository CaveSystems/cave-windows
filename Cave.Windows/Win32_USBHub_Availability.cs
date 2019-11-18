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
    /// Availability and status of an usb device.
    /// </summary>
    public enum Win32_USBHub_Availability : ushort
    {
        /// <summary>
        /// Other
        /// </summary>
        Other = 1,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 2,

        /// <summary>
        /// RunningOrFullPower
        /// </summary>
        RunningOrFullPower = 3,

        /// <summary>
        /// Warning
        /// </summary>
        Warning = 4,

        /// <summary>
        /// InTest
        /// </summary>
        InTest = 5,

        /// <summary>
        /// NotApplicable
        /// </summary>
        NotApplicable = 6,

        /// <summary>
        /// PowerOff
        /// </summary>
        PowerOff = 7,

        /// <summary>
        /// Offline
        /// </summary>
        Offline = 8,

        /// <summary>
        /// OffDuty
        /// </summary>
        OffDuty = 9,

        /// <summary>
        /// Degraded
        /// </summary>
        Degraded = 10,

        /// <summary>
        /// NotInstalled
        /// </summary>
        NotInstalled = 11,

        /// <summary>
        /// InstallError
        /// </summary>
        InstallError = 12,

        /// <summary>
        /// PowerSaveOrUnknown
        /// </summary>
        PowerSaveOrUnknown = 13,

        /// <summary>
        /// PowerSaveLowPowerMode
        /// </summary>
        PowerSaveLowPowerMode = 14,

        /// <summary>
        /// PowerSaveStandby
        /// </summary>
        PowerSaveStandby = 15,

        /// <summary>
        /// PowerCycle
        /// </summary>
        PowerCycle = 16,

        /// <summary>
        /// PowerSaveWarning
        /// </summary>
        PowerSaveWarning = 17,

        /// <summary>
        /// Paused
        /// </summary>
        Paused = 18,

        /// <summary>
        /// NotReady
        /// </summary>
        NotReady = 19,

        /// <summary>
        /// NotConfigured
        /// </summary>
        NotConfigured = 20,

        /// <summary>
        /// QuiescedOrUnavailable
        /// </summary>
        QuiescedOrUnavailable = 21,
    }
}
