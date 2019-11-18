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

//ignore missing comments on this file
//TODO add missing comments
#pragma warning disable 1591

using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Native interface to the IPHLPAPI.DLL
    /// </summary>
    public static class IPHLPAPI
    {
        public const int MAXLEN_PHYSADDR = 8;

        #region Enums

        public enum AF_INET
        {
            IP4 = 2,
            IP6 = 23
        }

        public enum MIB_TCP_STATE
        {
            CLOSED = 1,
            LISTENING,
            SYN_SENT,
            SYN_RCVD,
            ESTABLISHED,
            FIN_WAIT1,
            FIN_WAIT2,
            CLOSE_WAIT,
            CLOSING,
            LAST_ACK,
            TIME_WAIT,
            DELETE_TCB
        }

        public enum TCtable_CLASS
        {
            BASIC_LISTENER,
            BASIC_CONNECTIONS,
            BASIC_ALL,
            OWNER_PID_LISTENER,
            OWNER_PID_CONNECTIONS,
            OWNER_PID_ALL,
            OWNER_MODULE_LISTENER,
            OWNER_MODULE_CONNECTIONS,
            OWNER_MODULE_ALL
        }

        public enum UDtable_CLASS
        {
            BASIC,
            OWNER_PID,
            OWNER_MODULE
        }

        public enum TCPIP_OWNER_MODULE_INFO_CLASS
        {
            BASIC
        }

        #endregion

        #region structs

        public interface OWNER_MODULE { }

        [StructLayout(LayoutKind.Sequential)]
        public class Owner
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ModuleName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string ModulePath;
        }

        public enum MIB_IPNET_TYPE : uint
        {
            UNDEFINED = 0,
            OTHER = 1,
            INVALID = 2,
            DYNAMIC = 3,
            STATIC = 4,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_IPNETROW
        {
            public uint Index;

            public uint PhysAddrLength;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
            public byte[] PhysAddr;

            public uint Address;

            [MarshalAs(UnmanagedType.U4)]
            public MIB_IPNET_TYPE Type;

            public string MAC
            {
                get
                {
                    StringBuilder result = new StringBuilder();
                    for (int i = 0; i < PhysAddrLength; i++)
                    {
                        if (i > 0) result.Append('-');
                        result.Append(PhysAddr[i].ToString("X2"));
                    }
                    return result.ToString();
                }
            }

            public override string ToString()
            {
                StringBuilder result = new StringBuilder();
                result.Append(Type);
                result.Append(" <");
                result.Append(new IPAddress(Address));
                result.Append("> [");
                for (int i = 0; i < PhysAddrLength; i++)
                {
                    if (i > 0) result.Append('-');
                    result.Append(PhysAddr[i].ToString("X2"));
                }
                result.Append("]");
                return result.ToString();
            }
        }

        #region tcp v4
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPROW_OWNER_MODULE : OWNER_MODULE
        {
            public uint State;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]

            public byte[] LocalAddressBytes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            
            public byte[] LocalPortBytes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]

            public byte[] RemoteAddressBytes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]

            byte[] RemotePortBytes;

            public uint OwningPid;

            public long CreationFileTime;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public ulong[] OwningModuleInfo;

            public IPAddress RemoteAddress { get { return new IPAddress(RemoteAddressBytes); } }

            public IPAddress LocalAddress { get { return new IPAddress(LocalAddressBytes); } }

            public int RemotePort { get { return GetPort(RemotePortBytes); } }

            public int LocalPort { get { return GetPort(LocalPortBytes); } }

            public Owner Owner { get { return GetOwner(this); } }

            public DateTime CreationTime { get { return CreationFileTime == 0 ? default(DateTime) : DateTime.FromFileTime(CreationFileTime); } }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MIB_TCPTABLE_OWNER_MODULE
        {
            public uint NumEntries;
            public MIB_TCPROW_OWNER_MODULE FirstEntry;
        }
        #endregion

        #region udp v4
        /// <summary>
        /// The MIB_UDPROW_OWNER_MODULE structure contains an entry from the IPv4 User Datagram Protocol (UDP) listener table on the local computer. This entry also also includes any available ownership data and the process ID (PID) that issued the call to the bind function for the UDP endpoint.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_UDPROW_OWNER_MODULE : OWNER_MODULE
        {
            /// <summary>
            /// The IPv4 address of the UDP endpoint on the local computer. 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalAddressBytes;

            /// <summary>
            /// The port number of the UDP endpoint on the local computer. This member is stored in network byte order.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] LocalPortBytes;

            /// <summary>
            /// The PID of the process that issued the call to the bind function for the UDP endpoint. This member is set to 0 when the PID is unavailable.
            /// </summary>
            public uint OwningPid;

            /// <summary>
            /// A SYSTEMTIME structure that indicates when the call to the bind function for the UDP endpoint occurred.
            /// </summary>
            public long CreationFileTime;
            
            /// <summary>
            /// A set of flags. This member is not currently used.
            /// </summary>
            public int Flags;
            
            /// <summary>
            /// An array of opaque data that contains ownership information.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] 
            public ulong[] OwningModuleInfo;

            public IPAddress LocalAddress { get { return new IPAddress(LocalAddressBytes); } }

            public int LocalPort { get { return GetPort(LocalPortBytes); } }

            public Owner Owner { get { return GetOwner(this); } }

            public DateTime CreationTime { get { return CreationFileTime == 0 ? default(DateTime) : DateTime.FromFileTime(CreationFileTime); } }
        }

        /// <summary>
        /// The MIB_UDPTABLE_OWNER_MODULE structure contains the User Datagram Protocol (UDP) listener table for IPv4 on the local computer. The table also includes any available ownership data and the process ID (PID) that issued the call to the bind function for each UDP endpoint.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct MIB_UDPTABLE_OWNER_MODULE
        {
            /// <summary>
            /// The number of MIB_UDPROW_OWNER_MODULE elements in table.
            /// </summary>
            public uint NumEntries;

            /// <summary>
            /// An array of MIB_UDPROW_OWNER_MODULE structures returned by a call to GetExtendedUdpTable.
            /// </summary>
            public MIB_UDPROW_OWNER_MODULE FirstEntry;
        }
        #endregion

        #region tcp v6
        /// <summary>
        /// The MIB_TCP6ROW_OWNER_MODULE structure contains information that describes an IPv6 TCP connection bound to a specific process ID (PID) with ownership data.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MIB_TCP6ROW_OWNER_MODULE : OWNER_MODULE
        {
            /// <summary>
            /// The IPv6 address for the local endpoint of the TCP connection on the local computer. A value of zero indicates the listener can accept a connection on any interface.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] _localAddress;

            /// <summary>
            /// The scope ID in network byte order for the local IPv6 address.
            /// </summary>
            public uint LocalScopeId;

            /// <summary>
            /// The port number in network byte order for the local endpoint of the TCP connection on the local computer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] _localPort;

            /// <summary>
            /// The IPv6 address of the remote endpoint of the TCP connection on the remote computer. When the dwState member is MIB_TCP_STATE_LISTEN, this value has no meaning. 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] _remoteAddress;

            /// <summary>
            /// The scope ID in network byte order for the remote IPv6 address.
            /// </summary>
            public uint RemoteScopeId;

            /// <summary>
            /// The port number in network byte order for the remote endpoint of the TCP connection on the remote computer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] _remotePort;

            /// <summary>
            /// The state of the TCP connection. This member can be one of the values from the MIB_TCP_STATE enumeration defined in the Tcpmib.h header file. Note that the Tcpmib.h header file is automatically included in Iprtrmib.h, which is automatically included in the Iphlpapi.h header file. The Tcpmib.h and Iprtrmib.h header files should never be used directly. 
            /// </summary>
            public uint State;

            /// <summary>
            /// The PID of the local process that issued a context bind for this TCP connection. 
            /// </summary>
            public uint OwningPid;

            /// <summary>
            /// A SYSTEMTIME structure that indicates when the context bind operation that created this TCP connection occurred.
            /// </summary>
            long _creationTime;

            /// <summary>
            /// An array of opaque data that contains ownership information.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public ulong[] OwningModuleInfo;

            public IPAddress LocalAddress { get { return new IPAddress(_localAddress); } }

            public int LocalPort { get { return GetPort(_localPort); } }

            public IPAddress RemoteAddress { get { return new IPAddress(_remoteAddress); } }
            public int RemotePort { get { return GetPort(_remotePort); } }

            public Owner OwnerModule { get { return GetOwner(this); } }

            public DateTime CreationTime { get { return _creationTime == 0 ? default(DateTime) : DateTime.FromFileTime(_creationTime); } }
        }

        /// <summary>
        /// The MIB_TCP6TABLE_OWNER_MODULE structure contains a table of process IDs (PIDs) and the IPv6 TCP links context bound to these PIDs with any available ownership data.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct MIB_TCP6TABLE_OWNER_MODULE
        {
            /// <summary>
            /// The number of MIB_TCP6ROW_OWNER_MODULE elements in the table.
            /// </summary>
            public uint NumEntries;

            /// <summary>
            /// Array of MIB_TCP6ROW_OWNER_MODULE structures returned by a call to GetExtendedTcpTable.
            /// </summary>
            public MIB_TCP6ROW_OWNER_MODULE FirstEntry;
        }
        #endregion

        #region udp v6

        /// <summary>
        /// The MIB_UDP6ROW_OWNER_MODULE structure contains an entry from the User Datagram Protocol (UDP) listener table for IPv6 on the local computer. This entry also also includes any available ownership data and the process ID (PID) that issued the call to the bind function for the UDP endpoint.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_UDP6ROW_OWNER_MODULE : OWNER_MODULE
        {
            /// <summary>
            /// The IPv6 address of the UDP endpoint on the local computer. This member is stored in a character array in network byte order.
            /// A value of zero indicates a UDP listener willing to accept datagrams for any IP interface associated with the local computer.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] _localAddress;

            /// <summary>
            /// The scope ID for the IPv6 address of the UDP endpoint on the local computer.
            /// </summary>
            public uint LocalScopeId;

            /// <summary>
            /// The port number for the local UDP endpoint.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            byte[] _localPort;

            /// <summary>
            /// The PID of the process that issued a context bind for this endpoint. If this value is set to 0, the information for this endpoint is unavailable.
            /// </summary>
            public uint OwningPid;

            /// <summary>
            /// A SYSTEMTIME structure that indicates when the context bind operation that created this endpoint occurred.
            /// </summary>
            long _creationTime;

            /// <summary>
            /// A set of flags. This member is not currently used.
            /// </summary>
            public int Flags;

            /// <summary>
            /// An array of opaque data that contains ownership information.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] //FieldOffset(32), 
            public ulong[] OwningModuleInfo;

            public IPAddress LocalAddress { get { return new IPAddress(_localAddress); } }

            public int LocalPort { get { return GetPort(_localPort); } }

            public Owner OwnerModule { get { return GetOwner(this); } }

            public DateTime CreationTime { get { return _creationTime == 0 ? default(DateTime) : DateTime.FromFileTime(_creationTime); } }
        }

        /// <summary>
        /// The MIB_UDP6TABLE_OWNER_MODULE structure contains the User Datagram Protocol (UDP) listener table for IPv6 on the local computer. The table also includes any available ownership data and the process ID (PID) that issued the call to the bind function for each UDP endpoint.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct MIB_UDP6TABLE_OWNER_MODULE
        {
            /// <summary>
            /// The number of MIB_UDP6ROW_OWNER_MODULE elements in table.
            /// </summary>
            public uint NumEntries;

            /// <summary>
            /// An array of MIB_UDP6ROW_OWNER_MODULE structures returned by a call to GetExtendedUdpTable.
            /// </summary>
            public MIB_UDP6ROW_OWNER_MODULE FirstEntry;
        }
        #endregion

        #endregion

        static int GetPort(byte[] portBytes)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(portBytes, 0));
        }

        public static Owner GetOwningModuleTCP(MIB_TCPROW_OWNER_MODULE row)
        {
            int size = 0;
            SafeNativeMethods.GetOwnerModuleFromTcpEntry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, IntPtr.Zero, ref size);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                ErrorCode l_Error = SafeNativeMethods.GetOwnerModuleFromTcpEntry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, buffer, ref size);
                if (l_Error != ErrorCode.NO_ERROR) throw new Win32ErrorException(l_Error);
                Owner l_Owner = new Owner();
                Marshal.PtrToStructure(buffer, l_Owner);
                return l_Owner;
            }
            finally { Marshal.FreeHGlobal(buffer); }
        }

        public static Owner GetOwningModuleUDP(MIB_UDPROW_OWNER_MODULE row)
        {
            int size = 0;
            SafeNativeMethods.GetOwnerModuleFromUdpEntry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, IntPtr.Zero, ref size);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                ErrorCode l_Error = SafeNativeMethods.GetOwnerModuleFromUdpEntry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, buffer, ref size);
                if (l_Error != ErrorCode.NO_ERROR) throw new Win32ErrorException(l_Error);
                Owner l_Owner = new Owner();
                Marshal.PtrToStructure(buffer, l_Owner);
                return l_Owner;
            }
            finally { Marshal.FreeHGlobal(buffer); }
        }

        public static Owner GetOwningModuleTCP(MIB_TCP6ROW_OWNER_MODULE row)
        {
            int size = 0;
            SafeNativeMethods.GetOwnerModuleFromTcp6Entry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, IntPtr.Zero, ref size);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                ErrorCode l_Error = SafeNativeMethods.GetOwnerModuleFromTcp6Entry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, buffer, ref size);
                if (l_Error != ErrorCode.NO_ERROR) throw new Win32ErrorException(l_Error);
                Owner l_Owner = new Owner();
                Marshal.PtrToStructure(buffer, l_Owner);
                return l_Owner;
            }
            finally { Marshal.FreeHGlobal(buffer); }
        }

        public static Owner GetOwningModuleUDP(MIB_UDP6ROW_OWNER_MODULE row)
        {
            int size = 0;
            SafeNativeMethods.GetOwnerModuleFromUdp6Entry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, IntPtr.Zero, ref size);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                ErrorCode l_Error = SafeNativeMethods.GetOwnerModuleFromUdp6Entry(ref row, TCPIP_OWNER_MODULE_INFO_CLASS.BASIC, buffer, ref size);
                if (l_Error != ErrorCode.NO_ERROR) throw new Win32ErrorException(l_Error);
                Owner l_Owner = new Owner();
                Marshal.PtrToStructure(buffer, l_Owner);
                return l_Owner;
            }
            finally { Marshal.FreeHGlobal(buffer); }
        }

        /// <summary>
        /// Gets the owner of a module
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static Owner GetOwner(OWNER_MODULE row)
        {

            if (row is MIB_TCPROW_OWNER_MODULE)
            {
                return GetOwningModuleTCP((MIB_TCPROW_OWNER_MODULE)row);
            }
            if (row is MIB_TCP6ROW_OWNER_MODULE)
            {
                return GetOwningModuleTCP((MIB_TCP6ROW_OWNER_MODULE)row);
            }
            if (row is MIB_UDPROW_OWNER_MODULE)
            {
                return GetOwningModuleUDP((MIB_UDPROW_OWNER_MODULE)row);
            }
            if (row is MIB_UDP6ROW_OWNER_MODULE)
            {
                return GetOwningModuleUDP((MIB_UDP6ROW_OWNER_MODULE)row);
            }
            throw new Exception("Unknown row type!");
        }

        public static MIB_IPNETROW[] GetArpTable()
        {
            int bufferSize = 0;
            ErrorCode apiResult = SafeNativeMethods.GetIpNetTable(IntPtr.Zero, ref bufferSize, false);
            if (apiResult !=  ErrorCode.INSUFFICIENT_BUFFER)
            {
                throw new Win32ErrorException(apiResult);
            }

            IntPtr buffer = Marshal.AllocCoTaskMem(bufferSize);
            try
            {
                apiResult = SafeNativeMethods.GetIpNetTable(buffer, ref bufferSize, false);
                if (apiResult != ErrorCode.NO_ERROR)
                {
                    throw new Win32ErrorException(apiResult);
                }
                //read number of entries (dword)
                int count = Marshal.ReadInt32(buffer);
                MIB_IPNETROW[] result = new MIB_IPNETROW[count];
                IntPtr l_ReadPtr = new IntPtr(buffer.ToInt64() + 4);
                int valueSize = Marshal.SizeOf(typeof(MIB_IPNETROW));
                for (int index = 0; index < count; index++)
                {
                    result[index] = (MIB_IPNETROW)Marshal.PtrToStructure(l_ReadPtr, typeof(MIB_IPNETROW));
                    l_ReadPtr = new IntPtr(l_ReadPtr.ToInt64() + valueSize);
                }
                return result;
            }
            finally
            {
                SafeNativeMethods.FreeMibTable(buffer);
            }
        }

        internal static class SafeNativeMethods
        {
            /// <summary>
            /// The GetOwnerModuleFromTcpEntry function retrieves data about the module that issued the context bind for a specific IPv4 TCP endpoint in a MIB table row.
            /// </summary>
            /// <param name="pTcpEntry">A pointer to a MIB_TCPROW_OWNER_MODULE structure that contains the IPv4 TCP endpoint entry used to obtain the owner module.</param>
            /// <param name="Class">This parameter must be set to TCPIP_OWNER_MODULE_INFO_BASIC.</param>
            /// <param name="Buffer">A pointer a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this buffer is indicated by the value of the Class parameter.</param>
            /// <param name="pdwSize">The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct size of the buffer. The size required is the size of the corresponding structure plus an additional number of bytes equal to the length of data pointed to in the structure (for example, the name and path strings).</param>
            /// <returns>If the function call is successful, the value NO_ERROR is returned.</returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetOwnerModuleFromTcpEntry(ref MIB_TCPROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr Buffer, ref int pdwSize);

            /// <summary>
            /// The GetOwnerModuleFromUdpEntry function retrieves data about the module that issued the context bind for a specific IPv4 UDP endpoint in a MIB table row.
            /// </summary>
            /// <param name="pUdpEntry">A pointer to a MIB_UDPROW_OWNER_MODULE structure that contains the IPv4 UDP endpoint entry used to obtain the owner module.</param>
            /// <param name="Class">A TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module.</param>
            /// <param name="Buffer">The buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this buffer is indicated by the value of the Class parameter.</param>
            /// <param name="pdwSize">The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct structure size.</param>
            /// <returns></returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetOwnerModuleFromUdpEntry(ref MIB_UDPROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr Buffer, ref int pdwSize);

            /// <summary>
            /// The GetOwnerModuleFromTcp6Entry function retrieves data about the module that issued the context bind for a specific IPv6 TCP endpoint in a MIB table row.
            /// </summary>
            /// <param name="pTcpEntry">A pointer to a MIB_TCP6ROW_OWNER_MODULE structure that contains the IPv6 TCP endpoint entry used to obtain the owner module.</param>
            /// <param name="Class">This parameter must be set to TCPIP_OWNER_MODULE_INFO_BASIC.</param>
            /// <param name="Buffer">A pointer to a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this buffer is indicated by the value of the Class parameter.</param>
            /// <param name="pdwSize">The estimated size of the structure returned in Buffer, in bytes. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct structure size.</param>
            /// <returns></returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetOwnerModuleFromTcp6Entry(ref MIB_TCP6ROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr Buffer, ref int pdwSize);

            /// <summary>
            /// The GetOwnerModuleFromUdp6Entry function retrieves data about the module that issued the context bind for a specific IPv6 UDP endpoint in a MIB table row.
            /// </summary>
            /// <param name="pUdpEntry">A pointer to a MIB_UDP6ROW_OWNER_MODULE structure that contains the IPv6 UDP endpoint entry used to obtain the owner module.</param>
            /// <param name="Class">TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module.</param>
            /// <param name="Buffer">The buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this buffer is indicated by the value of the Class parameter.</param>
            /// <param name="pdwSize">The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct size of the structure.</param>
            /// <returns></returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetOwnerModuleFromUdp6Entry(ref MIB_UDP6ROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr Buffer, ref int pdwSize);

            /// <summary>
            /// The GetExtendedTcpTable function retrieves a table that contains a list of TCP endpoints available to the application.
            /// </summary>
            /// <param name="pTcpTable">A pointer to the table structure that contains the filtered TCP endpoints available to the application. For information about how to determine the type of table returned based on specific input parameter combinations, see the Remarks section later in this document.</param>
            /// <param name="dwOutBufLen">The estimated size of the structure returned in pTcpTable, in bytes. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct size of the structure.</param>
            /// <param name="bOrder">A value that specifies whether the TCP connection table should be sorted. If this parameter is set to TRUE, the TCP endpoints in the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the TCP endpoints in the table appear in the order in which they were retrieved.</param>
            /// <param name="ulAf">The version of IP used by the TCP endpoint.</param>
            /// <param name="TableClass">The type of the TCP table structure to retrieve. This parameter can be one of the values from the TCtable_CLASS enumeration.</param>
            /// <param name="Reserved">Reserved. This value must be zero.</param>
            /// <returns></returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool bOrder, AF_INET ulAf, TCtable_CLASS TableClass, int Reserved);

            /// <summary>
            /// The GetExtendedUdpTable function retrieves a table that contains a list of UDP endpoints available to the application.
            /// </summary>
            /// <param name="pUdpTable">A pointer to the table structure that contains the filtered UDP endpoints available to the application. For information about how to determine the type of table returned based on specific input parameter combinations, see the Remarks section later in this document.</param>
            /// <param name="dwOutBufLen">The estimated size of the structure returned in pUdpTable, in bytes. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this function, and this field will contain the correct size of the structure.</param>
            /// <param name="bOrder">A value that specifies whether the UDP endpoint table should be sorted. If this parameter is set to TRUE, the UDP endpoints in the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the UDP endpoints in the table appear in the order in which they were retrieved.</param>
            /// <param name="ulAf">The version of IP used by the UDP endpoint.</param>
            /// <param name="TableClass">The type of the UDP table structure to retrieve. This parameter can be one of the values from the UDtable_CLASS enumeration.</param>
            /// <param name="Reserved">Reserved. This value must be zero.</param>
            /// <returns></returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetExtendedUdpTable(IntPtr pUdpTable, ref int dwOutBufLen, bool bOrder, AF_INET ulAf, UDtable_CLASS TableClass, int Reserved);

            /// <summary>
            /// The GetIpNetTable function retrieves the IPv4 to physical address mapping table.
            /// </summary>
            /// <param name="pIpNetTable">A pointer to a buffer that receives the IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</param>
            /// <param name="pdwSize">On input, specifies the size in bytes of the buffer pointed to by the pIpNetTable parameter. On output, if the buffer is not large enough to hold the returned mapping table, the function sets this parameter equal to the required buffer size in bytes.</param>
            /// <param name="bOrder">A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this parameter is TRUE, the table is sorted.</param>
            /// <returns>If the function succeeds, the return value is NO_ERROR or ERROR_NO_DATA.</returns>
            [DllImport("iphlpapi.dll", SetLastError = true)]
            public static extern ErrorCode GetIpNetTable(IntPtr pIpNetTable, [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);

            /// <summary>
            /// The FreeMibTable function frees the buffer allocated by the functions that return tables of network interfaces, addresses, and routes (GetIfTable2 and GetAnycastIpAddressTable, for example).
            /// </summary>
            /// <param name="plpNetTable">A pointer to the buffer to free.</param>
            [DllImport("IpHlpApi.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern void FreeMibTable(IntPtr plpNetTable);
        }
    }
}

#pragma warning restore 1591
