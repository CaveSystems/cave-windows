using System;

namespace Cave.Windows
{
    /// <summary>
    /// Provides windows console colors
    /// </summary>
    [Flags]
    public enum CONSOLECOLOR : byte
    {
        /// <summary>
        /// Foreground bits
        /// </summary>
        FOREGROUND = 0xF,

        /// <summary>
        /// Background bits
        /// </summary>
        BACKGROUND = 0xF0,

        /// <summary>
        /// Blue foreground
        /// </summary>
        FOREGROUND_BLUE = 1,

        /// <summary>
        /// Green foreground
        /// </summary>
        FOREGROUND_GREEN = 2,

        /// <summary>
        /// Red foreground
        /// </summary>
        FOREGROUND_RED = 4,

        /// <summary>
        /// Cyan foreground
        /// </summary>
        FOREGROUND_CYAN = FOREGROUND_GREEN + FOREGROUND_BLUE,

        /// <summary>
        /// Magenta foreground
        /// </summary>
        FOREGROUND_MAGENTA = FOREGROUND_BLUE + FOREGROUND_RED,

        /// <summary>
        /// Yellow foreground
        /// </summary>
        FOREGROUND_YELLOW = FOREGROUND_GREEN + FOREGROUND_RED,

        /// <summary>
        /// White foreground
        /// </summary>
        FOREGROUND_WHITE =  FOREGROUND_BLUE + FOREGROUND_GREEN + FOREGROUND_RED,

        /// <summary>
        /// Intense (lighter) foreground
        /// </summary>
        FOREGROUND_INTENSITY = 8,

        /// <summary>
        /// blue background
        /// </summary>
        BACKGROUND_BLUE = FOREGROUND_BLUE << 4,

        /// <summary>
        /// green background
        /// </summary>
        BACKGROUND_GREEN = FOREGROUND_GREEN << 4,

        /// <summary>
        /// red background
        /// </summary>
        BACKGROUND_RED = FOREGROUND_RED << 4,

        /// <summary>
        /// cyan background
        /// </summary>
        BACKGROUND_CYAN = FOREGROUND_CYAN << 4,

        /// <summary>
        /// magenta background
        /// </summary>
        BACKGROUND_MAGENTA = FOREGROUND_MAGENTA << 4,

        /// <summary>
        /// yellow background
        /// </summary>
        BACKGROUND_YELLOW = FOREGROUND_YELLOW << 4,

        /// <summary>
        /// white background
        /// </summary>
        BACKGROUND_WHITE = FOREGROUND_WHITE << 4,

        /// <summary>
        /// Intense (lighter) background
        /// </summary>
        BACKGROUND_INTENSITY = FOREGROUND_INTENSITY << 4,
    }
}
