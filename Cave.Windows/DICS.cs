namespace Cave.Windows
{
    /// <summary>
    /// Provides state change actions
    /// </summary>
    public enum DICS : uint
    {
        /// <summary>
        /// Loads the drivers for the device and starts the device, if possible. If the function cannot start the device, it sets the DI_NEEDREBOOT flag for the device which indicates to the initiator of the property change request that they must prompt the user to restart the computer.
        /// </summary>
        ENABLE = 1,

        /// <summary>
        /// Disables the device. If the device can be disabled but this function cannot disable the device dynamically, this function marks the device to be disabled the next time that the computer restarts.
        /// </summary>
        DISABLE = 2,

        /// <summary>
        /// Removes and reconfigures the device so that the new properties can take effect. This flag typically indicates that a user has changed a property on a device manager property page for the device. The PnP manager directs the drivers for the device to remove their device objects and then the PnP manager reconfigures and restarts the device.
        /// </summary>
        PROPCHANGE = 3,

        /// <summary>
        /// The device is being started (if the request is for the currently active hardware profile).
        /// </summary>
        START = 4,

        /// <summary>
        /// The device is being stopped. The driver stack will be unloaded and the CSCONFIGFLAG_DO_NOT_START flag will be set for the device.
        /// </summary>
        STOP = 5
    }
}
