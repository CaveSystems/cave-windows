using System;

namespace Cave.Windows
{
    /// <summary>
    /// PeekMessage parameters
    /// </summary>
    [Flags]
    public enum PM : int
    {
        /// <summary>
        ///
        /// </summary>
        NOREMOVE = 0,

        /// <summary>
        ///
        /// </summary>
        REMOVE = 1,

        /// <summary>
        ///
        /// </summary>
        NOYIELD = 2
    }
}
