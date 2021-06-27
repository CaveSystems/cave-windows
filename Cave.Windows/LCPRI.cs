namespace Cave.Windows
{
    /// <summary>
    /// Logical configuration Priority values
    /// <para>These priority values are used in user-mode calls to CM_Add_Empty_Log_Conf. Drivers may also specify priority values for a given IO_RESOURCE_LIST structure by including a ConfigData member union as the first IO_RESOURCE_DESCRIPTOR in the IO_RESOURCE_LIST. In this case, the descriptor type would be CmResourceTypeConfigData.</para>
    /// </summary>
    public enum LCPRI
    {
        /// <summary>
        /// Coming from a forced config
        /// </summary>
        FORCECONFIG = 0x0,

        /// <summary>
        /// Coming from a boot config
        /// </summary>
        BOOTCONFIG = 0x1,

        /// <summary>
        /// Preferable (better performance)
        /// </summary>
        DESIRED = 0x2000,

        /// <summary>
        /// Workable (acceptable performance)
        /// </summary>
        NORMAL = 0x3000,

        /// <summary>
        /// Do not use / Mask
        /// </summary>
        LASTBESTCONFIG = 0x3FFF,

        /// <summary>
        /// Not desired, but will work
        /// </summary>
        SUBOPTIMAL = 0x5000,

        /// <summary>
        /// Do not use / Mask
        /// </summary>
        LASTSOFTCONFIG = 0x7FFF,

        /// <summary>
        /// Need to restart
        /// </summary>
        RESTART = 0x8000,

        /// <summary>
        /// Need to reboot
        /// </summary>
        REBOOT = 0x9000,

        /// <summary>
        /// Need to shutdown/power-off
        /// </summary>
        POWEROFF = 0xA000,

        /// <summary>
        /// Need to change a jumper
        /// </summary>
        HARDRECONFIG = 0xC000,

        /// <summary>
        /// Cannot be changed
        /// </summary>
        HARDWIRED = 0xE000,

        /// <summary>
        /// Impossible configuration
        /// </summary>
        IMPOSSIBLE = 0xF000,

        /// <summary>
        /// Disabled configuration
        /// </summary>
        DISABLED = 0xFFFF,
    }
}
