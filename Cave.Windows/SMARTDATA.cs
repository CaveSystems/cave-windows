using Cave.Collections.Generic;
using System;
using System.IO;

namespace Cave.Windows
{
    /// <summary>
    /// provides easy access to s.m.a.r.t. data
    /// </summary>
    public class SMARTDATA
    {
        /// <summary>
        /// obtains all entries
        /// </summary>
        public SMARTDATAENTRY[] Entries { get; private set; }

        /// <summary>
        /// creates a new s.m.a.r.t. data instance
        /// </summary>
        /// <param name="smartData"></param>
        public SMARTDATA(byte[] smartData)
        {
            Entries = new SMARTDATAENTRY[30];
            for (var i = 0; i < 30; i++)
            {
                Entries[i] = new SMARTDATAENTRY(smartData, i);
            }
        }

        /// <summary>
        /// creates a new s.m.a.r.t. data instance
        /// </summary>
        /// <param name="smartData"></param>
        public SMARTDATA(string smartData)
        {
            if (smartData == null) throw new ArgumentNullException(nameof(smartData));
            Entries = new SMARTDATAENTRY[30];
            var data = new byte[512];
            var currentValue = 0;
            var currentStage = 0;
            var currentPosition = 0;
            foreach (var c in smartData.ToUpperInvariant())
            {
                var value = -1;
                if ((c >= '0') && (c <= '9'))
                {
                    value = (byte)(c - '0');
                }
                else if ((c >= 'A') && (c <= 'F'))
                {
                    value = (byte)(c - 'A') + 10;
                }
                if (value >= 0)
                {
                    currentValue = (currentValue << 4) + value;
                    if (++currentStage == 2)
                    {
                        data[currentPosition++] = (byte)currentValue;
                        currentValue = 0;
                        currentStage = 0;
                    }
                }
            }
            if (currentPosition != 512) throw new InvalidDataException();
            for (var i = 0; i < 30; i++)
            {
                Entries[i] = new SMARTDATAENTRY(data, i);
            }
        }

        /// <summary>
        /// finds a specific s.m.a.r.t. data entry in the specified smart data
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public SMARTDATAENTRY FindSmartDataEntry(int identifier)
        {
            //iterate through all Entries
            foreach (var entry in Entries)
            {
                if (entry.Identifier == identifier)
                {
                    return entry;
                }
            }
            return null;
        }

        /// <summary>
        /// tries to retrieve the hdd temperature
        /// </summary>
        /// <returns></returns>
        public int HddTemperature
        {
            get
            {
                var smartDataEntry = FindSmartDataEntry(194);
                if (smartDataEntry == null)
                {
                    smartDataEntry = FindSmartDataEntry(190);
                }
                if (smartDataEntry != null)
                {
                    return smartDataEntry.Data[5];
                }
                return -1;
            }
        }
    }
}
