using System;

namespace Cave.Windows
{
    /// <summary>
    /// Flags for device information elements filter
    /// </summary>
    [Flags]
    public enum DIGCF : uint
    {
        /// <summary>
        /// Return only the device that is associated with the system default device interface, if one is set, for the specified device interface classes.
        /// </summary>
        DEFAULT=0x1,

        /// <summary>
        /// Return only devices that are currently present in a system.
        /// </summary>
        PRESENT = 0x2,

        /// <summary>
        /// Return a list of installed devices for all device setup classes or all device interface classes.
        /// </summary>
        ALLCLASSES = 0x4,

        /// <summary>
        /// Return only devices that are a part of the current hardware profile.
        /// </summary>
        PROFILE = 0x8,

        /// <summary>
        /// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags parameter if the Enumerator parameter specifies a device instance ID.
        /// </summary>
        DEVICEINTERFACE=0x10,
    }
}
