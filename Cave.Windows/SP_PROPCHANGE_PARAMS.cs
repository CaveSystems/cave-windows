using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// An SP_PROPCHANGE_PARAMS structure corresponds to a DIF_PROPERTYCHANGE installation request.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SP_PROPCHANGE_PARAMS
    {
        /// <summary>
        /// An install request header that contains the header size and the DIF code for the request. See SP_CLASSINSTALL_HEADER.
        /// </summary>
        public SP_CLASSINSTALL_HEADER ClassInstallHeader;

        /// <summary>
        /// State change action.
        /// </summary>
        public DICS StateChange;

        /// <summary>
        /// Flags that specify the scope of a device property change.
        /// </summary>
        public DICS_FLAGS Scope;

        /// <summary>
        /// Supplies the hardware profile ID for profile-specific changes. Zero specifies the current hardware profile.
        /// </summary>
        public uint HwProfile;
    }
}
