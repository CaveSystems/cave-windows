using Cave.IO;
using System;

namespace Cave.Windows
{
    /// <summary>
    /// provides access to s.m.a.r.t. data entries
    /// </summary>
    public class SMARTDATAENTRY
    {
        static readonly IBitConverter Converter = new BitConverterLE();

        /// <summary>
        /// index 0..29
        /// </summary>
        /// <param name="smartData"></param>
        /// <param name="index"></param>
        public SMARTDATAENTRY(byte[] smartData, int index)
        {
            if ((index < 0) || (index > 29)) throw new ArgumentException(string.Format("Index no in valid range [0..29] !"), nameof(index));
            var i = 2 + (index * 12);
            Data = new byte[12];
            Buffer.BlockCopy(smartData, i, Data, 0, 12);
        }

        /// <summary>
        /// retrieves the identifier of the smart data entry
        /// </summary>
        public byte Identifier => Data[0];

        /// <summary>
        /// retrieves the flags for the smart data entry
        /// </summary>
        public ushort Flags => Converter.ToUInt16(Data, 1);

        /// <summary>
        /// retrieves the value of the smart data entry
        /// </summary>
        public byte Value => Data[3];

        /// <summary>
        /// retrieves the whole data of the smart data entry
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// obtains a summary
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Identifier.ToString() + "=" + Value.ToString();
    }
}
