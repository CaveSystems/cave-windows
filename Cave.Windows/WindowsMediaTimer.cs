using System;
using System.Diagnostics;

namespace Cave.Windows
{
    /// <summary>
    /// Provides access to the WindowsMediaTimer
    /// </summary>
    public static class WindowsMediaTimer
    {
        /// <summary>Begins this instance.</summary>
        /// <returns></returns>
        public static bool Begin()
        {
            if (Platform.IsMicrosoft)
            {
                try
                {
                    WINMM.TimeBeginFastPeriod();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"WINMM.TimeBeginFastPeriod() {ex}");
                    return false;
                }
            }
            Debug.WriteLine("This is not a microsoft platform!");
            return false;
        }

        /// <summary>Ends the fast period.</summary>
        /// <returns></returns>
        public static bool End()
        {
            if (Platform.IsMicrosoft)
            {
                try
                {
                    WINMM.TimeEndFastPeriod();
                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"WINMM.TimeEndFastPeriod() {ex}");
                    return false;
                }
            }
            Debug.WriteLine("This is not a microsoft platform!");
            return false;
        }
    }
}
