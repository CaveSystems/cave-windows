namespace Cave.Windows
{
    /// <summary>
    /// Windows standard handles
    /// </summary>
    public enum STD_HANDLE : uint
    {
        /// <summary>The standard input device.</summary>
        INPUT = 0xFFFFFFF6,

        /// <summary>The standard output device.</summary>
        OUTPUT = 0xFFFFFFF5,

        /// <summary>The standard error device.</summary>
        ERROR = 0xFFFFFFF4,
    }
}
