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

   Copyright (c) 2003-2014 Andreas Rohleder (andreas@rohleder.cc)
 */
#endregion

using Cave.Collections.Generic;
using System;
using System.IO;

namespace Cave.Windows
{
    /// <summary>
    /// provides easy access to s.m.a.r.t. data
    /// </summary>
    public class SMARTDATA
    {
        SMARTDATAENTRY[] m_Entries;

        /// <summary>
        /// obtains all entries
        /// </summary>
        public SMARTDATAENTRY[] Entries
        {
            get { return (SMARTDATAENTRY[])m_Entries.Clone(); }
        }

        /// <summary>
        /// creates a new s.m.a.r.t. data instance
        /// </summary>
        /// <param name="smartData"></param>
        public SMARTDATA(byte[] smartData)
        {
            m_Entries = new SMARTDATAENTRY[30];
            for (int i = 0; i < 30; i++)
            {
                m_Entries[i] = new SMARTDATAENTRY(smartData, i);
            }
        }

        /// <summary>
        /// creates a new s.m.a.r.t. data instance
        /// </summary>
        /// <param name="smartData"></param>
        public SMARTDATA(string smartData)
        {
            if (smartData == null) throw new ArgumentNullException("smartData");
            m_Entries = new SMARTDATAENTRY[30];
            byte[] data = new byte[512];
            int currentValue = 0;
            int currentStage = 0;
            int currentPosition = 0;
            foreach (char c in smartData.ToUpperInvariant())
            {
                int value = -1;
                if ((c >= '0') && (c <= '9'))
                {
                    value = (byte)(c - '0');
                }
                else if ((c >= 'A') && (c <= 'F'))
                {
                    value = (byte)(c - 'A') + 10;
                }
                if (value >= 0)
                {
                    currentValue = (currentValue << 4) + value;
                    if (++currentStage == 2)
                    {
                        data[currentPosition++] = (byte)currentValue;
                        currentValue = 0;
                        currentStage = 0;
                    }
                }
            }
            if (currentPosition != 512) throw new InvalidDataException();
            for (int i = 0; i < 30; i++)
            {
                m_Entries[i] = new SMARTDATAENTRY(data, i);
            }
        }

        /// <summary>
        /// finds a specific s.m.a.r.t. data entry in the specified smart data
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public SMARTDATAENTRY FindSmartDataEntry(int identifier)
        {
            //iterate through all Entries
            foreach (SMARTDATAENTRY entry in Entries)
            {
                if (entry.Identifier == identifier)
                {
                    return entry;
                }
            }
            return null;
        }

        /// <summary>
        /// tries to retrieve the hdd temperature
        /// </summary>
        /// <returns></returns>
        public int HddTemperature
        {
            get
            {
                SMARTDATAENTRY l_SmartDataEntry = FindSmartDataEntry(194);
                if (l_SmartDataEntry == null)
                {
                    l_SmartDataEntry = FindSmartDataEntry(190);
                }
                if (l_SmartDataEntry != null)
                {
                    return l_SmartDataEntry.Data[5];
                }
                return -1;
            }
        }
    }
}
