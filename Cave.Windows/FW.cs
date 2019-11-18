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

//ignore missing comments on this file
//TODO complete and add missing comments
#pragma warning disable 1591

using Cave.Net;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;

namespace Cave.Windows
{
    /// <summary>
    /// Firewall and Advanced Security Protocol
    /// https://msdn.microsoft.com/en-us/library/cc231461.aspx
    /// </summary>
    public class FW
    {
        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/cc231559.aspx
        /// </summary>
        public enum PROFILE_TYPE : uint
        {
            /// <summary>
            /// This value is invalid and MUST NOT be used. It is defined for simplicity in writing IDL definitions and code.
            /// </summary>
            Invalid = 0x000,

            /// <summary>
            /// This value represents the profile for networks that are connected to domains.
            /// </summary>
            Domain = 0x001,

            /// <summary>
            /// This value represents the standard profile for networks. These networks are classified as private by the administrators in the server host. The classification happens the first time the host connects to the network. Usually these networks are behind Network Address Translation (NAT) devices, routers, and other edge devices, and they are in a private location, such as a home or an office.
            /// </summary>
            Standard = 0x002,

            /// <summary>
            /// This value represents the profile for private networks, which is represented by the same value as that used for FW_PROFILE_TYPE_STANDARD.
            /// </summary>
            Private = 0x002,

            /// <summary>
            /// This value represents the profile for public networks. These networks are classified as public by the administrators in the server host. The classification happens the first time the host connects to the network. Usually these networks are those at airports, coffee shops, and other public places where the peers in the network or the network administrator are not trusted.
            /// </summary>
            Public = 0x004,

            /// <summary>
            /// This value represents all these network sets and any future network sets.
            /// </summary>
            All = 0x7FFFFFFF,

            /// <summary>
            /// This value represents the current profiles to which the firewall and advanced security components determine the host is connected at the moment of the call. This value can be specified only in method calls, and it cannot be combined with other flags. 
            /// </summary>
            Current = 0x80000000,

            /// <summary>
            /// This value represents no profile and is invalid. It is defined for simplicity in writing IDL definitions and code. This and greater values MUST NOT be used.
            /// </summary>
            None = 0x80000001,
        }

        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/cc231562.aspx
        /// </summary>
        [Flags]
        public enum RULE_FLAGS
        {
            /// <summary>
            /// This value means that none of the following flags are set. It is defined for simplicity in writing IDL definitions and code.
            /// </summary>
            NONE = 0x0000,

            /// <summary>
            /// The rule is enabled if this flag is set; otherwise, it is disabled.
            /// </summary>
            ACTIVE = 0x0001,

            /// <summary>
            /// This flag MUST be set only on rules that have the allow actions. If set, traffic that matches the rule is allowed only if it has been authenticated by IPsec; otherwise, traffic is blocked.
            /// </summary>
            AUTHENTICATE = 0x0002,

            /// <summary>
            /// This flag is similar to the FW_RULE_FLAGS_AUTHENTICATE flag; however, traffic MUST also be encrypted.
            /// </summary>
            AUTHENTICATE_WITH_ENCRYPTION = 0x0004,

            /// <summary>
            /// This flag MUST be set only on inbound rules. This flag allows the matching traffic to traverse a NAT edge device and be allowed in the host computer.
            /// </summary>
            ROUTEABLE_ADDRS_TRAVERSE = 0x0008,

            /// <summary>
            /// This flag allows responses from a remote IP address that is different from the one to which the outbound matched traffic originally went.
            /// </summary>
            LOOSE_SOURCE_MAPPED = 0x0010,

            /// <summary>
            /// This flag MUST be set only on rules that have the FW_RULE_FLAGS_AUTHENTICATE flag set. If set, traffic that matches the rule is allowed if IKE or AuthIP authentication was successful; however, this flag does not necessarily require that traffic be protected by IPsec encapsulations.
            /// </summary>
            AUTH_WITH_NO_ENCAPSULATION = 0x0020,

            /// <summary>
            /// This flag MUST be set only on inbound rules that have the FW_RULE_FLAGS_AUTHENTICATE_WITH_ENCRYPTION flag set. If set and if the first packet that arrives is unencrypted but authenticated by IPsec, the packet is allowed, and an IKE or AuthIP negotiation is started to negotiate encryption settings and encrypt subsequent packets. [MS-AIPS] section 3.2.4 specifies negotiation initiation behavior for hosts that support both IKE and AuthIP negotiation. If the negotiation fails, the connection is dropped.
            /// </summary>
            AUTH_WITH_ENC_NEGOTIATE = 0x0040,

