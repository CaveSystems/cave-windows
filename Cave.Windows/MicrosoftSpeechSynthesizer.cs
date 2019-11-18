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
 */
#endregion

#if TODO

using Cave.Logging;
using Cave.Media;
using System.Globalization;
using System.Speech.Synthesis;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a <see cref="ISpeechSynthesizer"/> implementation for Microsoft Speech
    /// </summary>
    /// <seealso cref="ISpeechSynthesizer" />
    public class MicrosoftSpeechSynthesizer : ISpeechSynthesizer, ILogSource
    {
        SpeechSynthesizer synth;

        /// <summary>Initializes a new instance of the <see cref="MicrosoftSpeechSynthesizer"/> class.</summary>
        public MicrosoftSpeechSynthesizer()
        {
            synth = new SpeechSynthesizer();
            this.LogInfo("Using <green>MicrosoftSpeechSynthesizer");
        }

        /// <summary>Gets the name of the log source.</summary>
        /// <value>The name of the log source.</value>
        public string LogSourceName
        {
            get { return "MicrosoftSpeechSynthesizer"; }
        }

        /// <summary>Gets or sets the volume.</summary>
        /// <value>The volume.</value>
        public float Volume
        {
            get
            {
                return synth.Volume / 100.0f;
            }
            set
            {
                synth.Volume = (int)(value * 100);
            }
        }

        /// <summary>Selects a voice with a specific gender, age, and locale.</summary>
        /// <param name="gender">The gender.</param>
        /// <param name="age">The age.</param>
        /// <param name="cultureInfo">The culture information.</param>
        public void SelectVoiceByHints(Cave.Media.VoiceGender gender, Cave.Media.VoiceAge age, CultureInfo cultureInfo)
        {
            lock (synth)
            {
                System.Speech.Synthesis.VoiceGender vg = (System.Speech.Synthesis.VoiceGender)(int)gender;
                System.Speech.Synthesis.VoiceAge va;
                age.ToString().TryParse(out va);
                synth.SelectVoiceByHints(vg, va, 0, cultureInfo);
            }
        }

        /// <summary>Speaks the specified text.</summary>
        /// <param name="text">The text.</param>
        public void Speak(string text)
        {
            lock (synth)
            {
                synth.Speak(text);
            }
        }
    }
}
#endif