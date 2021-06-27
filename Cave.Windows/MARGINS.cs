using System.Drawing;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Margins struct needed for api calls.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MARGINS
    {
        /// <summary>
        /// Converts a <see cref="Rectangle"/> structure to a new <see cref="MARGINS"/> structure.
        /// </summary>
        /// <param name="rect">Rectangle to convert.</param>
        public static implicit operator MARGINS(Rectangle rect)
        {
            return new MARGINS()
            {
                LEFT = rect.Left,
                RIGHT = rect.Right,
                BOTTOM = rect.Bottom,
                TOP = rect.Top,
            };
        }

        /// <summary>
        /// creates a new Margins struct with the specified values.
        /// </summary>
        /// <param name="l">Left.</param>
        /// <param name="t">Top.</param>
        /// <param name="r">Right.</param>
        /// <param name="b">Bottom.</param>
        public MARGINS(int l, int t, int r, int b)
        {
            LEFT = l;
            TOP = t;
            RIGHT = r;
            BOTTOM = b;
        }

        /// <summary>
        /// distance to the left border.
        /// </summary>
        public int LEFT;

        /// <summary>
        /// distance to the right border.
        /// </summary>
        public int RIGHT;

        /// <summary>
        /// distance to the top border.
        /// </summary>
        public int TOP;

        /// <summary>
        /// distance to the bottom border.
        /// </summary>
        public int BOTTOM;

        /// <summary>
        /// Converts the structure to a <see cref="Rectangle"/> structure.
        /// </summary>
        ///// <returns>Returns a new <see cref="Rectangle"/> instance.</returns>
        public Rectangle ToRectangle() => Rectangle.FromLTRB(LEFT, TOP, RIGHT, BOTTOM);
    }
}
