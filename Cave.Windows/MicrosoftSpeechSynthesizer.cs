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