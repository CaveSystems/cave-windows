namespace Cave.Windows
{
    /// <summary>
    /// Scope of the resources
    /// </summary>
    public enum SCOPE : int
    {
        /// <summary>
        /// resource is connected
        /// </summary>
        RESOURCE_CONNECTED = 0x1,
        /// <summary>
        /// resource will be remembered (persistent connections)
        /// </summary>
        RESOURCE_REMEMBERED = 0x3,
        /// <summary>
        /// resources on the whole network
        /// </summary>
        RESOURCE_GLOBALNET = 0x2,
    }
}
