using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Specifies Desktop Window Manager (DWM) thumbnail properties.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_THUMBNAIL_PROPERTIES
    {
        /// <summary>
        /// A bitwise combination of DWM thumbnail constant values that indicate which members are set.
        /// </summary>
        public DWM_TNP Flags;

        /// <summary>
        /// The rectangle in the destination window the thumbnail will be rendered.
        /// </summary>
        public Rectangle Destination;

        /// <summary>
        /// The rectangle that specifies the region of the source window to use as the thumbnail. By default, the entire window is used as the thumbnail.
        /// </summary>
        public Rectangle Source;

        /// <summary>
        /// The opacity with which to render the thumbnail. 0 is fully transparent while 255 is fully opaque. The default value is 255.
        /// </summary>
        public byte Opacity;

        /// <summary>
        /// TRUE to make the thumbnail visible; FALSE to make the thumbnail invisible. The default is FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Visible;

        /// <summary>
        /// TRUE to use only the thumbnail source's client area; otherwise, FALSE. The default is FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool SourceClientAreaOnly;
    }
}
