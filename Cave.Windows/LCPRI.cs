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
    /// Logical configuration Priority values
    /// <para>These priority values are used in user-mode calls to CM_Add_Empty_Log_Conf. Drivers may also specify priority values for a given IO_RESOURCE_LIST structure by including a ConfigData member union as the first IO_RESOURCE_DESCRIPTOR in the IO_RESOURCE_LIST. In this case, the descriptor type would be CmResourceTypeConfigData.</para>
    /// </summary>
    public enum LCPRI
    {
        /// <summary>
        /// Coming from a forced config
        /// </summary>
        FORCECONFIG = 0x0,

        /// <summary>
        /// Coming from a boot config
        /// </summary>
        BOOTCONFIG = 0x1,

        /// <summary>
        /// Preferable (better performance)
        /// </summary>
        DESIRED = 0x2000,

        /// <summary>
        /// Workable (acceptable performance)
        /// </summary>
        NORMAL = 0x3000,

        /// <summary>
        /// Do not use / Mask
        /// </summary>
        LASTBESTCONFIG = 0x3FFF,

        /// <summary>
        /// Not desired, but will work
        /// </summary>
        SUBOPTIMAL = 0x5000,

        /// <summary>
        /// Do not use / Mask
        /// </summary>
        LASTSOFTCONFIG = 0x7FFF,

        /// <summary>
        /// Need to restart
        /// </summary>
        RESTART = 0x8000,

        /// <summary>
        /// Need to reboot
        /// </summary>
        REBOOT = 0x9000,

        /// <summary>
        /// Need to shutdown/power-off
        /// </summary>
        POWEROFF = 0xA000,

        /// <summary>
        /// Need to change a jumper
        /// </summary>
        HARDRECONFIG = 0xC000,

        /// <summary>
        /// Cannot be changed
        /// </summary>
        HARDWIRED = 0xE000,

        /// <summary>
        /// Impossible configuration
        /// </summary>
        IMPOSSIBLE = 0xF000,

        /// <summary>
        /// Disabled configuration
        /// </summary>
        DISABLED = 0xFFFF,
    }
}
