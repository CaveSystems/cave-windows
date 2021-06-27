using System;

namespace Cave.Windows
{
    /// <summary>
    /// provides a struct for the windows idle, kernel and user times
    /// </summary>
    public struct SYSTEMTIMES
    {
        /// <summary>
        /// creates a new SystemTimes object and sets the timespans
        /// </summary>
        /// <param name="idle"></param>
        /// <param name="kernel"></param>
        /// <param name="user"></param>
        public SYSTEMTIMES(TimeSpan idle, TimeSpan kernel, TimeSpan user)
        {
            Idle = idle;
            Kernel = kernel;
            User = user;
        }

        /// <summary>
        /// Amount of time that the system has been idle.
        /// </summary>
        public TimeSpan Idle;

        /// <summary>
        /// Amount of time that the system has spent executing in Kernel mode (including all threads in all processes, on all processors). This time value also includes the amount of time the system has been idle.
        /// </summary>
        public TimeSpan Kernel;

        /// <summary>
        /// Amount of time that the system has spent executing in User mode (including all threads in all processes, on all processors).
        /// </summary>
        public TimeSpan User;
    }
}
