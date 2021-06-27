namespace Cave.Windows
{
    /// <summary>
    /// Availability and status of an usb device.
    /// </summary>
    public enum Win32_USBHub_Availability : ushort
    {
        /// <summary>
        /// Other
        /// </summary>
        Other = 1,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 2,

        /// <summary>
        /// RunningOrFullPower
        /// </summary>
        RunningOrFullPower = 3,

        /// <summary>
        /// Warning
        /// </summary>
        Warning = 4,

        /// <summary>
        /// InTest
        /// </summary>
        InTest = 5,

        /// <summary>
        /// NotApplicable
        /// </summary>
        NotApplicable = 6,

        /// <summary>
        /// PowerOff
        /// </summary>
        PowerOff = 7,

        /// <summary>
        /// Offline
        /// </summary>
        Offline = 8,

        /// <summary>
        /// OffDuty
        /// </summary>
        OffDuty = 9,

        /// <summary>
        /// Degraded
        /// </summary>
        Degraded = 10,

        /// <summary>
        /// NotInstalled
        /// </summary>
        NotInstalled = 11,

        /// <summary>
        /// InstallError
        /// </summary>
        InstallError = 12,

        /// <summary>
        /// PowerSaveOrUnknown
        /// </summary>
        PowerSaveOrUnknown = 13,

        /// <summary>
        /// PowerSaveLowPowerMode
        /// </summary>
        PowerSaveLowPowerMode = 14,

        /// <summary>
        /// PowerSaveStandby
        /// </summary>
        PowerSaveStandby = 15,

        /// <summary>
        /// PowerCycle
        /// </summary>
        PowerCycle = 16,

        /// <summary>
        /// PowerSaveWarning
        /// </summary>
        PowerSaveWarning = 17,

        /// <summary>
        /// Paused
        /// </summary>
        Paused = 18,

        /// <summary>
        /// NotReady
        /// </summary>
        NotReady = 19,

        /// <summary>
        /// NotConfigured
        /// </summary>
        NotConfigured = 20,

        /// <summary>
        /// QuiescedOrUnavailable
        /// </summary>
        QuiescedOrUnavailable = 21,
    }
}
