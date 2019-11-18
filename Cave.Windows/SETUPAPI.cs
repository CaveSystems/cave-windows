#region CopyRight 2018
/*
    Copyright (c) 2003-2018 Andreas Rohleder (andreas@rohleder.cc)
    All rights reserved
*/
#endregion
#region License MSPL
/*
    This file contains some sourcecode that uses Microsoft Windows API calls
    to provide functionality that is part of the underlying operating system.
    The API calls and their documentation are copyrighted work of Microsoft
    and/or its suppliers. Use of the Software is governed by the terms of the
    MICROSOFT LIMITED PUBLIC LICENSE.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE.MSPL file
    found at the installation directory or the distribution package.
*/
#endregion
#region License LGPL-3
/*
    This program/library/sourcecode is free software; you can redistribute it
    and/or modify it under the terms of the GNU Lesser General Public License
    version 3 as published by the Free Software Foundation subsequent called
    the License.

    You may not use this program/library/sourcecode except in compliance
    with the License. The License is included in the LICENSE file
    found at the installation directory or the distribution package.

    Permission is hereby granted, free of charge, to any person obtaining
    a copy of this software and associated documentation files (the
    "Software"), to deal in the Software without restriction, including
    without limitation the rights to use, copy, modify, merge, publish,
    distribute, sublicense, and/or sell copies of the Software, and to
    permit persons to whom the Software is furnished to do so, subject to
    the following conditions:

    The above copyright notice and this permission notice shall be included
    in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
    MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
    LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
    OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
    WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion License
#region Authors & Contributors
/*
   Information source:
     Microsoft Corporation

   Implementation:
     Andreas Rohleder <andreas@rohleder.cc>

   Contributors:
 */
#endregion

#if !NETSTANDARD20

