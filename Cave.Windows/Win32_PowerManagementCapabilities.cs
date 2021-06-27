namespace Cave.Windows
{
    /// <summary>
    /// Specific power-related capabilities of a logical device.
    /// </summary>
    public enum Win32_PowerManagementCapabilities : ushort
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown=0,

        /// <summary>
        /// NotSupported
        /// </summary>
        NotSupported=1,

        /// <summary>
        /// Disabled
        /// </summary>
        Disabled=2,

        /// <summary>
        /// Enabled
        /// </summary>
        Enabled=3,

        /// <summary>
        /// PowerSavingModesEnteredAutomatically
        /// </summary>
        PowerSavingModesEnteredAutomatically=4,

        /// <summary>
        /// PowerStateSettable
        /// </summary>
        PowerStateSettable=5,

        /// <summary>
        /// PowerCyclingSupported
        /// </summary>
        PowerCyclingSupported=6,

        /// <summary>
        /// TimedPowerOnSupported
        /// </summary>
        TimedPowerOnSupported=7,
    }
}
