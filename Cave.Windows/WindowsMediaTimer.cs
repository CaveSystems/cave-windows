#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
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
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion Authors & Contributors

using System;
using System.Diagnostics;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to the WindowsMediaTimer
    /// </summary>
    public static class WindowsMediaTimer
    {
        /// <summary>Begins this instance.</summary>
        /// <returns></returns>
        public static bool Begin()
        {
            if (Platform.IsMicrosoft)
            {
                try
                {
                    WINMM.TimeBeginFastPeriod();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"WINMM.TimeBeginFastPeriod() {ex}");
                    return false;
                }
            }
            Debug.WriteLine("This is not a microsoft platform!");
            return false;
        }

        /// <summary>Ends the fast period.</summary>
        /// <returns></returns>
        public static bool End()
        {
            if (Platform.IsMicrosoft)
            {
                try
                {
                    WINMM.TimeEndFastPeriod();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"WINMM.TimeEndFastPeriod() {ex}");
                    return false;
                }
            }
            Debug.WriteLine("This is not a microsoft platform!");
            return false;
        }
    }
}
