using System;

namespace Cave.Windows
{
    /// <summary>
    /// Flags used by the DWM_THUMBNAIL_PROPERTIES structure to indicate which of its members have been set.
    /// </summary>
    
    [Flags]
    public enum DWM_TNP : uint
    {
        /// <summary>
        /// Indicates a value for Destination has been  specified .
        /// </summary>
        RECTDESTINATION = 0x00000001,

        /// <summary>
        /// Indicates a value for Source has been  specified .
        /// </summary>
        RECTSOURCE = 0x00000002,

        /// <summary>
        /// Indicates a value for opacity has been  specified .
        /// </summary>
        OPACITY = 0x00000004,

        /// <summary>
        /// Indicates a value for Visible has been  specified .
        /// </summary>
        VISIBLE = 0x00000008,

        /// <summary>
        /// Indicates a value for SourceClientAreaOnly has been  specified .
        /// </summary>
        SOURCECLIENTAREAONLY = 0x00000010,
    }
}
