using System;
using System.Collections.Generic;
using System.Management;

namespace Cave.Windows
{
    /// <summary>
    /// The Win32_USBHub WMI class represents the management characteristics of a universal serial bus (USB) hub.
    /// </summary>
    public class Win32_USBHub : Win32_Object
    {
        /// <summary>
        /// Obtains all devices at the root Win32_USBHub
        /// </summary>
        /// <returns></returns>
        public static Win32_USBHub[] GetAll()
        {
            var list = new List<Win32_USBHub>();
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub");
            var collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                list.Add(new Win32_USBHub(obj));
            }
            searcher.Dispose();
            collection.Dispose();
            return list.ToArray();
        }

        private Win32_USBHub(ManagementObject obj) : base(obj) { }

        /// <summary>
        /// Availability and status of the device. Power Save - Unknown indicates that the device is known to be in a power save mode, but its exact status is unknown; Power Save - Low Power Mode indicates that the device is in a power save state, but still functioning, and may exhibit degraded performance; Power Save - Standby indicates that the device is not functioning, but can be brought to full power quickly; and Power Save - Warning indicates that the device is in a warning state, though also in a power save mode. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public Win32_USBHub_Availability Availability => Read<Win32_USBHub_Availability>("Availability");

        /// <summary>
        /// Short description of the CIM_Setting object. This property is inherited from CIM_Setting.
        /// </summary>
        public string Caption => Read<string>("Caption");

        /// <summary>
        /// USB class code. This property is inherited from CIM_USBHub.
        /// </summary>
        public byte ClassCode => Read<byte>("ClassCode");

        /// <summary>
        /// Win32 Configuration Manager error code.
        /// </summary>
        public uint ConfigManagerErrorCode => Read<uint>("ConfigManagerErrorCode");

        /// <summary>
        /// If TRUE, the device is using a user-defined configuration. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public bool ConfigManagerUserConfig => Read<bool>("ConfigManagerUserConfig");

        /// <summary>
        /// Name of the first concrete class to appear in the inheritance chain used in the creation of an instance. When used with the other key properties of the class, this property allows all instances of this class and its subclasses to be uniquely identified. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string CreationClassName => Read<string>("CreationClassName");

        /// <summary>
        /// Array of USB alternate settings for each interface in the currently selected configuration (indicated by the CurrentConfigValue property). This array has one entry for each interface in the configuration. If the property, CurrentConfigValue is 0 (zero), (which indicates that the device is not configured), the array is undefined. To understand how to parse this octet string, refer to the USB specification. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public byte CurrentAlternateSettings => Read<byte>("CurrentAlternateSettings");

        /// <summary>
        /// Configuration currently configured for this device. If this value is 0 (zero), the device is not configured. This property is inherited from CIM_USBDevice.
        /// </summary>
        public byte CurrentConfigValue => Read<byte>("CurrentConfigValue");

        /// <summary>
        /// Textual description of the object. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public string Description => Read<string>("Description");

        /// <summary>
        /// Address or other identifying information to name the logical device uniquely. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string DeviceID => Read<string>("DeviceID");

        /// <summary>
        /// Indicates that the error reported in the LastErrorCode property is now cleared. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public bool ErrorCleared => Read<bool>("ErrorCleared");

        /// <summary>
        /// Free-form string that supplies more information about the error recorded in LastErrorCode property and information about any corrective actions that may be taken. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string ErrorDescription => Read<string>("ErrorDescription");

        /// <summary>
        /// If TRUE, power is switched to all ports on the HUB at one time. If FALSE, power is switched individually for each port. This property is inherited from CIM_USBHub.
        /// </summary>
        public bool GangSwitched => Read<bool>("GangSwitched");

        /// <summary>
        /// Date and time the object was installed. This property does not require a value to indicate that the object is installed. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public DateTime InstallDate => Read<DateTime>("InstallDate");

        /// <summary>
        /// Last error code reported by the logical device. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public uint LastErrorCode => Read<uint>("LastErrorCode");

        /// <summary>
        /// Name of the USB hub. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public string Name => Read<string>("Name");

        /// <summary>
        /// Number of defined device configurations. This property is inherited from CIM_USBDevice.
        /// </summary>
        public byte NumberOfConfigs => Read<byte>("NumberOfConfigs");

        /// <summary>
        /// Number of downstream ports on the hub, including those embedded in the hub's silicon. This property is inherited from CIM_USBHub.
        /// </summary>
        public byte NumberOfPorts => Read<byte>("NumberOfPorts");

        /// <summary>
        /// Windows Plug and Play device identifier of the logical device. Example: *PNP030b. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string PNPDeviceID => Read<string>("PNPDeviceID");

        /// <summary>
        /// Specific power-related capabilities of the logical device. This property is inherited from CIM_USBHub.
        /// </summary>
        public Win32_PowerManagementCapabilities[] PowerManagementCapabilities => ReadArray<Win32_PowerManagementCapabilities, ushort>("PowerManagementCapabilities");

        /// <summary>
        /// If TRUE, the device can be power managed; that is, put into a power save state. This Boolean value does not indicate that power management features are currently enabled or, if enabled, what features are supported. For more information, see the PowerManagementCapabilities array for this information. If FALSE, the integer value 1 (one), for the string "Not Supported", should be the only entry in the PowerManagementCapabilities array. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public bool PowerManagementSupported => Read<bool>("PowerManagementSupported");

        /// <summary>
        /// USB protocol code. This property is inherited from CIM_USBDevice.
        /// </summary>
        public byte ProtocolCode => Read<byte>("ProtocolCode");

        /// <summary>
        /// Current status of the object. Various operational and nonoperational statuses can be defined. Operational statuses include: "OK", "Degraded", and "Pred Fail" (an element, such as a SMART-enabled hard disk drive, may be functioning properly but predicting a failure in the near future). Nonoperational statuses include: "Error", "Starting", "Stopping", and "Service". The latter, "Service", can apply during mirror-resilvering of a disk, reload of a user permissions list, or other administrative work. Not all such work is online, yet the managed element is neither "OK" nor in one of the other states. This property is inherited from CIM_ManagedSystemElement.
        /// </summary>
        public string Status => Read<string>("Status");

        /// <summary>
        /// State of the logical device. If this property does not apply to the logical device, the value 5 (Not Applicable) should be used. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public Win32_StatusInfo StatusInfo => Read<Win32_StatusInfo>("StatusInfo");

        /// <summary>
        /// USB subclass code. This property is inherited from CIM_USBDevice.
        /// </summary>
        public byte SubclassCode => Read<byte>("SubclassCode");

        /// <summary>
        /// Creation class name for the scoping system. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string SystemCreationClassName => Read<string>("SystemCreationClassName");

        /// <summary>
        /// Name of the scoping system. This property is inherited from CIM_LogicalDevice.
        /// </summary>
        public string SystemName => Read<string>("SystemName");

        /// <summary>
        /// Latest USB version supported by the USB device. The property is expressed as a binary-coded decimal (BCD), where a decimal point is implied between the second and third digits. For example, a value of 0x201 indicates that version 2.01 is supported. This property is inherited from CIM_USBDevice.
        /// </summary>
        public Version USBVersion
        {
            get
            {
                var version = Read<ushort>("USBVersion");
                return new Version(version >> 8, version & 0xFF);
            }
        }

        /// <summary>
        /// Obtains a string containing "Name [DeviceID]"
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name + " [" + DeviceID + "]";
    }
}

