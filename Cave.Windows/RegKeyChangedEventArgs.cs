using Microsoft.Win32;
using System;

namespace Cave.Windows
{
    /// <summary>
    /// <see cref="EventArgs"/> for Registry notifications
    /// </summary>
    public class RegKeyChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtains the <see cref="RegistryKey"/>
        /// </summary>
        public RegistryKey Key;

        /// <summary>
        /// Creates new <see cref="RegKeyChangedEventArgs"/>
        /// </summary>
        /// <param name="key"></param>
        public RegKeyChangedEventArgs(RegistryKey key) => Key = key;
    }
}
