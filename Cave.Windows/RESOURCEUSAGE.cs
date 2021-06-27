using System;

namespace Cave.Windows
{
    /// <summary>
    /// A set of bit flags describing how the resource can be used.
    /// </summary>
    [Flags]
    public enum RESOURCEUSAGE : int
    {
        /// <summary>
        /// resource is connectable
        /// </summary>
        RESOURCEUSAGE_CONNECTABLE = 0x1,
        /// <summary>
        /// resource is a container
        /// </summary>
        RESOURCEUSAGE_CONTAINER = 0x2,
        /// <summary>
        /// The resource is not a local device.
        /// </summary>
        RESOURCEUSAGE_NOLOCALDEVICE = 0x4,
        /// <summary>
        /// The resource is a sibling. This value is not used by Windows.
        /// </summary>
        RESOURCEUSAGE_SIBLING = 0x00000008,
        /// <summary>
        /// The resource must be attached. This value specifies that a function to enumerate resource this should fail if the caller is not authenticated, even if the network permits enumeration without authentication.
        /// </summary>
        RESOURCEUSAGE_ATTACHED = 0x00000010,
    }
}
