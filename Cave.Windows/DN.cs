using System;

namespace Cave.Windows
{
    /// <summary>
    /// Device Node Status Flags
    /// </summary>
    [Flags]
    public enum DN : ulong //BitSize depends on architecture
    {
        /// <summary>
        /// Was enumerated by ROOT
        /// </summary>
        ROOT_ENUMERATED = 0x1,

        /// <summary>
        /// Has Register_Device_Driver
        /// </summary>
        DRIVER_LOADED = 0x2,

        /// <summary>
        /// Has Register_Enumerator
        /// </summary>
        ENUM_LOADED = 0x4,

        /// <summary>
        /// Is currently configured
        /// </summary>
        STARTED = 0x8,

        /// <summary>
        /// Manually installed
        /// </summary>
        MANUAL = 0x10,

        /// <summary>
        /// May need reenumeration
        /// </summary>
        NEED_TO_ENUM = 0x20,

        /// <summary>
        /// Has received a config (Win9x only)
        /// </summary>
        NOT_FIRST_TIME = 0x40,

        /// <summary>
        /// Enum generates hardware ID
        /// </summary>
        HARDWARE_ENUM = 0x80,

        /// <summary>
        /// Lied about can reconfig once (Win9x only)
        /// </summary>
        LIAR = 0x100,

        /// <summary>
        /// Not CM_Create_DevNode lately (Win9x only)
        /// </summary>
        HAS_MASK = 0x200,

        /// <summary>
        /// Need device installer
        /// </summary>
        HAS_PROBLEM = 0x400,

        /// <summary>
        /// Is filtered
        /// </summary>
        FILTERED = 0x800,

        /// <summary>
        /// Has been moved (Win9x only)
        /// </summary>
        MOVED = 0x1000,

        /// <summary>
        /// Can be rebalanced
        /// </summary>
        DISABLEABLE = 0x2000,

        /// <summary>
        /// Can be removed
        /// </summary>
        REMOVABLE = 0x4000,

        /// <summary>
        /// Has a private problem
        /// </summary>
        PRIVATE_PROBLEM = 0x8000,

        /// <summary>
        /// Multi function parent
        /// </summary>
        MF_PARENT = 0x10000,

        /// <summary>
        /// Multi function child
        /// </summary>
        MF_CHILD = 0x20000,

        /// <summary>
        /// DevInst is being removed
        /// </summary>
        WILL_BE_REMOVED = 0x40000,

        /// <summary>
        /// Has received a config enumerate
        /// </summary>
        NOT_FIRST_TIMEE = 0x80000,

        /// <summary>
        /// When child is stopped, free resources
        /// </summary>
        STOP_FREE_RES = 0x100000,

        /// <summary>
        /// Don't skip during rebalance
        /// </summary>
        REBAcANDIDATE = 0x200000,

        /// <summary>
        /// This devnode's log_confs do not have same resources
        /// </summary>
        BAD_PARTIAL = 0x400000,

        /// <summary>
        /// This devnode's is an NT enumerator
        /// </summary>
        NT_ENUMERATOR = 0x800000,

        /// <summary>
        /// This devnode's is an NT driver
        /// </summary>
        NT_DRIVER = 0x1000000,

        /// <summary>
        /// Devnode need lock resume processing
        /// </summary>
        NEEDS_LOCKING = 0x2000000,

        /// <summary>
        /// Devnode can be the wakeup device
        /// </summary>
        ARM_WAKEUP = 0x4000000,

        /// <summary>
        /// APM aware enumerator
        /// </summary>
        APM_ENUMERATOR = 0x8000000,

        /// <summary>
        /// APM aware driver
        /// </summary>
        APM_DRIVER = 0x10000000,

        /// <summary>
        /// Silent install
        /// </summary>
        SILENT_INSTALL = 0x20000000,

        /// <summary>
        /// No show in device manager
        /// </summary>
        NO_SHOW_IN_DM = 0x40000000,

        /// <summary>
        /// Had a problem during preassignment of boot log conf
        /// </summary>
        BOOT_LOG_PROB = 0x80000000
    }
}
