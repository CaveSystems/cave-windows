using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// The POINT structure defines the x- and y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class POINT
    {
        /// <summary>
        /// Specifies the x-coordinate of the point.
        /// </summary>
        public int x;
        /// <summary>
        /// Specifies the y-coordinate of the point.
        /// </summary>
        public int y;
    }
}
