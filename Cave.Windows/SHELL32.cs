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
using System.Text;

//do not warn for missing comments in this class
#pragma warning disable 1591

namespace Cave.Windows
{
    /// <summary>
    /// Provides an interface to the shell32.dll
    /// </summary>
    public class SHELL32
    {
        /// <summary>
        /// Provides available paths
        /// </summary>
        public enum PATH : int
        {
            DESKTOP = 0x0000,
            INTERNET = 0x0001,
            PROGRAMS = 0x0002,
            CONTROLS = 0x0003,
            PRINTERS = 0x0004,
            PERSONAL = 0x0005,
            FAVORITES = 0x0006,
            STARTUP = 0x0007,
            RECENT = 0x0008,
            SENDTO = 0x0009,
            BITBUCKET = 0x000a,
            STARTMENU = 0x000b,
            MYDOCUMENTS = PERSONAL,
            MYMUSIC = 0x000d,
            MYVIDEO = 0x000e,
            DESKTOPDIRECTORY = 0x0010,
            DRIVES = 0x0011,
            NETWORK = 0x0012,
            NETHOOD = 0x0013,
            FONTS = 0x0014,
            TEMPLATES = 0x0015,
            COMMON_STARTMENU = 0x0016,
            COMMON_PROGRAMS = 0x0017,
            COMMON_STARTUP = 0x0018,
            COMMON_DESKTOPDIRECTORY = 0x0019,
            APPDATA = 0x001a,
            PRINTHOOD = 0x001b,
            LOCAaPPDATA = 0x001c,
            ALTSTARTUP = 0x001d,
            COMMON_ALTSTARTUP = 0x001e,
            COMMON_FAVORITES = 0x001f,
            INTERNET_CACHE = 0x0020,
            COOKIES = 0x0021,
            HISTORY = 0x0022,
            COMMON_APPDATA = 0x0023,
            WINDOWS = 0x0024,
            SYSTEM = 0x0025,
            PROGRAM_FILES = 0x0026,
            MYPICTURES = 0x0027,
            PROFILE = 0x0028,
            SYSTEMX86 = 0x0029,
            PROGRAM_FILESX86 = 0x002a,
            PROGRAM_FILES_COMMON = 0x002b,
            PROGRAM_FILES_COMMONX86 = 0x002c,
            COMMON_TEMPLATES = 0x002d,
            COMMON_DOCUMENTS = 0x002e,
            COMMON_ADMINTOOLS = 0x002f,
            ADMINTOOLS = 0x0030,
            CONNECTIONS = 0x0031,
            COMMON_MUSIC = 0x0035,
            COMMON_PICTURES = 0x0036,
            COMMON_VIDEO = 0x0037,
            RESOURCES = 0x0038,
            RESOURCES_LOCALIZED = 0x0039,
            COMMON_OEM_LINKS = 0x003a,
            CDBURN_AREA = 0x003b,
            COMPUTERSNEARME = 0x003d,
        }

        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        /// <summary>
        /// Retrieves the path of a special folder
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetSpecialFolderPath(PATH path)
        {
            StringBuilder result = new StringBuilder(260);
            if (SHGetSpecialFolderPath(IntPtr.Zero, result, (int)path, false))
            {
                return result.ToString();
            }
            return null;
        }
    }
}

#pragma warning restore 1591
