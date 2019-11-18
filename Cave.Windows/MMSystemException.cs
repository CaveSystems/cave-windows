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
#endregion License
#region Authors & Contributors
/*
   Author:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion Authors & Contributors

using System;
using System.Runtime.Serialization;

namespace Cave.Windows
{
    /// <summary>
    /// Privides a Windows Multi Media System Exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class MMSystemException : Exception
    {
        /// <summary>The result</summary>
        public WINMM.RESULT Result { get; }

        /// <summary>Initializes a new instance of the <see cref="MMSystemException"/> class.</summary>
        public MMSystemException()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MMSystemException"/> class.</summary>
        /// <param name="message">Die Meldung, in der der Fehler beschrieben wird.</param>
        public MMSystemException(string message) : base(message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MMSystemException"/> class.</summary>
        /// <param name="result">The result.</param>
        public MMSystemException(WINMM.RESULT result)
            : base("MMSystem Error " + result.ToString())
        {
            Result = result;
        }

        /// <summary>Initializes a new instance of the <see cref="MMSystemException"/> class.</summary>
        /// <param name="message">Die Fehlermeldung, in der die Ursache der Ausnahme erklärt wird.</param>
        /// <param name="innerException">Die Ausnahme, die die aktuelle Ausnahme ausgelöst hat, oder ein Nullverweis (Nothing in Visual Basic), wenn keine innere Ausnahme angegeben ist.</param>
        public MMSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MMSystemException"/> class.</summary>
        /// <param name="info">Die <see cref="T:System.Runtime.Serialization.SerializationInfo" />-Klasse, die die serialisierten Objektdaten für die ausgelöste Ausnahme enthält.</param>
        /// <param name="context">Der <see cref="T:System.Runtime.Serialization.StreamingContext" />, der die Kontextinformationen über die Quelle oder das Ziel enthält.</param>
        protected MMSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}