            /// <summary>
            /// This flag MUST be set only on inbound rules. This flag allows the matching traffic to traverse a NAT edge device and be allowed in the host computer, if and only if a matching PortInUse object is found in the PortsInUse collection with NATTraversalRequested set to true
            /// </summary>
            ROUTEABLE_ADDRS_TRAVERSE_DEFER_APP = 0x0080,

            /// <summary>
            /// This flag MUST be set only on inbound rules. Whenever an application tries to listen for traffic that matches this rule, the operating system asks the administrator of the host whether it should allow this traffic to traverse the NAT.
            /// </summary>
            ROUTEABLE_ADDRS_TRAVERSE_DEFER_USER = 0x0100,

            /// <summary>
            /// This flag MUST be set only on outbound rules that have an allow action with either the FW_RULE_FLAGS_AUTHENTICATE or the FW_RULE_FLAGS_AUTHENTICATE_WITH_ENCRYPTION flag set. If set, this rule is evaluated before block rules, making it equivalent to a rule with an FW_RULE_ACTION_ALLOW_BYPASS, but for outbound.
            /// </summary>
            AUTHENTICATE_BYPASS_OUTBOUND = 0x0200,

            /// <summary>
            /// This flag allows responses from a network with a different profile type than the network to which the outbound traffic was originally sent. This flag MUST be ignored on rules with an action of FW_RULE_ACTION_BLOCK. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            ALLOW_PROFILE_CROSSING = 0x0400,

            /// <summary>
            /// If this flag is set on a rule, the remote address and remote port conditions are ignored when determining whether a network traffic flow matches the rule. This flag MUST be ignored on rules with an action of FW_RULE_ACTION_BLOCK. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            LOCAL_ONLY_MAPPED = 0x0800,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used. It is defined for simplicity in writing IDL definitions and code. This symbolic constant has a value of 0x1000.
            /// </summary>
            MAX = 0x1000,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x0201 and earlier. It is defined for simplicity in writing IDL definitions and code. This symbolic constant has a value of 0x0020.
            /// </summary>
            MAX_V2_1 = 0x0020,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x0209 and earlier. It is defined for simplicity in writing IDL definitions and code. This symbolic constant has a value of 0x0040.
            /// </summary>
            MAX_V2_9 = 0x0040,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x020A and earlier. It is defined for simplicity in writing IDL definitions and code. This symbolic constant has a value of 0x0800.
            /// </summary>
            MAX_V2_10 = 0x0800
        }

        public enum DIRECTION
        {
            /// <summary>
            /// This value is invalid and MUST NOT be used. 
            /// </summary>
            Invalid = 0,

            /// <summary>
            /// Incoming
            /// </summary>
            In,

            /// <summary>
            /// Outgoing
            /// </summary>
            Out,
        }

        /// <summary>
        /// This enumeration describes the possible actions on firewall rules.
        /// </summary>
        public enum RULE_ACTION
        {
            /// <summary>
            /// This value is invalid and MUST NOT be used. It is defined for simplicity in writing IDL definitions and code. 
            /// </summary>
            Invalid = 0,

            /// <summary>
            /// Rules with this action allow traffic but are applicable only to rules that at least specify the FW_RULE_FLAGS_AUTHENTICATE flag. 
            /// </summary>
            AllowBypass = 1,

            /// <summary>
            /// Rules with this action block traffic. 
            /// </summary>
            Block = 2,

            /// <summary>
            /// Rules with this action allow traffic. 
            /// </summary>
            Allow = 3,
        }

        /// <summary>
        /// This enumeration is used to represent types of network adapters (NICs) in a specific machine. Each type might have one or more network adapters.
        /// </summary>
        [Flags]
        public enum INTERFACE_TYPE
        {
            /// <summary>
            /// Represents all types of network adapters (NICs). The following types fall into this type.
            /// </summary>
            All = 0x0000,

            /// <summary>
            /// Represents network adapters (NICs) that use wired network physical layers such as Ethernet.
            /// </summary>
            Lan = 0x0001,

            /// <summary>
            /// Represents network adapters that use the wireless 802 network physical layer.
            /// </summary>
            Wireless = 0x0002,

            /// <summary>
            /// Represents network adapters that use VPN connections.
            /// </summary>
            RemoteAccess = 0x0004,
        }

