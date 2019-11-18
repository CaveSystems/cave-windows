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
using System.Collections.Generic;
using System.Threading;

namespace Cave.Windows
{
    /// <summary>
    /// provides a load percentage gauge for windows
    /// </summary>
    
    public class LOAD : IDisposable
    {
        /// <summary>
        /// class for handling load values
        /// </summary>
        public class VALUES
        {
            /// <summary>
            /// creates a new load item
            /// </summary>
            /// <param name="lastMinute"></param>
            /// <param name="lastFiveMinutes"></param>
            /// <param name="lastFifteenMinutes"></param>
            internal VALUES(double lastMinute, double lastFiveMinutes, double lastFifteenMinutes)
            {
                LastMinute = lastMinute;
                LastFiveMinutes = lastFiveMinutes;
                LastFifteenMinutes = lastFifteenMinutes;
            }

            /// <summary>
            /// obtains the load of the last minute
            /// </summary>
            public double LastMinute;

            /// <summary>
            /// obtains the load of the last five minutes
            /// </summary>
            public double LastFiveMinutes;

            /// <summary>
            /// obtains the load of the last fifteen minutes
            /// </summary>
            public double LastFifteenMinutes;
        }

        Timer m_Timer;
        SYSTEMTIMES m_LastTimes = new SYSTEMTIMES();
        LinkedList<double> m_Loads = new LinkedList<double>();

        void m_Update(object state)
        {
            lock (this)
            {
                //get kernel times
                SYSTEMTIMES times = KERNEL32.GetSystemTimes();
                //calculate the timeslice we work on
                double l_SliceTime = ((times.Kernel + times.User) - (m_LastTimes.Kernel + m_LastTimes.User)).TotalMilliseconds;
                if (l_SliceTime < 1.0) return;
                //calculate the load during this timeslice
                double l_SliceLoad = 1 - (times.Idle - m_LastTimes.Idle).TotalMilliseconds / l_SliceTime;
                //push the slice load to the array
                m_Loads.AddLast(l_SliceLoad);
                //pop all items older then 900 seconds
                while (m_Loads.Count > 900) m_Loads.RemoveFirst();
                //save last times
                m_LastTimes = times;
            }
        }

        /// <summary>
        /// retrieves the loads of the last 15 minutes (one value per second)
        /// </summary>
        public double[] Loads
        {
            get
            {
                lock (this)
                {
                    double[] result = new double[900];
                    m_Loads.CopyTo(result, 0);
                    return result;
                }
            }
        }

        /// <summary>
        /// retrieves the csu load percentages
        /// </summary>
        public VALUES Get()
        {
            double[] l_Loads = Loads;
            double l_Load = 0;
            int index = 900;
            int i = 0;
            //calc last minute:
            for (i = 0; i < 60; i++)
            {
                l_Load += l_Loads[--index];
            }
            double l_LastMinute = l_Load / 60;
            //calc last 5 minutes:
            for (; i < 300; i++)
            {
                l_Load += l_Loads[--index];
            }
            double l_LastFiveMinutes = l_Load / 300;
            //calc last 15 minutes:
            for (; i < 900; i++)
            {
                l_Load += l_Loads[--index];
            }
            double l_LastFifteenMinutes = l_Load / i;
            return new VALUES(l_LastMinute, l_LastFiveMinutes, l_LastFifteenMinutes);
        }

        /// <summary>
        /// creates a new load percentage object
        /// </summary>
        public LOAD()
        {
            for (int i = 0; i < 900; i++)
            {
                m_Loads.AddLast(0.0);
            }
            m_LastTimes = KERNEL32.GetSystemTimes();
            m_Timer = new Timer(new TimerCallback(m_Update), null, 1000, 1000);
        }

        /// <summary>
        /// disposes the object
        /// </summary>
        public void Dispose()
        {
            if (m_Timer != null)
            {
                m_Timer.Dispose();
                m_Timer = null;
            }
        }
    }
}
