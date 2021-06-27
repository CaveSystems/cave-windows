using System;
using System.Collections.Generic;
using System.Threading;

namespace Cave.Windows
{
    /// <summary>
    /// provides a load percentage gauge for windows
    /// </summary>
    
    public class LOAD : IDisposable
    {
        /// <summary>
        /// class for handling load values
        /// </summary>
        public class VALUES
        {
            /// <summary>
            /// creates a new load item
            /// </summary>
            /// <param name="lastMinute"></param>
            /// <param name="lastFiveMinutes"></param>
            /// <param name="lastFifteenMinutes"></param>
            internal VALUES(double lastMinute, double lastFiveMinutes, double lastFifteenMinutes)
            {
                LastMinute = lastMinute;
                LastFiveMinutes = lastFiveMinutes;
                LastFifteenMinutes = lastFifteenMinutes;
            }

            /// <summary>
            /// obtains the load of the last minute
            /// </summary>
            public double LastMinute;

            /// <summary>
            /// obtains the load of the last five minutes
            /// </summary>
            public double LastFiveMinutes;

            /// <summary>
            /// obtains the load of the last fifteen minutes
            /// </summary>
            public double LastFifteenMinutes;
        }

        Timer timer;
        SYSTEMTIMES lastTimes = new();
        readonly LinkedList<double> List = new();

        void Update(object state)
        {
            lock (this)
            {
                //get kernel times
                var times = KERNEL32.GetSystemTimes();
                //calculate the timeslice we work on
                var sliceTime = ((times.Kernel + times.User) - (lastTimes.Kernel + lastTimes.User)).TotalMilliseconds;
                if (sliceTime < 1.0) return;
                //calculate the load during this timeslice
                var sliceLoad = 1 - ((times.Idle - lastTimes.Idle).TotalMilliseconds / sliceTime);
                //push the slice load to the array
                List.AddLast(sliceLoad);
                //pop all items older then 900 seconds
                while (List.Count > 900) List.RemoveFirst();
                //save last times
                lastTimes = times;
            }
        }

        /// <summary>
        /// retrieves the loads of the last 15 minutes (one value per second)
        /// </summary>
        public double[] Loads
        {
            get
            {
                lock (this)
                {
                    var result = new double[900];
                    List.CopyTo(result, 0);
                    return result;
                }
            }
        }

        /// <summary>
        /// retrieves the csu load percentages
        /// </summary>
        public VALUES Get()
        {
            var loads = Loads;
            double load = 0;
            var index = 900;
            int i;
            //calc last minute:
            for (i = 0; i < 60; i++)
            {
                load += loads[--index];
            }
            var lastMinute = load / 60;
            //calc last 5 minutes:
            for (; i < 300; i++)
            {
                load += loads[--index];
            }
            var lastFiveMinutes = load / 300;
            //calc last 15 minutes:
            for (; i < 900; i++)
            {
                load += loads[--index];
            }
            var lastFifteenMinutes = load / i;
            return new VALUES(lastMinute, lastFiveMinutes, lastFifteenMinutes);
        }

        /// <summary>
        /// creates a new load percentage object
        /// </summary>
        public LOAD()
        {
            for (var i = 0; i < 900; i++)
            {
                List.AddLast(0.0);
            }
            lastTimes = KERNEL32.GetSystemTimes();
            timer = new Timer(new TimerCallback(Update), null, 1000, 1000);
        }

        /// <summary>
        /// disposes the object
        /// </summary>
        public void Dispose()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