        /// <summary>
        /// This enumeration is used to represent specific address types.
        /// </summary>
        public enum ADDRESS_KEYWORD
        {
            /// <summary>
            /// Specifies that no specific keyword is used.
            /// </summary>
            NONE = 0x0000,

            /// <summary>
            /// Represents the collection of addresses that are currently within the local subnet of the computer.
            /// </summary>
            LOCAL_SUBNET = 0x0001,

            /// <summary>
            /// Represents the collection of addresses of the current DNS servers.
            /// </summary>
            DNS = 0x0002,

            /// <summary>
            /// Represents the collection of addresses of the current DHCP servers.
            /// </summary>
            DHCP = 0x0004,

            /// <summary>
            /// Represents the collection of addresses of the current WINS servers.
            /// </summary>
            WINS = 0x0008,

            /// <summary>
            /// Represents the collection of addresses of the current gateway servers.
            /// </summary>
            DEFAULT_GATEWAY = 0x0010,

            /// <summary>
            /// Represents the collection of addresses that are currently within the local intranet of the computer. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            [Obsolete]
            INTRANET = 0x0020,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x020A and earlier. It is defined for simplicity in writing IDL definitions and code. 
            /// </summary>
            [Obsolete]
            MAX_V2_10 = 0x0020,

            /// <summary>
            /// Represents the collection of addresses that are currently not within the local intranet or remote intranet of the computer. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            [Obsolete]
            INTERNET = 0x0040,

            /// <summary>
            /// Represents the collection of addresses of the current Digital Media Renderer devices as defined in [MS-DLNHND] section 3.3. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            [Obsolete]
            PLAYTO_RENDERERS = 0x0080,

            /// <summary>
            /// Represents the collection of addresses that are currently within the remote intranet of the computer. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            [Obsolete]
            REMOTE_INTRANET = 0x0100,
        }

        /// <summary>
        /// This structure defines IPv4 subnets. It is used in policy rules.
        /// </summary>
        public struct IPV4_SUBNET
        {
            /// <summary>
            /// This field represents the IPv4 address.
            /// </summary>
            public IPAddress Address;

            /// <summary>
            /// This field contains the subnet mask in host network order. If it contains ones, they MUST be contiguous and shifted to the most significant bits.
            /// </summary>
            public IPAddress SubnetMask;

            public static IPV4_SUBNET FromString(string s)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This structure represents a range of IPv4 addresses within the IPv4 address space.
        /// </summary>
        public struct IPV4_ADDRESS_RANGE
        {
            /// <summary>
            /// The first IPv4 address of the range in the IPv4 address space defined by this structure. The address is included in the range.
            /// </summary>
            public IPAddress StartAddress;

            /// <summary>
            /// The last IPv4 address of the range in the IPv4 address space defined by this structure. The address is included in the range.
            /// </summary>
            public IPAddress EndAddress;

            public static IPV4_SUBNET FromString(string s)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This structure represents an IPv6 subnet.
        /// </summary>
        public struct IPV6_SUBNET
        {
            /// <summary>
            /// This field contains a 16-octet IPv6 address.
            /// </summary>
            public IPAddress Address;

            public static IPV4_SUBNET FromString(string s)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This structure represents a range of IPv6 addresses within the IPv6 address space.
        /// </summary>
        public struct IPV6_ADDRESS_RANGE
        {
            /// <summary>
            /// A 16-octet array containing the first IPv6 address of the range in the IPv6 address range defined by this structure.
            /// </summary>
            public IPAddress StartAddress;

            /// <summary>
            /// A 16-octet array containing the last IPv6 address of the range in the IPv6 address range defined by this structure.
            /// </summary>
            public IPAddress EndAddress;

            public static IPV4_SUBNET FromString(string s)
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                throw new NotImplementedException();
            }

        }

        /// <summary>
        /// This structure contains a list of address structures. Static and symbolic representations are supported, but a structure can contain only one representation type
        /// </summary>
        public struct ADDRESSES
        {
            /// <summary>
            /// A combination of FW_ADDRESS_KEYWORD flags. Addresses in this field are specified from the IPv4 address space.
            /// </summary>
            public ADDRESS_KEYWORD V4Flags;

            /// <summary>
            /// A combination of FW_ADDRESS_KEYWORD flags. Addresses in this field are specified from the IPv6 address space.
            /// </summary>
            public ADDRESS_KEYWORD V6Flags;

            /// <summary>
            /// A list of specifically defined IPv4 address subnets.
            /// </summary>
            public IPV4_SUBNET[] V4SubNets;

