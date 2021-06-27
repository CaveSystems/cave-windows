using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Specifies Desktop Window Manager (DWM) blur behind properties.
    /// </summary>    
    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {
        /// <summary>
        /// A bitwise combination of DWM Blur Behind Constants values indicating which members are set.
        /// </summary>
        public DWM_BB Flags;

        /// <summary>
        /// TRUE to register the window handle to DWM blur behind; FALSE to unregister the window handle from DWM blur behind.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool Enable;

        /// <summary>
        /// The region within the client area to apply the blur behind. A NULL value will apply the blur behind the entire client area.
        /// </summary>
        IntPtr m_Region;

        /// <summary>
        /// TRUE if the window's colorization should transition to match the maximized windows; otherwise, FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool TransitionOnMaximized;

        /// <summary>
        /// Sets a new Region
        /// </summary>
        /// <param name="graphics">The Graphics on which this Region is drawn. </param>
        /// <param name="region">The Region to set</param>
        public void SetRegion(Graphics graphics, Region region) => m_Region = region.GetHrgn(graphics);

        /// <summary>
        /// Obtains the Region
        /// </summary>
        /// <returns></returns>
        public Region GetRegion() => Region.FromHrgn(m_Region);
    }
}
