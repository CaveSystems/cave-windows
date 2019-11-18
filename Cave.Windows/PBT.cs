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
    ///
    /// </summary>
    public enum PBT : int
    {
        /// <summary>
        ///
        /// </summary>
        APMQUERYSUSPEND = 0x0000,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSTANDBY = 0x0001,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSUSPENDFAILED = 0x0002,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSTANDBYFAILED = 0x0003,

        /// <summary>
        ///
        /// </summary>
        APMSUSPEND = 0x0004,

        /// <summary>
        ///
        /// </summary>
        APMSTANDBY = 0x0005,

        /// <summary>
        ///
        /// </summary>
        APMRESUMECRITICAL = 0x0006,

        /// <summary>
        ///
        /// </summary>
        APMRESUMESUSPEND = 0x0007,

        /// <summary>
        ///
        /// </summary>
        APMRESUMESTANDBY = 0x0008,

        /// <summary>
        ///
        /// </summary>
        PBTF_APMRESUMEFROMFAILURE = 0x00000001,

        /// <summary>
        ///
        /// </summary>
        APMBATTERYLOW = 0x0009,

        /// <summary>
        ///
        /// </summary>
        APMPOWERSTATUSCHANGE = 0x000A,

        /// <summary>
        ///
        /// </summary>
        APMOEMEVENT = 0x000B,

        /// <summary>
        ///
        /// </summary>
        APMRESUMEAUTOMATIC = 0x0012,
    }
}
