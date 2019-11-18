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

#if !NETSTANDARD20

using Cave.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;

namespace Cave.Windows
{
    /// <summary>
    /// provides an interface to some system.management functions
    /// </summary>
    public static class WMI
    {
        /// <summary>
        /// retrieves the temperatures (in celsius) of the acpi temperature sensors (driver needed !)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetAcpiTemperatures()
        {
            var result = new Dictionary<string, int>();
            var searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            foreach (ManagementObject queryObj in searcher.Get())
            {
                if ((bool)queryObj["Active"])
                {
                    string name = (string)queryObj["InstanceName"];
                    uint kelvin = (uint)queryObj["CurrentTemperature"];
                    int celsius = (int)((kelvin - 2731) / 10);
                    result.Add(name, celsius);
                }
            }
            return result;
        }

        /// <summary>
        /// retrieves the temperatures (in celsius) of the acpi temperature sensors (driver needed !)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetChipsetTemperatures()
        {
            var result = new Dictionary<string, int>();
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_TemperatureProbe");
            foreach (ManagementObject l_QueryObj in searcher.Get())
            {
                if ((ushort)l_QueryObj["Availability"] <= 3)
                {
                    string name = (string)l_QueryObj["Caption"];
                    uint l_Kelvin = (uint)l_QueryObj["CurrentReading"];
                    int celsius = (int)((l_Kelvin - 2731) / 10);
                    result.Add(name, celsius);
                }
            }
            return result;
        }

        /// <summary>
        /// retrieves the current hdd temperatures using WMI
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, int> GetHddTemperatures()
        {
            var result = new Dictionary<string, int>();
            try
            {
                var searcher = new ManagementObjectSearcher("root\\WMI", "SELECT * FROM MSStorageDriver_ATAPISmartData");
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject queryObj in collection)
                {
                    if (queryObj["VendorSpecific"] != null)
                    {
                        string name = (string)queryObj["InstanceName"];
                        var smartData = new SMARTDATA((byte[])(queryObj["VendorSpecific"]));
                        int temperature = smartData.HddTemperature;
                        if (temperature >= 0) result.Add(name, temperature);
                    }
                }
                searcher.Dispose();
            }
            catch { }
            return result;
        }

        /// <summary>
        /// retrieves the fan speed of the Win32 Fan (driver needed !)
        /// </summary>
        /// <returns></returns>
        public static int GetFanSpeed()
        {
            var managementClass = new ManagementClass("Win32_Fan");
            foreach (ManagementObject managementObject in managementClass.GetInstances())
            {
                foreach (PropertyData propertyData in managementObject.Properties)
                {
                    if (propertyData.Value != null)
                    {
                        return (int)propertyData.Value;
                    }
                }
            }
            throw new NotSupportedException();
        }

        /// <summary>
        /// Parses a string to read a date/time value.
        /// </summary>
        /// <param name="wMIDateString"></param>
        /// <returns></returns>
        public static DateTime ParseCIMDateTime(string wMIDateString)
        {
            //check parameter
            if (string.IsNullOrEmpty(wMIDateString)) throw new ArgumentNullException("wMIDateString");
            wMIDateString = wMIDateString.Insert(24, ":") + "0";
            //set parsing format
            string l_Format = "yyyyMMddHHmmss.ffffffzzz";
            //return
            return DateTime.ParseExact(wMIDateString, l_Format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Obtains the processor count
        /// </summary>
        /// <returns></returns>
        public static int GetPhysicalProcessorCount()
        {
            List<object> processorList = new List<object>();
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            foreach (ManagementObject managementObject in managementClass.GetInstances())
            {
                if (!processorList.Contains(managementObject.Properties["SocketDesignation"].Value))
                {
                    processorList.Add(managementObject.Properties["SocketDesignation"].Value);
                }
            }
            return processorList.Count;
        }

        /// <summary>
        /// Obtains the uptime
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetUptime()
        {
            TimeSpan uptime = new TimeSpan();
            ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject l_ManagementObject in managementClass.GetInstances())
            {
                //get the LastBootUpTime date parsed
                try
                {
                    DateTime lastBootUp = ParseCIMDateTime(l_ManagementObject["LastBootUpTime"].ToString());
                    if (lastBootUp != default(DateTime))
                    {
                        uptime = DateTime.Now - lastBootUp;
                    }
                }
                catch { }
            }
            return uptime;
        }
    }
}

#endif