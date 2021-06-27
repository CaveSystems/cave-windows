using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The KBDLLHOOKSTRUCT structure contains information about a low-level keyboard input event.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class KBDLLHOOKSTRUCT
    {
        /// <summary>
        /// Specifies a virtual-key code. The code must be a value in the range 1 to 254.
        /// </summary>
        public int vkCode;

        /// <summary>
        /// Specifies a hardware scan code for the key.
        /// </summary>
        public int scanCode;

        /// <summary>
        /// Specifies the extended-key flag, event-injected flag, context code, and transition-state flag.
        /// </summary>
        public int flags;

        /// <summary>
        /// Specifies the time stamp for this message.
        /// </summary>
        public int time;

        /// <summary>
        /// Specifies extra information associated with the message.
        /// </summary>
        public int dwExtraInfo;
    }
}
