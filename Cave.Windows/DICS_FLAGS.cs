using System;

namespace Cave.Windows
{
    /// <summary>
    /// Scope of a device property change
    /// </summary>
    [Flags]
    public enum DICS_FLAGS : uint
    {
        /// <summary>
        /// Make the change in all hardware profiles.
        /// </summary>
        GLOBAL = 1,

        /// <summary>
        /// Make the change in the specified profile only.
        /// </summary>
        CONFIGSPECIFIC = 2,

        /// <summary>
        /// 1 or more hardware profile-specific
        /// </summary>
        [Obsolete]
        CONFIGGENERAL = 4,
    }
}