            /// <summary>
            /// A list of specifically defined IPv4 address ranges.
            /// </summary>
            public IPV4_ADDRESS_RANGE[] V4Ranges;

            /// <summary>
            /// A list of specifically defined IPv6 address subnets.
            /// </summary>
            public IPV6_SUBNET[] V6SubNets;

            /// <summary>
            /// A list of specifically defined IPv6 address ranges.
            /// </summary>
            public IPV6_ADDRESS_RANGE[] V6Ranges;

            public void Add(string text)
            {
                switch (text.ToLower())
                {
                    default: throw new NotImplementedException();
                }
            }
        }

        public struct ICMtype_CODE
        {
            public byte Type;
            /// <summary>
            /// The Code field MUST contain values between 0x0000 and 0x0100. When wCode contains 0x100, it expresses any ICMP code belonging to the corresponding ICMP type. When Code contains values in the range 0 to 0x00FF, it expresses a specific ICMP code.
            /// </summary>
            public int Code;
        }

        /// <summary>
        /// This enumeration describes the operations used in the FW_OS_PLATFORM structure to determine if an object should be applied to a specified operating system platform.
        /// </summary>
        public enum OS_PLATFORM_OP
        {
            /// <summary>
            /// The operating system platform MUST be the same as the one specified.
            /// </summary>
            EQ = 0,

            /// <summary>
            /// The operating system MUST be greater than or equal to the one specified.
            /// </summary>
            GTEQ = 1,
        }

        /// <summary>
        /// This structure describes a set of operating system platforms. The fields in this data type correspond to the fields of the OSVERSIONINFOEX data type (for more information, see [MSDN-OSVERSIONINFOEX]). There are no constraints on the values allowed for the platform type, major version, or minor version. The set may include values that do not correspond to any existing operating system platform.
        /// </summary>
        public struct OS_PLATFORM
        {
            /// <summary>
            /// The three least significant bits identify the platform type. This corresponds to the dwPlatformId field in MSDN. The five most significant bits contain a value from the FW_OS_PLATFORM_OP enumeration.
            /// </summary>
            public byte Platform;

            /// <summary>
            /// Specifies the major version number for the OS. This corresponds to the dwMajorVersion field in MSDN.
            /// </summary>
            public byte MajorVersion;

            /// <summary>
            /// Specifies the minor version number for the OS. This corresponds to the dwMinorVersion field in MSDN.
            /// </summary>
            public byte MinorVersion;

            /// <summary>
            /// Not used. Reserved for future use.
            /// </summary>
            public byte Reserved;

            public OS_PLATFORM_OP Op
            {
                get { return (OS_PLATFORM_OP)(Platform >> 3); }
                set { Platform = (byte)((Platform & 0x7) | ((int)value << 3)); }
            }

            public int PlatformId
            {
                get { return Platform & 0x7; }
                set
                {
                    if ((value > 3) || (value < 0)) throw new ArgumentOutOfRangeException(nameof(value));
                    Platform = (byte)((Platform & 0xF8) | value);
                }
            }
        }

        /// <summary>
        /// This enumeration identifies (with bitmask flags) the ports used by specific well-known protocols. The ports corresponding to these keywords change dynamically and are tracked by the PortsInUse object.
        /// </summary>
        [Flags]
        public enum PORT_KEYWORD
        {
            /// <summary>
            /// Specifies that no port keywords are used.
            /// </summary>
            NONE = 0x00,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsDynamicRPC is true.
            /// </summary>
            DYNAMIC_RPC_PORTS = 0x01,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsRPCEndpointMapper is true.
            /// </summary>
            RPC_EP = 0x02,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsTeredo is true. 
            /// </summary>
            TEREDO_PORT = 0x04,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsIPTLSIn is true. For schema versions 0x0200 and 0x0201, this value is invalid and MUST NOT be used.
            /// </summary>
            IP_TLS_IN = 0x08,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsIPTLSOut is true. For schema versions 0x0200 and 0x0201, this value is invalid and MUST NOT be used.
            /// </summary>
            IP_TLS_OUT = 0x10,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsDHCPClient is true. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used.
            /// </summary>
            DHCP = 0x20,

            /// <summary>
            /// Represents all ports in the PortsInUse collection where IsPlayToDiscovery is true. For schema versions 0x0200, 0x0201, and 0x020A, this value is invalid and MUST NOT be used. 
            /// </summary>
            PLAYTO_DISCOVERY = 0x40,
            
            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x0201 and earlier. It is defined for simplicity in writing IDL definitions and code.
            /// </summary>
            [Obsolete]
            MAX_V2_1 = 0x08,

