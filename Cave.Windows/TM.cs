using System;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// C++ structure containing a calendar date and time broken down into its components.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct TM
    {
        /// <summary>
        /// seconds after the minute
        /// </summary>
        public int Seconds;

        /// <summary>
        /// minutes after the hour
        /// </summary>
        public int Minute;

        /// <summary>
        /// hours since midnight
        /// </summary>
        public int Hour;

        /// <summary>
        /// day of the month
        /// </summary>
        public int Day;

        /// <summary>
        /// months since January
        /// </summary>
        public int Month;

        /// <summary>
        /// years since 1900
        /// </summary>
        public int Year;

        /// <summary>
        /// days since Sunday
        /// </summary>
        public int WeekDay;

        /// <summary>
        /// days since January 1
        /// </summary>
        public int DayOfYear;

        /// <summary>
        /// Daylight Saving Time flag
        /// </summary>
        public int IsDayLightSaving;

        /// <summary>
        /// Obtains the date time of this TM object
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime() => new(Year + 1900, Month, Day, Hour, Minute, Seconds, DateTimeKind.Unspecified);

        /// <summary>
        /// Returns the date time as string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToDateTime().ToString();
    }
}
