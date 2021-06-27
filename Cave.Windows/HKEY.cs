using System;

namespace Cave.Windows
{
    /// <summary>
    /// Windows handles to registry hives
    /// </summary>
    
    public enum HKEY : int
    {
        /// <summary>
        /// Defines the types (or classes) of documents and the properties associated with those types. This field reads the Windows registry base key HKEY_CLASSES_ROOT.
        /// </summary>
        CLASSES_ROOT = unchecked((int)0x80000000),

        /// <summary>
        /// Contains information about the current user preferences. This field reads the Windows registry base key HKEY_CURRENT_USER
        /// </summary>
        CURRENT_USER = unchecked((int)0x80000001),

        /// <summary>
        /// Contains the configuration data for the local machine. This field reads the Windows registry base key HKEY_LOCAL_MACHINE.
        /// </summary>
        LOCAL_MACHINE = unchecked((int)0x80000002),

        /// <summary>
        /// Contains information about the default user configuration. This field reads the Windows registry base key HKEY_USERS.
        /// </summary>
        USERS = unchecked((int)0x80000003),

        /// <summary>
        /// Contains performance information for software components. This field reads the Windows registry base key HKEY_PERFORMANCE_DATA.
        /// </summary>
        PERFORMANCE_DATA = unchecked((int)0x80000004),

        /// <summary>
        /// Contains configuration information pertaining to the hardware that is not specific to the user. This field reads the Windows registry base key HKEY_CURRENT_CONFIG.
        /// </summary>
        CURRENT_CONFIG = unchecked((int)0x80000005),

        /// <summary>
        /// Obsolete. Contains dynamic registry data. This field reads the Windows registry base key HKEY_DYN_DATA.
        /// </summary>
        [Obsolete("The DynData registry key only works on Win9x, which is no longer supported by the CLR. On NT-based operating systems, use the PerformanceData registry key instead.")]
        DYN_DATA = unchecked((int)0x80000006),
    }
}