using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// The Setup API provides a set of functions that a setup application calls to perform installation operations.
    /// </summary>
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
            Handle m_Handle;
            SP_DEVINFO_DATA m_DeviceInfo;
            //chache variables
            string m_Description;
            string m_HardwareID;
            string m_FriendlyName;
            string m_LocationInformation;
            string m_UINumber;

            #region private implementation
            string GetString(SPDRP property)
            {
                StringBuilder resultString = new StringBuilder(KERNEL32.DefaultStructBufferSize);
                RegistryValueKind valueKind;
                uint l_RequiredSize;
                SP_DEVINFO_DATA l_DevInfo = m_DeviceInfo;
                bool result = SETUPAPI.SetupDiGetDeviceRegistryProperty(m_Handle, ref l_DevInfo, property, out valueKind, resultString, (uint)resultString.Capacity, out l_RequiredSize);
                if (!result)
                {
                    int l_Error = Marshal.GetLastWin32Error();
                    if (l_Error == 13) return null;
                    if (l_Error != 0) throw new Win32ErrorException(l_Error);
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
                IntPtr ptr = Marshal.AllocHGlobal(KERNEL32.DefaultStructBufferSize);
                try
                {
                    RegistryValueKind valueKind = new RegistryValueKind();
                    uint l_RequiredSize = 0;
                    SP_DEVINFO_DATA l_DevInfo = m_DeviceInfo;
                    bool result = SetupDiGetDeviceRegistryProperty(m_Handle, ref l_DevInfo, property, ref valueKind, ptr, (uint)KERNEL32.DefaultStructBufferSize, ref l_RequiredSize);
                    if (!result)
                    {
                        int l_Error = Marshal.GetLastWin32Error();
                        if (l_Error == 13) return null;
                        if (l_Error != 0) throw new Win32ErrorException(l_Error);
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
                    string str = Marshal.PtrToStringAuto(ptr, (int)l_RequiredSize - 1);
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
                m_Handle = handle;
                m_DeviceInfo = devInfo;
            }
            #endregion

            #region public (readonly) properties
            /// <summary>
            /// Obtains the node (number)
            /// </summary>
            public uint DeviceNode { get { return m_DeviceInfo.DevInst; } }

            /// <summary>
            /// Obtains the ClassGuid
            /// </summary>
            public Guid ClassGuid { get { return m_DeviceInfo.ClassGuid; } }

            /// <summary>
            /// Obtains the device description
            /// </summary>
            public string Description
            {
                get
                {
                    if (m_Description == null) m_Description = GetString(SPDRP.DEVICEDESC);
                    return m_Description;
                }
            }

            /// <summary>
            /// Obtains the hardware id (multiple devices can have the same hardware id e.g. processor cores)
            /// </summary>
            public string HardwareID
            {
                get
                {
                    if (m_HardwareID == null) m_HardwareID = GetString(SPDRP.HARDWAREID);
                    return m_HardwareID;
                }
            }

            /// <summary>
            /// Provides the "human readable" user friendly name of the device
            /// </summary>
            public string FriendlyName
            {
                get
                {
                    if (m_FriendlyName == null) m_FriendlyName = GetString(SPDRP.FRIENDLYNAME);
                    return m_FriendlyName;
                }
            }

            /// <summary>
            /// Obtains the device location
            /// </summary>
            public string LocationInformation
            {
                get
                {
                    if (m_LocationInformation == null) m_LocationInformation = GetString(SPDRP.LOCATION_INFORMATION);
                    return m_LocationInformation;
                }
            }

            /// <summary>
            /// Obtains the ui number of the device (if set, this can be a slot- or portnumber)
            /// </summary>
            public string UINumber
            {
                get
                {
                    if (m_UINumber == null) m_UINumber = GetString(SPDRP.UI_NUMBER);
                    return m_UINumber;
                }
            }

            /// <summary>
            /// Checks whether the device is enabled or not.
            /// </summary>
            public bool Enabled
            {
                get
                {
                    DN l_Status;
                    CM_PROB l_ProblemCode;
                    CM_ERROR l_ErrorCode = CM_Get_DevNode_Status(out l_Status, out l_ProblemCode, m_DeviceInfo.DevInst, 0);
                    if (l_ErrorCode != 0) throw new Win32ConfigManagerException(l_ErrorCode);
                    return l_ProblemCode == 0;
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
                SP_PROPCHANGE_PARAMS p = new SP_PROPCHANGE_PARAMS();
                p.ClassInstallHeader.cbSize = (uint)Marshal.SizeOf(p.ClassInstallHeader);
                p.ClassInstallHeader.InstallFunction = installFunction;
                p.StateChange = stateChange;
                p.Scope = scope;
                p.HwProfile = hardwareProfile;
                SP_DEVINFO_DATA l_DeviceInfo = m_DeviceInfo;
                { //Set parameters
                    if (!SetupDiSetClassInstallParams(m_Handle, ref l_DeviceInfo, ref p, (uint)Marshal.SizeOf(p))) throw new Win32ErrorException();
                    KERNEL32.CheckLastError();
                }
                { //Run change
                    if (!SetupDiChangeState(m_Handle, ref l_DeviceInfo)) throw new Win32ErrorException();
                    KERNEL32.CheckLastError();
                }
                //if (!SetupDiCallClassInstaller(installFunction, m_Handle, ref l_DeviceInfo))
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
                StringBuilder result = new StringBuilder();
                if (!string.IsNullOrEmpty(Description))
                {
                    result.Append(Description);
                }
                else
                {
                    result.AppendFormat("Node {0} Class {1}", DeviceNode, ClassGuid);
                }
                if (!string.IsNullOrEmpty(FriendlyName)) result.AppendFormat(" '{0}'", FriendlyName);
                if (!string.IsNullOrEmpty(HardwareID)) result.AppendFormat(" [{0}]", HardwareID);
                return result.ToString();
            }

            /// <summary>
            /// Checks two instances for equality
            /// </summary>
            /// <param name="obj">Another DEVICE instance</param>
            /// <returns>Returns true if both instances have the same ClassGuid and DeviceNode</returns>
            public override bool Equals(object obj)
            {
                DEVICE other = obj as DEVICE;
                if (object.ReferenceEquals(null, other)) return false;
                return (other.DeviceNode == DeviceNode) && (other.ClassGuid == ClassGuid);
            }

            /// <summary>
            /// Obtains the device node number
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return (int)DeviceNode;
            }
            #endregion
        }

        /// <summary>
        /// Obtains a list of all present (active and inactive) devices
        /// </summary>
        /// <returns>Returns an array of <see cref="DEVICE"/>s</returns>
        public static DEVICE[] GetAllPresentDevices()
        {
            List<DEVICE> l_Devices = new List<DEVICE>();
            Guid l_Guid = new Guid();
            Handle handle = SETUPAPI.SetupDiGetClassDevs(ref l_Guid, null, IntPtr.Zero, DIGCF.ALLCLASSES | DIGCF.PRESENT);
            if (handle.IsInvalid) throw new Win32ErrorException();
            SP_DEVINFO_DATA info = new SP_DEVINFO_DATA();
            info.cbSize = (uint)Marshal.SizeOf(info);
            for (uint i = 0; SETUPAPI.SetupDiEnumDeviceInfo(handle, i, ref info); i++)
            {
                DEVICE l_Device = new DEVICE(handle, info);
                l_Devices.Add(l_Device);
            }
            return l_Devices.ToArray();
        }

        /// <summary>
        /// The SetupDiGetClassDevs function returns a handle to a device information set that contains requested device information elements for a local computer. <br />
        /// To return only devices that are present in the system, set the DIGCF_PRESENT flag.
        /// </summary>
        /// <param name="ClassGuid">A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be NULL. For more information about how to set ClassGuid, see the following Remarks section.</param>
        /// <param name="Enumerator">A pointer to a NULL-terminated string that specifies:
        /// <list type="bullet">
        /// <item>An identifier (ID) of a Plug and Play (PnP) enumerator. This ID can either be the value's globally unique identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".</item>
        /// <item>A PnP device instance ID. When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.</item>
        /// </list>
        /// This pointer is optional and can be NULL. If an enumeration value is not used to select devices, set Enumerator to NULL
        /// </param>
        /// <param name="hwndParent">A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the device information set. This handle is optional and can be NULL.</param>
        /// <param name="Flags">A variable of type DWORD that specifies control options that filter the device information elements that are added to the device information set. This parameter can be a bitwise OR of zero or more of the following flags.</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern Handle SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, IntPtr hwndParent, DIGCF Flags);

        /// <summary>
        /// The SetupDiDestroyDeviceInfoList function deletes a device information set and frees all associated memory.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to the device information set to delete.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        /// <summary>
        /// The SetupDiEnumDeviceInfo function returns a SP_DEVINFO_DATA structure that specifies a device information element in a device information set.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to the device information set for which to return an SP_DEVINFO_DATA structure that represents a device information element.</param>
        /// <param name="MemberIndex">A zero-based index of the device information element to retrieve.</param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure to receive information about an enumerated device information element. The caller must set DeviceInfoData.cbSize to sizeof(SP_DEVINFO_DATA).</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiEnumDeviceInfo(Handle DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);

        /// <summary>
        /// The SetupDiGetDeviceRegistryProperty function retrieves a specified Plug and Play device property.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to a device information set that contains a device information element that represents the device for which to retrieve a Plug and Play property.</param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
        /// <param name="Property">Specifies the property to be retrieved</param>
        /// <param name="PropertyRegDataType">A pointer to a variable that receives the data type of the property that is being retrieved. This is one of the standard registry data types. This parameter is optional and can be NULL.</param>
        /// <param name="PropertyBuffer">A pointer to a buffer that receives the property that is being retrieved. If this parameter is set to NULL, and PropertyBufferSize is also set to zero, the function returns the required size for the buffer in </param>
        /// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
        /// <param name="RequiredSize">A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer that is required to hold the data for the requested property. This parameter is optional and can be </param>
        /// <returns>SetupDiGetDeviceRegistryProperty returns TRUE if the call was successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError. SetupDiGetDeviceRegistryProperty returns the ERROR_INVALID_DATA error code if the requested property does not exist for a device or if the property data is not valid.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiGetDeviceRegistryProperty(Handle DeviceInfoSet, [In] ref SP_DEVINFO_DATA DeviceInfoData, SPDRP Property, out RegistryValueKind PropertyRegDataType, StringBuilder PropertyBuffer, uint PropertyBufferSize, out uint RequiredSize);

        /// <summary>
        /// The SetupDiGetDeviceRegistryProperty function retrieves a specified Plug and Play device property.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to a device information set that contains a device information element that represents the device for which to retrieve a Plug and Play property.</param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet.</param>
        /// <param name="Property">Specifies the property to be retrieved</param>
        /// <param name="PropertyRegDataType">A pointer to a variable that receives the data type of the property that is being retrieved. This is one of the standard registry data types. This parameter is optional and can be NULL.</param>
        /// <param name="PropertyBuffer">A pointer to a buffer that receives the property that is being retrieved. If this parameter is set to NULL, and PropertyBufferSize is also set to zero, the function returns the required size for the buffer in </param>
        /// <param name="PropertyBufferSize">The size, in bytes, of the PropertyBuffer buffer.</param>
        /// <param name="RequiredSize">A pointer to a variable of type DWORD that receives the required size, in bytes, of the PropertyBuffer buffer that is required to hold the data for the requested property. This parameter is optional and can be </param>
        /// <returns>SetupDiGetDeviceRegistryProperty returns TRUE if the call was successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError. SetupDiGetDeviceRegistryProperty returns the ERROR_INVALID_DATA error code if the requested property does not exist for a device or if the property data is not valid.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiGetDeviceRegistryProperty(Handle DeviceInfoSet, [In] ref SP_DEVINFO_DATA DeviceInfoData, SPDRP Property, ref RegistryValueKind PropertyRegDataType, IntPtr PropertyBuffer, uint PropertyBufferSize, ref uint RequiredSize);

        /// <summary>
        /// The SetupDiSetClassInstallParams function sets or clears class install parameters for a device information set or a particular device information element.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to the device information set for which to set class install parameters.</param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that represents the device for which to set class install parameters. This parameter is optional and can be NULL. If this parameter is specified, SetupDiSetClassInstallParams sets the class installation parameters for the specified device. If this parameter is NULL, SetupDiSetClassInstallParams sets the class install parameters that are associated with DeviceInfoSet.</param>
        /// <param name="ClassInstallParams">A pointer to a buffer that contains the new class install parameters to use. The SP_CLASSINSTALL_HEADER structure at the beginning of this buffer must have its cbSize field set to sizeof(SP_CLASSINSTALL_HEADER) and the InstallFunction field must be set to the DI_FUNCTION code that reflects the type of parameters contained in the rest of the buffer. </param>
        /// <param name="ClassInstallParamsSize">The size, in bytes, of the ClassInstallParams buffer. If the buffer is not supplied (that is, the class install parameters are being cleared), ClassInstallParamsSize must be 0.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiSetClassInstallParams(Handle DeviceInfoSet, [In] ref SP_DEVINFO_DATA DeviceInfoData, [In] ref SP_PROPCHANGE_PARAMS ClassInstallParams, uint ClassInstallParamsSize);

        /// <summary>
        /// The SetupDiCallClassInstaller function calls the appropriate class installer, and any registered co-installers, with the specified installation request (DIF code).
        /// </summary>
        /// <param name="InstallFunction">The device installation request (DIF request) to pass to the co-installers and class installer. DIF codes have the format DIF_XXX and are defined in Setupapi.h. See Device Installation Function Codes for more information.</param>
        /// <param name="DeviceInfoSet">A handle to a device information set for the local computer. This set contains a device installation element which represents the device for which to perform the specified installation function. </param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in the DeviceInfoSet that represents the device for which to perform the specified installation function. This parameter is optional and can be set to NULL. If this parameter is specified, SetupDiCallClassInstaller performs the specified function on the DeviceInfoData element. If DeviceInfoData is NULL, </param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiCallClassInstaller(DIF InstallFunction, Handle DeviceInfoSet, [In]ref SP_DEVINFO_DATA DeviceInfoData);

        /// <summary>
        /// The SetupDiChangeState function is the default handler for the DIF_PROPERTYCHANGE installation request.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to a device information set for the local computer. This set contains a device information element that represents the device whose state is to be changed. </param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This is an IN-OUT parameter because DeviceInfoData.DevInst might be updated with a new handle value upon return.</param>
        /// <returns></returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiChangeState(Handle DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData);

        /// <summary>
        /// The SetupDiGetDeviceInstallParams function retrieves device installation parameters for a device information set or a particular device information element.
        /// </summary>
        /// <param name="DeviceInfoSet">A handle to the device information set that contains the device installation parameters to retrieve.</param>
        /// <param name="DeviceInfoData">A pointer to an SP_DEVINFO_DATA structure that specifies the device information element in DeviceInfoSet. This parameter is optional and can be NULL. If this parameter is specified, SetupDiGetDeviceInstallParams retrieves the installation parameters for the specified device. If this parameter is NULL, the function retrieves the global device installation parameters that are associated with DeviceInfoSet.</param>
        /// <param name="DeviceInstallParams">A pointer to an SP_DEVINSTALL_PARAMS structure that receives the device install parameters. DeviceInstallParams.cbSize must be set to the size, in bytes, of the structure before calling this function.</param>
        /// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved by making a call to GetLastError.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetupDiGetDeviceInstallParams(Handle DeviceInfoSet, [In] ref SP_DEVINFO_DATA DeviceInfoData, ref SP_DEVINSTALL_PARAMS DeviceInstallParams);

        /// <summary>
        /// The CM_Get_DevNode_Status function obtains the status of a device instance from its device node (devnode) in the local machine's device tree.
        /// </summary>
        /// <param name="pulStatus">Address of a location to receive status bit flags. The function can set any combination of the DN_-prefixed bit flags defined in Cfg.h.</param>
        /// <param name="pulProblemNumber">Address of a location to receive one of the CM_PROB_-prefixed problem values defined in Cfg.h. Used only if DN_HAS_PROBLEM is set in pulStatus.</param>
        /// <param name="dnDevInst">Caller-supplied device instance handle that is bound to the local machine.</param>
        /// <param name="ulFlags">Not used, must be zero.</param>
        /// <returns>If the operation succeeds, the function returns CR_SUCCESS. Otherwise, it returns one of the CR_-prefixed error codes defined in Cfgmgr32.h.</returns>
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern CM_ERROR CM_Get_DevNode_Status(out DN pulStatus, out CM_PROB pulProblemNumber, uint dnDevInst, uint ulFlags);
    }
}

#endif