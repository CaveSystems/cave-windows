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
                    var name = (string)queryObj["InstanceName"];
                    var kelvin = (uint)queryObj["CurrentTemperature"];
                    var celsius = (int)((kelvin - 2731) / 10);
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
            foreach (ManagementObject queryObj in searcher.Get())
            {
                if ((ushort)queryObj["Availability"] <= 3)
                {
                    var name = (string)queryObj["Caption"];
                    var kelvin = (uint)queryObj["CurrentReading"];
                    var celsius = (int)((kelvin - 2731) / 10);
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
                var collection = searcher.Get();
                foreach (ManagementObject queryObj in collection)
                {
                    if (queryObj["VendorSpecific"] != null)
                    {
                        var name = (string)queryObj["InstanceName"];
                        var smartData = new SMARTDATA((byte[])(queryObj["VendorSpecific"]));
                        var temperature = smartData.HddTemperature;
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
            foreach (var managementObject in managementClass.GetInstances())
            {
                foreach (var propertyData in managementObject.Properties)
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
        /// <param name="wmiDateString"></param>
        /// <returns></returns>
        public static DateTime ParseCIMDateTime(string wmiDateString)
        {
            //check parameter
            if (string.IsNullOrEmpty(wmiDateString)) throw new ArgumentNullException(nameof(wmiDateString));
            wmiDateString = wmiDateString.Insert(24, ":") + "0";
            //set parsing format
            var format = "yyyyMMddHHmmss.ffffffzzz";
            //return
            return DateTime.ParseExact(wmiDateString, format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Obtains the processor count
        /// </summary>
        /// <returns></returns>
        public static int GetPhysicalProcessorCount()
        {
            var processorList = new List<object>();
            var managementClass = new ManagementClass("Win32_Processor");
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
            var uptime = new TimeSpan();
            var managementClass = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject managementObject in managementClass.GetInstances())
            {
                //get the LastBootUpTime date parsed
                try
                {
                    var lastBootUp = ParseCIMDateTime(managementObject["LastBootUpTime"].ToString());
                    if (lastBootUp != default)
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