            /// <summary>
            /// This value and values that exceed this value are not valid and MUST NOT be used by servers and clients with schema version 0x020A and earlier. It is defined for simplicity in writing IDL definitions and code.
            /// </summary>
            [Obsolete]
            MAX_V2_10 = 0x20
        }


        /// <summary>
        /// This structure contains the ports represented statically through FW_PORT_RANGE structures or symbolically through FW_PORT_KEYWORD enumeration values.
        /// </summary>
        public class PORTS
        {
            /// <summary>
            /// This field is a combination of FW_PORT_KEYWORDS.
            /// </summary>
            PORT_KEYWORD Keywords;

            /// <summary>
            /// This field is a list of specifically defined ports.
            /// </summary>
            List<PORT_RANGE> Ports = new List<PORT_RANGE>();

            public void Add(string port)
            {
                switch (port)
                {
                    case "RPC": Keywords |= PORT_KEYWORD.DYNAMIC_RPC_PORTS; break;
                    default: AddRange(port); break;
                }
            }

            public void AddRange(string range)
            {
                Ports.Add(PORT_RANGE.Parse(range));
            }
        }

        /// <summary>
        /// This structure represents a range of ports. Ports are 16-bit unsigned values used in TCP and UDP protocols.
        /// </summary>
        public struct PORT_RANGE
        {
            /// <summary>
            /// This field specifies the first port included in the range defined.
            /// </summary>
            public ushort StartPort;

            /// <summary>
            /// This field specifies the last port included in the range defined.
            /// </summary>
            public ushort EndPort;

            public static PORT_RANGE Parse(string ports)
            {
                PORT_RANGE result = new PORT_RANGE();
                int i = ports.IndexOf('-');
                if (i > -1)
                {
                    result.StartPort = ushort.Parse(ports.Substring(0, i));
                    result.EndPort = ushort.Parse(ports.Substring(i + 1));
                }
                else
                {
                    result.StartPort = ushort.Parse(ports);
                }
                return result;
            }
        }

        public class RULE
        {
            public static RULE[] FromRegistry()
            {
                List<RULE> l_Rules = new List<RULE>();
                RegistryKey l_Static = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\RestrictedServices\Static\System");
                RegistryKey config = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\RestrictedServices\Configurable\System");
                foreach (string name in l_Static.GetValueNames())
                {
                    RULE l_Rule = new RULE();

                    string[] parts = ((string)l_Static.GetValue(name)).Split('|');
                    l_Rule.Version = new Version(parts[0].Substring(1));
                    for (int i = 1; i < parts.Length; i++)
                    {
                        if (parts[i].Length == 0) continue;
                        int n = parts[i].IndexOf('=');
                        if (n < 0) continue;

                        string field = parts[i].Substring(0, n);
                        string value = parts[i].Substring(n + 1);
                        switch (field.ToLower())
                        {
                            case "action": l_Rule.Action = (RULE_ACTION)Enum.Parse(typeof(RULE_ACTION), value, true); continue;
                            case "dir": l_Rule.Direction = (DIRECTION)Enum.Parse(typeof(DIRECTION), value, true); continue;
                            case "profile": l_Rule.Profile = (PROFILE_TYPE)Enum.Parse(typeof(PROFILE_TYPE), value, true); continue;
                            case "protocol": l_Rule.Protocol = (IanaProtocolNumber)int.Parse(value); continue;
                            case "lport": l_Rule.LocalPorts.Add(value); continue;
                            case "lport2_10": l_Rule.LocalPorts.AddRange(value); continue;
                            case "rport": l_Rule.RemotePorts.Add(value); continue;
                            case "rport2_10": l_Rule.RemotePorts.AddRange(value); continue;
                            case "security": throw new NotImplementedException();
                            case "security2_9": throw new NotImplementedException();
                            case "security2": throw new NotImplementedException();
                            case "if": l_Rule.InterfaceIds = value; continue;
                            case "iftype": l_Rule.InterfaceType = (INTERFACE_TYPE)int.Parse(value); continue;
                            case "app": l_Rule.Application = value; continue;
                            case "svc": l_Rule.Service = value; continue;
                            case "la4": l_Rule.LocalAddresses.Add(value); continue;
                            case "la6": l_Rule.LocalAddresses.Add(value); continue;
                            case "ra4": l_Rule.RemoteAddresses.Add(value); continue;
                            case "ra6": l_Rule.RemoteAddresses.Add(value); continue;
                            case "name": l_Rule.Name = value; continue;
                            case "desc": l_Rule.Description = value; continue;
                            case "edge": l_Rule.RouteableAddrsTraverse = bool.Parse(value); continue;
                            case "defer": throw new NotImplementedException();
                            case "lsm": l_Rule.LooseSourceMapped = bool.Parse(value); continue;
                            case "active": l_Rule.Active = bool.Parse(value); continue;
                            case "icmp4": throw new NotImplementedException();
                            case "icmp6": throw new NotImplementedException();
                            case "platform": throw new NotImplementedException();
                            case "rmauth": throw new NotImplementedException();
                            case "ruauth": throw new NotImplementedException();
                            case "authbypassout": l_Rule.AuthenticateByPassOutbound = bool.Parse(value); continue;
                            case "skipver": l_Rule.SkipVersion = new Version(value); continue;
                            case "lom": l_Rule.LocalOnlyMapped = bool.Parse(value); continue;
                            case "platform2": throw new NotImplementedException();
                            case "pcross": throw new NotImplementedException();
                            case "luauth": throw new NotImplementedException();
                            case "ra42": throw new NotImplementedException();
                            case "ra62": throw new NotImplementedException();
                            case "luown": throw new NotImplementedException();
                            case "apppkgid": throw new NotImplementedException();
                            case "lport2_20": throw new NotImplementedException();
                            case "ttk": throw new NotImplementedException();
                            default: throw new NotSupportedException(string.Format("Unsupported field {0}", field));
                        }
                    }
                    l_Rules.Add(l_Rule);
                }
                return l_Rules.ToArray();
            }

