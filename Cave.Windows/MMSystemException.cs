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
            : base("MMSystem Error " + result.ToString()) => Result = result;

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