using System;

namespace Cave.Windows
{
    /// <summary>
    /// Flags used by DWM_BLURBEHIND to indicate which members have been set.
    /// </summary>
    
    [Flags]
    public enum DWM_BB : uint
    {
        /// <summary>
        /// Indicates a value for fEnable has been  specified .
        /// </summary>
        ENABLE = 0x00000001,

        /// <summary>
        /// Indicates a value for hRgnBlur has been  specified .
        /// </summary>
        BLURREGION = 0x00000002,

        /// <summary>
        /// Indicates a value for fTransitionOnMaximized has been  specified .
        /// </summary>
        TRANSITIONONMAXIMIZED = 0x00000004,
    }
}
