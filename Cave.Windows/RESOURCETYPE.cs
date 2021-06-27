namespace Cave.Windows
{
    /// <summary>
    /// The type of resource
    /// </summary>
    public enum RESOURCETYPE : int
    {
        /// <summary>
        /// unknown resource
        /// </summary>
        RESOURCETYPE_UNKNOWN = 0xFFFF,
        /// <summary>
        /// resource is a disk
        /// </summary>
        RESOURCETYPE_DISK = 0x1,
        /// <summary>
        /// resource is a printer
        /// </summary>
        RESOURCETYPE_PRINT = 0x2,
        /// <summary>
        /// resource type is unknown, try any
        /// </summary>
        RESOURCETYPE_ANY = 0x0,
    }
}
