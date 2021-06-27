namespace Cave.Windows
{
    /// <summary>
    /// process memory type
    /// </summary>
    
    public enum MEM_TYPE : uint
    {
        /// <summary></summary>
        IMAGE = 0x1000000,

        /// <summary></summary>
        MAPPED = 0x40000,

        /// <summary></summary>
        PRIVATE = 0x20000,
    }
}
