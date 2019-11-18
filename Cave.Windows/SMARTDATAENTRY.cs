#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:

   Copyright (c) 2003-2014 Andreas Rohleder (andreas@rohleder.cc)
 */
#endregion

using Cave.Collections.Generic;
using Cave.IO;
using System;

namespace Cave.Windows
{
    /// <summary>
    /// provides access to s.m.a.r.t. data entries
    /// </summary>
    public class SMARTDATAENTRY
    {
        byte[] m_Data;

        /// <summary>
        /// index 0..29
        /// </summary>
        /// <param name="smartData"></param>
        /// <param name="index"></param>
        public SMARTDATAENTRY(byte[] smartData, int index)
        {
            if ((index < 0) || (index > 29)) throw new ArgumentException(string.Format("Index no in valid range [0..29] !"), "index");
            int i = 2 + (index * 12);
            m_Data = new byte[12];
            Buffer.BlockCopy(smartData, i, m_Data, 0, 12);
        }

        /// <summary>
        /// retrieves the identifier of the smart data entry
        /// </summary>
        public byte Identifier { get { return m_Data[0]; } }

        /// <summary>
        /// retrieves the flags for the smart data entry
        /// </summary>
        public ushort Flags { get { return BitConverterLE.Instance.ToUInt16(m_Data, 1); } }

        /// <summary>
        /// retrieves the value of the smart data entry
        /// </summary>
        public byte Value { get { return m_Data[3]; } }

        /// <summary>
        /// retrieves the whole data of the smart data entry
        /// </summary>
        public byte[] Data
        {
            get { return (byte[])m_Data.Clone(); }
        }

        /// <summary>
        /// obtains a summary
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Identifier.ToString() + "=" + Value.ToString();
        }
    }
}
