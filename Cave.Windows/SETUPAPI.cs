using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// The Setup API provides a set of functions that a setup application calls to perform installation operations.
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("Interoperability", "CA1401")]
    public class SETUPAPI
    {
        /// <summary>
        /// Provides a <see cref="SafeHandle"/> implementation for <see cref="SetupDiGetClassDevs"/>
        /// </summary>
        public sealed class Handle : SafeHandleZeroOrMinusOneIsInvalid
        {
            /// <summary>
            /// Creates a new handle
            /// </summary>
            internal Handle() : base(true) { }

            /// <summary>
            /// Releases the handle
            /// </summary>
            /// <returns></returns>
            protected override bool ReleaseHandle()
            {
                if (IsInvalid) return true;
                SETUPAPI.SetupDiDestroyDeviceInfoList(DangerousGetHandle());
                SetHandle(IntPtr.Zero);
                return true;
            }
        }

        /// <summary>
        /// Provides SETUPAPI device functions
        /// </summary>
        public sealed class DEVICE
        {
            readonly Handle Handle;
            SP_DEVINFO_DATA deviceInfo;
            //chache variables
            string description;
            string[] hardwareIds;
            string friendlyName;
            string locationInformation;
            string uiNumber;

            #region private implementation
            string GetString(SPDRP property)
            {
                var resultString = new StringBuilder(KERNEL32.DefaultStructBufferSize);
                var devInfo = deviceInfo;
                var result = SETUPAPI.SetupDiGetDeviceRegistryProperty(Handle, ref devInfo, property, out var valueKind, resultString, (uint)resultString.Capacity, out _);
                if (!result)
                {
                    var error = Marshal.GetLastWin32Error();
                    if (error == 13) return null;
                    if (error != 0) throw new Win32ErrorException(error);
                }
                switch (valueKind)
                {
                    case RegistryValueKind.Binary: throw new InvalidCastException(string.Format("Please use GetData() for BINARY values!"));
                    case RegistryValueKind.DWord: throw new InvalidCastException(string.Format("Please use GetUInt32() for DWORD values!"));
                    case RegistryValueKind.QWord: throw new InvalidCastException(string.Format("Please use GetUInt64() for QWORD values!"));
                    case RegistryValueKind.MultiString: break;
                    case RegistryValueKind.String: break;
                    default: throw new NotImplementedException(string.Format("Not implemented registry value kind {0}!", valueKind));
                }
                return resultString.ToString();
            }

            string[] GetStrings(SPDRP property)
            {
                var ptr = Marshal.AllocHGlobal(KERNEL32.DefaultStructBufferSize);
                try
                {
                    var valueKind = new RegistryValueKind();
                    uint requiredSize = 0;
                    var devInfo = deviceInfo;
                    var result = SetupDiGetDeviceRegistryProperty(Handle, ref devInfo, property, ref valueKind, ptr, (uint)KERNEL32.DefaultStructBufferSize, ref requiredSize);
                    if (!result)
                    {
                        var error = Marshal.GetLastWin32Error();
                        if (error == 13) return null;
                        if (error != 0) throw new Win32ErrorException(error);
                    }
                    switch (valueKind)
                    {
                        case RegistryValueKind.Binary: throw new InvalidCastException(string.Format("Please use GetData() for BINARY values!"));
                        case RegistryValueKind.DWord: throw new InvalidCastException(string.Format("Please use GetUInt32() for DWORD values!"));
                        case RegistryValueKind.QWord: throw new InvalidCastException(string.Format("Please use GetUInt64() for QWORD values!"));
                        case RegistryValueKind.MultiString: break;
                        case RegistryValueKind.String: throw new InvalidCastException(string.Format("Please use GetString() for *_SZ values!"));
                        default: throw new NotImplementedException(string.Format("Not implemented registry value kind {0}!", valueKind));
                    }
                    var str = Marshal.PtrToStringAuto(ptr, (int)requiredSize - 1);
                    return str.Split('\0');
                }
                finally { Marshal.FreeHGlobal(ptr); }
            }
            #endregion

            #region constructor
            /// <summary>
            /// Creates a new instance
            /// </summary>
            /// <param name="handle">Handle to the setupapi device search handle created by <see cref="SetupDiGetClassDevs"/></param>
            /// <param name="devInfo">A device info for a specific device</param>
            internal DEVICE(Handle handle, SP_DEVINFO_DATA devInfo)
            {
                Handle = handle;
                deviceInfo = devInfo;
            }
            #endregion

            #region public (readonly) properties
            /// <summary>
            /// Obtains the node (number)
            /// </summary>
            public uint DeviceNode => deviceInfo.DevInst;

            /// <summary>
            /// Obtains the ClassGuid
            /// </summary>
            public Guid ClassGuid => deviceInfo.ClassGuid;

            /// <summary>
            /// Obtains the device description
            /// </summary>
            public string Description
            {
                get
                {
                    if (description == null) description = GetString(SPDRP.DEVICEDESC);
                    return description;
                }
            }

            /// <summary>
            /// Obtains the hardware id (multiple devices can have the same hardware id e.g. processor cores)
            /// </summary>
            public string[] HardwareIds
            {
                get
                {
                    if (hardwareIds == null) hardwareIds = GetStrings(SPDRP.HARDWAREID);
                    return hardwareIds;
                }
            }

            /// <summary>
            /// Provides the "human readable" user friendly name of the device
            /// </summary>
            public string FriendlyName
            {
                get
                {
                    if (friendlyName == null) friendlyName = GetString(SPDRP.FRIENDLYNAME);
                    return friendlyName;
                }
            }

            /// <summary>
            /// Obtains the device location
            /// </summary>
            public string LocationInformation
            {
                get
                {
                    if (locationInformation == null) locationInformation = GetString(SPDRP.LOCATION_INFORMATION);
                    return locationInformation;
                }
            }

            /// <summary>
            /// Obtains the ui number of the device (if set, this can be a slot- or portnumber)
            /// </summary>
            public string UINumber
            {
                get
                {
                    if (uiNumber == null) uiNumber = GetString(SPDRP.UI_NUMBER);
                    return uiNumber;
                }
            }

            /// <summary>
            /// Checks whether the device is enabled or not.
            /// </summary>
            public bool Enabled
            {
                get
                {
                    var errorCode = CM_Get_DevNode_Status(out _, out var problemCode, deviceInfo.DevInst, 0);
                    if (errorCode != 0) throw new Win32ConfigManagerException(errorCode);
                    return problemCode == 0;
                }
            }
            #endregion

            #region public functionality
            /// <summary>
            /// Changes the properties of a device by calling the <see cref="SetupDiSetClassInstallParams"/> and <see cref="SetupDiChangeState"/> functions
            /// </summary>
            /// <param name="installFunction">The function to call</param>
            /// <param name="stateChange">The new state</param>
            /// <param name="scope">Scope for the change</param>
            /// <param name="hardwareProfile">HardwareProfile to use</param>
            public void ChangeProperty(DIF installFunction, DICS stateChange, DICS_FLAGS scope, uint hardwareProfile)
            {
                var p = new SP_PROPCHANGE_PARAMS();
                p.ClassInstallHeader.cbSize = (uint)Marshal.SizeOf(p.ClassInstallHeader);
                p.ClassInstallHeader.InstallFunction = installFunction;
                p.StateChange = stateChange;
                p.Scope = scope;
                p.HwProfile = hardwareProfile;
                var deviceInfo = this.deviceInfo;
                { //Set parameters
                    if (!SetupDiSetClassInstallParams(Handle, ref deviceInfo, ref p, (uint)Marshal.SizeOf(p))) throw new Win32ErrorException();
                    KERNEL32.CheckLastError();
                }
                { //Run change
                    if (!SetupDiChangeState(Handle, ref deviceInfo)) throw new Win32ErrorException();
                    KERNEL32.CheckLastError();
                }
                //if (!SetupDiCallClassInstaller(installFunction, m_Handle, ref deviceInfo))
            }

            /// <summary>
            /// Enables the device at hardware profile 0 gobally (this does only work with physical or endpoint devices, not with logical ones)
            /// </summary>
            public void EnableDevice()
            {
                ChangeProperty(DIF.PROPERTYCHANGE, DICS.ENABLE, DICS_FLAGS.GLOBAL, 0);
                ChangeProperty(DIF.PROPERTYCHANGE, DICS.ENABLE, DICS_FLAGS.CONFIGSPECIFIC, 0);
            }

            /// <summary>
            /// Disables the device at hardware profile 0 gobally (this does only work with physical or endpoint devices, not with logical ones)
            /// </summary>
            public void DisableDevice()
            {
                ChangeProperty(DIF.PROPERTYCHANGE, DICS.DISABLE, DICS_FLAGS.GLOBAL, 0);
                ChangeProperty(DIF.PROPERTYCHANGE, DICS.DISABLE, DICS_FLAGS.CONFIGSPECIFIC, 0);
            }
            #endregion

            #region object overrides
            /// <summary>
            /// Obtains a string containing "Description 'FriendlyName' [HardwareID]"<br />
            /// Empty fields may be omitted.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                var result = new StringBuilder();
                if (!string.IsNullOrEmpty(Description))
                {
                    result.Append(Description);
                }
                else
                {
                    result.AppendFormat("Node {0} Class {1}", DeviceNode, ClassGuid);
                }
                if (!string.IsNullOrEmpty(FriendlyName)) result.AppendFormat(" '{0}'", FriendlyName);
                var id = hardwareIds?.Where(id => !string.IsNullOrEmpty(id)).FirstOrDefault();
                if (id != null) result.AppendFormat(" [{0}]", id);
                return result.ToString();
            }

            /// <summary>
            /// Checks two instances for equality
            /// </summary>
            /// <param name="obj">Another DEVICE instance</param>
            /// <returns>Returns true if both instances have the same ClassGuid and DeviceNode</returns>
            public override bool Equals(object obj)
            {
                if (obj is not DEVICE other) return false;
                return (other.DeviceNode == DeviceNode) && (other.ClassGuid == ClassGuid);
            }

            /// <summary>
            /// Obtains the device node number
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode() => (int)DeviceNode;
            #endregion
        }

        /// <summary>
        /// Obtains a list of all present (active and inactive) devices
        /// </summary>
        /// <returns>Returns an array of <see cref="DEVICE"/>s</returns>
        public static DEVICE[] GetAllPresentDevices()
        {
            var devices = new List<DEVICE>();
            var guid = new Guid();
            var handle = SETUPAPI.SetupDiGetClassDevs(ref guid, null, IntPtr.Zero, DIGCF.ALLCLASSES | DIGCF.PRESENT);
            if (handle.IsInvalid) throw new Win32ErrorException();
            var info = new SP_DEVINFO_DATA();
            info.cbSize = (uint)Marshal.SizeOf(info);
            for (uint i = 0; SETUPAPI.SetupDiEnumDeviceInfo(handle, i, ref info); i++)
            {
                var device = new DEVICE(handle, info);
                devices.Add(device);
            }
            return devices.ToArray();
        }

        /// <summary>
        /// The SetupDiGetClassDevs function returns a handle to a device information set that contains requested device information elements for a local computer. <br />
        /// To return only devices that are present in the system, set the DIGCF_PRESENT flag.
        /// </summary>
        /// <param name="classGuid">A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be NULL. For more information about how to set ClassGuid, see the following Remarks section.</param>
        /// <param name="enumerator">A pointer to a NULL-terminated string that specifies:
        /// <list type="bullet">
        /// <item>An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the value's globally unique identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".</item>
        /// <item>A PnP device instance ID. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.</item>
        /// </list>
        /// This pointer is optional and can be NULL. If an enumeration value is not used to select devices, set Enumerator to NULL
        /// </param>
        /// <param name="hwndParent">A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the device information set. This handle is optional and can be NULL.</param>
        /// <param name="flags">A variable of type DWORD that specifies control options that filter the device information elements that are added to the device information set. This parameter can be a bitwise OR of zero or more of the following flags.</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern Handle SetupDiGetClassDevs(ref Guid classGuid, string enumerator, IntPtr hwndParent, DIGCF flags);

        /// <summary>
        /// The SetupDiDestroyDeviceInfoList function deletes a device information set and frees all associated memory.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set to delete.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);

        /// <summary>
        /// The SetupDiEnumDeviceInfo function returns a SP_DEVINFO_DATA structure that specifies a device information element in a device information set.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set for which to return an SP_DEVINFO_DATA structure that represents a device information element.</param>
        /// <param name="memberIndex">A zero-based index of the device information element to retrieve.</param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure to receive information about an enumerated device information element. The caller must set DeviceInfoData.cbSize to sizeof(SP_DEVINFO_DATA).</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiEnumDeviceInfo(Handle deviceInfoSet, uint memberIndex, ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// The SetupDiGetDeviceRegistryProperty function retrieves a specified Plug and Play device property.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to a device information set that contains a device information element that represents the device for which to retrieve a Plug and Play property.</param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
        /// <param name="property">Specifies the property to be retrieved</param>
        /// <param name="propertyRegDataType">A pointer to a variable that receives the data type of the property that is being retrieved. This is one of the standard registry data types. This parameter is optional and can be NULL.</param>
        /// <param name="propertyBuffer">A pointer to a buffer that receives the property that is being retrieved. If this parameter is set to NULL, and PropertyBufferSize is also set to zero, the function returns the required size for the buffer in </param>
        /// <param name="propertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
        /// <param name="requiredSize">A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer that is required to hold the data for the requested property. This parameter is optional and can be </param>
        /// <returns>SetupDiGetDeviceRegistryProperty returns TRUE if the call was successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError. SetupDiGetDeviceRegistryProperty returns the ERROR_INVALID_DATA error code if the requested property does not exist for a device or if the property data is not valid.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiGetDeviceRegistryProperty(Handle deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData, SPDRP property, out RegistryValueKind propertyRegDataType, StringBuilder propertyBuffer, uint propertyBufferSize, out uint requiredSize);

        /// <summary>
        /// The SetupDiGetDeviceRegistryProperty function retrieves a specified Plug and Play device property.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to a device information set that contains a device information element that represents the device for which to retrieve a Plug and Play property.</param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
        /// <param name="property">Specifies the property to be retrieved</param>
        /// <param name="propertyRegDataType">A pointer to a variable that receives the data type of the property that is being retrieved. This is one of the standard registry data types. This parameter is optional and can be NULL.</param>
        /// <param name="propertyBuffer">A pointer to a buffer that receives the property that is being retrieved. If this parameter is set to NULL, and PropertyBufferSize is also set to zero, the function returns the required size for the buffer in </param>
        /// <param name="propertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
        /// <param name="requiredSize">A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer that is required to hold the data for the requested property. This parameter is optional and can be </param>
        /// <returns>SetupDiGetDeviceRegistryProperty returns TRUE if the call was successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError. SetupDiGetDeviceRegistryProperty returns the ERROR_INVALID_DATA error code if the requested property does not exist for a device or if the property data is not valid.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiGetDeviceRegistryProperty(Handle deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData, SPDRP property, ref RegistryValueKind propertyRegDataType, IntPtr propertyBuffer, uint propertyBufferSize, ref uint requiredSize);

        /// <summary>
        /// The SetupDiSetClassInstallParams function sets or clears class install parameters for a device information set or a particular device information element.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set for which to set class install parameters.</param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that represents the device for which to set class install parameters. This parameter is optional and can be NULL. If this parameter is specified, SetupDiSetClassInstallParams sets the class installation parameters for the specified device. If this parameter is NULL, SetupDiSetClassInstallParams sets the class install parameters that are associated with DeviceInfoSet.</param>
        /// <param name="classInstallParams">A pointer to a buffer that contains the new class install parameters to use. The SP_CLASSINSTALL_HEADER structure at the beginning of this buffer must have its cbSize field set to sizeof(SP_CLASSINSTALL_HEADER) and the InstallFunction field must be set to the DI_FUNCTION code that reflects the type of parameters contained in the rest of the buffer. </param>
        /// <param name="classInstallParamsSize">The size, in bytes, of the ClassInstallParams buffer. If the buffer is not supplied (that is, the class install parameters are being cleared), ClassInstallParamsSize must be 0.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiSetClassInstallParams(Handle deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData, [In] ref SP_PROPCHANGE_PARAMS classInstallParams, uint classInstallParamsSize);

        /// <summary>
        /// The SetupDiCallClassInstaller function calls the appropriate class installer, and any registered co-installers, with the specified installation request (DIF code).
        /// </summary>
        /// <param name="installFunction">The device installation request (DIF request) to pass to the co-installers and class installer. DIF codes have the format DIF_XXX and are defined in Setupapi.h. See Device Installation Function Codes for more information.</param>
        /// <param name="deviceInfoSet">A handle to a device information set for the local computer. This set contains a device installation element which represents the device for which to perform the specified installation function. </param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in the DeviceInfoSet that represents the device for which to perform the specified installation function. This parameter is optional and can be set to NULL. If this parameter is specified, SetupDiCallClassInstaller performs the specified function on the DeviceInfoData element. If DeviceInfoData is NULL, </param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiCallClassInstaller(DIF installFunction, Handle deviceInfoSet, [In]ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// The SetupDiChangeState function is the default handler for the DIF_PROPERTYCHANGE installation request.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to a device information set for the local computer. This set contains a device information element that represents the device whose state is to be changed. </param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT parameter because DeviceInfoData.DevInst might be updated with a new handle value upon return.</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiChangeState(Handle deviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// The SetupDiGetDeviceInstallParams function retrieves device installation parameters for a device information set or a particular device information element.
        /// </summary>
        /// <param name="deviceInfoSet">A handle to the device information set that contains the device installation parameters to retrieve.</param>
        /// <param name="deviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is optional and can be NULL. If this parameter is specified, SetupDiGetDeviceInstallParams retrieves the installation parameters for the specified device. If this parameter is NULL, the function retrieves the global device installation parameters that are associated with DeviceInfoSet.</param>
        /// <param name="deviceInstallParams">A pointer to an SP_DEVINSTALL_PARAMS structure that receives the device install parameters. DeviceInstallParams.cbSize must be set to the size, in bytes, of the structure before calling this function.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool SetupDiGetDeviceInstallParams(Handle deviceInfoSet, [In] ref SP_DEVINFO_DATA deviceInfoData, ref SP_DEVINSTALL_PARAMS deviceInstallParams);

        /// <summary>
        /// The CM_Get_DevNode_Status function obtains the status of a device instance from its device node (devnode) in the local machine's device tree.
        /// </summary>
        /// <param name="pulStatus">Address of a location to receive status bit flags. The function can set any combination of the DN_-prefixed bit flags defined in Cfg.h.</param>
        /// <param name="pulProblemNumber">Address of a location to receive one of the CM_PROB_-prefixed problem values defined in Cfg.h. Used only if DN_HAS_PROBLEM is set in pulStatus.</param>
        /// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
        /// <param name="ulFlags">Not used, must be zero.</param>
        /// <returns>If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern CM_ERROR CM_Get_DevNode_Status(out DN pulStatus, out CM_PROB pulProblemNumber, uint dnDevInst, uint ulFlags);
    }
}
