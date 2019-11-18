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
#endregion
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion Authors & Contributors

using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// C++ structure containing a calendar date and time broken down into its components.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct TM
    {
        /// <summary>
        /// seconds after the minute
        /// </summary>
        public int Seconds;

        /// <summary>
        /// minutes after the hour
        /// </summary>
        public int Minute;

        /// <summary>
        /// hours since midnight
        /// </summary>
        public int Hour;

        /// <summary>
        /// day of the month
        /// </summary>
        public int Day;

        /// <summary>
        /// months since January
        /// </summary>
        public int Month;

        /// <summary>
        /// years since 1900
        /// </summary>
        public int Year;

        /// <summary>
        /// days since Sunday
        /// </summary>
        public int WeekDay;

        /// <summary>
        /// days since January 1
        /// </summary>
        public int DayOfYear;

        /// <summary>
        /// Daylight Saving Time flag
        /// </summary>
        public int IsDayLightSaving;

        /// <summary>
        /// Obtains the date time of this TM object
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            return new DateTime(Year + 1900, Month, Day, Hour, Minute, Seconds, DateTimeKind.Unspecified);
        }

        /// <summary>
        /// Returns the date time as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToDateTime().ToString();
        }
    }
}