            public bool Active
            {
                get { return 0 != (Flags & RULE_FLAGS.ACTIVE); }
                set { Flags = value ? (Flags | RULE_FLAGS.ACTIVE) : (Flags & ~RULE_FLAGS.ACTIVE); }
            }

            public bool LocalOnlyMapped
            {
                get { return 0 != (Flags & RULE_FLAGS.LOCAL_ONLY_MAPPED); }
                set { Flags = value ? (Flags | RULE_FLAGS.LOCAL_ONLY_MAPPED) : (Flags & ~RULE_FLAGS.LOCAL_ONLY_MAPPED); }
            }

            public bool RouteableAddrsTraverse
            {
                get { return 0 != (Flags & RULE_FLAGS.ROUTEABLE_ADDRS_TRAVERSE); }
                set { Flags = value ? (Flags | RULE_FLAGS.ROUTEABLE_ADDRS_TRAVERSE) : (Flags & ~RULE_FLAGS.ROUTEABLE_ADDRS_TRAVERSE); }
            }

            public bool LooseSourceMapped
            {
                get { return 0 != (Flags & RULE_FLAGS.LOOSE_SOURCE_MAPPED); }
                set { Flags = value ? (Flags | RULE_FLAGS.LOOSE_SOURCE_MAPPED) : (Flags & ~RULE_FLAGS.LOOSE_SOURCE_MAPPED); }
            }

            public bool AuthenticateByPassOutbound
            {
                get { return 0 != (Flags & RULE_FLAGS.AUTHENTICATE_BYPASS_OUTBOUND); }
                set { Flags = value ? (Flags | RULE_FLAGS.AUTHENTICATE_BYPASS_OUTBOUND) : (Flags & ~RULE_FLAGS.AUTHENTICATE_BYPASS_OUTBOUND); }
            }

            public Version Version = new Version(2, 0);

            public RULE_FLAGS Flags;

            public RULE_ACTION Action;

            public DIRECTION Direction;

            public PROFILE_TYPE Profile;

            public IanaProtocolNumber Protocol;

            public string InterfaceIds;

            public INTERFACE_TYPE InterfaceType;

            public string Application;

            public string Service;

            public ADDRESSES LocalAddresses = new ADDRESSES();

            public ADDRESSES RemoteAddresses = new ADDRESSES();

            public PORTS LocalPorts = new PORTS();

            public PORTS RemotePorts = new PORTS();

            public string Name;

            public string Description;

            public ICMtype_CODE[] IcmpTypeCodeList;

            public OS_PLATFORM[] Platform;

            public Version SkipVersion;
        }
    }
}

#pragma warning restore 1591

#endif