using System.Diagnostics.CodeAnalysis;

namespace Cave.Windows
{
    /// <summary>
    ///
    /// </summary>
    [SuppressMessage("Design", "CA1069")]
    public enum PBT : int
    {
        /// <summary>
        ///
        /// </summary>
        APMQUERYSUSPEND = 0x0000,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSTANDBY = 0x0001,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSUSPENDFAILED = 0x0002,

        /// <summary>
        ///
        /// </summary>
        APMQUERYSTANDBYFAILED = 0x0003,

        /// <summary>
        ///
        /// </summary>
        APMSUSPEND = 0x0004,

        /// <summary>
        ///
        /// </summary>
        APMSTANDBY = 0x0005,

        /// <summary>
        ///
        /// </summary>
        APMRESUMECRITICAL = 0x0006,

        /// <summary>
        ///
        /// </summary>
        APMRESUMESUSPEND = 0x0007,

        /// <summary>
        ///
        /// </summary>
        APMRESUMESTANDBY = 0x0008,

        /// <summary>
        ///
        /// </summary>
        PBTF_APMRESUMEFROMFAILURE = 0x00000001,

        /// <summary>
        ///
        /// </summary>
        APMBATTERYLOW = 0x0009,

        /// <summary>
        ///
        /// </summary>
        APMPOWERSTATUSCHANGE = 0x000A,

        /// <summary>
        ///
        /// </summary>
        APMOEMEVENT = 0x000B,

        /// <summary>
        ///
        /// </summary>
        APMRESUMEAUTOMATIC = 0x0012,
    }
}
