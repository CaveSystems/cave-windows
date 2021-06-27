namespace Cave.Windows
{
    /// <summary>
    /// Provides symbol load flags for <see cref="DBGHELP"/>
    /// </summary>
    public enum SYMFLAGS : int
    {
        /// <summary>
        /// No flags given
        /// </summary>
        NONE = 0,

        /// <summary>
        /// Creates a virtual module named ModuleName at the address specified in BaseOfDll. To add symbols to this module, call the SymAddSymbol function.
        /// </summary>
        VIRTUAL = 1,

        /// <summary>
        /// Loads the module but not the symbols for the module.
        /// </summary>
        NO_SYMBOLS = 0x4
    }
}
