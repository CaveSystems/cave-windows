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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

//This class provides outdated functionality. do not warn inside this class
#pragma warning disable 612

namespace Cave.Windows
{
	/// <summary>
	/// Provides access to low level registry functions
	/// </summary>
	public class REGISTRY
	{
		/// <summary>
		/// Obtains the windows handle to a <see cref="RegistryHive"/> enum value
		/// </summary>
		/// <param name="hive"></param>
		/// <returns></returns>
		public static HKEY GetHiveHandle(RegistryHive hive)
		{
			switch (hive)
			{
				case RegistryHive.ClassesRoot: return HKEY.CLASSES_ROOT;
				case RegistryHive.CurrentUser: return HKEY.CURRENT_USER;
				case RegistryHive.CurrentConfig: return HKEY.CURRENT_CONFIG;
				case RegistryHive.DynData: return HKEY.DYN_DATA;
				case RegistryHive.LocalMachine: return HKEY.LOCAL_MACHINE;
				case RegistryHive.PerformanceData: return HKEY.PERFORMANCE_DATA;
				case RegistryHive.Users: return HKEY.USERS;
				default: throw new NotImplementedException(string.Format("The RegistryHive {0} is unknown!", hive));
			}
		}

		/// <summary>
		/// Obtains the windows handle to a registry path
		/// </summary>
		/// <param name="registryPath"></param>
		/// <returns></returns>
		public static HKEY GetHiveHandle(string registryPath)
		{
			return GetHiveHandle(GetHive(registryPath));
		}

		/// <summary>
		/// Obtains the <see cref="RegistryHive"/> from a given <see cref="HKEY"/>
		/// </summary>
		/// <param name="hKey"></param>
		/// <returns></returns>
		public static RegistryHive GetHive(HKEY hKey)
		{
			switch (hKey)
			{
				case HKEY.CLASSES_ROOT: return RegistryHive.ClassesRoot;
				case HKEY.CURRENT_CONFIG: return RegistryHive.CurrentConfig;
				case HKEY.CURRENT_USER: return RegistryHive.CurrentUser;
				case HKEY.DYN_DATA: return RegistryHive.DynData;
				case HKEY.LOCAL_MACHINE: return RegistryHive.LocalMachine;
				case HKEY.PERFORMANCE_DATA: return RegistryHive.PerformanceData;
				case HKEY.USERS: return RegistryHive.Users;
				default: throw new NotImplementedException(string.Format("The Registry HKey {0} is unknown!", hKey));
			}
		}

		/// <summary>
		/// Obtains the <see cref="RegistryHive"/> from a given path
		/// </summary>
		/// <param name="registryPath"></param>
		/// <returns></returns>
		public static RegistryHive GetHive(string registryPath)
		{
			string[] parts = registryPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length < 1) throw new Exception(string.Format("Invalid registry path '{0}' given!", registryPath));
			switch (parts[0].ToUpper())
			{
				case "HKEY_CLASSES_ROOT":
				case "HKEY_CLASSESROOT":
				case "CLASSES_ROOT":
				case "CLASSESROOT":
				case "HKCR":
					return RegistryHive.ClassesRoot;
				case "HKEY_LOCAL_MACHINE":
				case "HKEY_LOCALMACHINE":
				case "LOCAL_MACHINE":
				case "LOCALMACHINE":
				case "HKLM":
					return RegistryHive.LocalMachine;
				case "HKEY_CURRENT_USER":
				case "HKEY_CURRENTUSER":
				case "CURRENT_USER":
				case "CURRENTUSER":
				case "HKCU":
					return RegistryHive.CurrentUser;
				case "HKEY_CURRENT_CONFIG":
				case "HKEY_CURRENTCONFIG":
				case "CURRENT_CONFIG":
				case "CURRENTCONFIG":
				case "HKCC":
					return RegistryHive.CurrentConfig;
				case "HKEY_USERS":
				case "USERS":
				case "HKU":
					return RegistryHive.Users;
				case "DYN_DATA":
				case "DYNDATA":
				case "HKDD":
					return RegistryHive.DynData;
				case "PERFORMANCE_DATA":
				case "PERFORMANCEDATA":
				case "HKPD":
					return RegistryHive.PerformanceData;
				default: throw new Exception(string.Format("Invalid registry path '{0}' given!", registryPath));
			}
		}

		/// <summary>
		/// Obtains the <see cref="RegistryKey"/> for a given <see cref="RegistryHive"/>
		/// </summary>
		/// <param name="hive"></param>
		/// <returns></returns>
		public static RegistryKey GetKey(RegistryHive hive)
		{
			switch (hive)
			{
#pragma warning disable 618
				case RegistryHive.DynData: return Registry.DynData;
#pragma warning restore 618
				case RegistryHive.ClassesRoot: return Registry.ClassesRoot;
				case RegistryHive.CurrentConfig: return Registry.CurrentConfig;
				case RegistryHive.CurrentUser: return Registry.CurrentUser;
				case RegistryHive.LocalMachine: return Registry.LocalMachine;
				case RegistryHive.PerformanceData: return Registry.PerformanceData;
				case RegistryHive.Users: return Registry.Users;
				default: throw new NotImplementedException(string.Format("The RegistryHive {0} is unknown!", hive));
			}
		}

		/// <summary>
		/// Obtains the <see cref="RegistryKey"/> for a given path
		/// </summary>
		/// <param name="registryPath"></param>
		/// <param name="writeAble"></param>
		/// <returns></returns>
		public static RegistryKey GetKey(string registryPath, bool writeAble)
		{
			Queue<string> parts = new Queue<string>(registryPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries));
			if (parts.Count < 1) throw new Exception(string.Format("Invalid registry path '{0}' given!", registryPath));
			RegistryKey l_Key = GetKey(GetHive(parts.Dequeue()));

			while (parts.Count > 0)
			{
				bool l_WriteAble = writeAble && (parts.Count == 1);
				string l_SubKeyName = parts.Dequeue();
				RegistryKey l_NextKey = l_Key.OpenSubKey(l_SubKeyName, l_WriteAble);
				if (l_NextKey == null)
				{
					if (!writeAble)
					{
						throw new Exception(string.Format("The RegistryKey '{0}' does not exist!", registryPath));
					}
					l_NextKey = l_Key.CreateSubKey(l_SubKeyName);
					if (l_NextKey == null)
					{
						throw new AccessViolationException(string.Format("The RegistryKey '{0}' cannot be created!", registryPath));
					}
					if (!l_WriteAble)
					{
						l_NextKey.Close();
						l_NextKey = l_Key.OpenSubKey(l_SubKeyName, false);
						if (l_NextKey == null) throw new Exception(string.Format("The RegistryKey '{0}' cannot be opened!", registryPath));
					}
					l_Key.Close();
					l_Key = l_NextKey;
				}
			}
			return l_Key;
		}



		/// <summary>
		/// Get a pointer to a registry key.
		/// </summary>
		/// <param name="key">Registry key to obtain the pointer of.</param>
		/// <returns>Pointer to the specified registry key.</returns>
		public static IntPtr GetRegistryKeyHandle(RegistryKey key)
		{
			//Get the type of the RegistryKey
			Type l_KeyType = typeof(RegistryKey);
			//Get the FieldInfo of the 'hkey' member of RegistryKey
			FieldInfo fieldInfo = l_KeyType.GetField("hkey", BindingFlags.NonPublic | BindingFlags.Instance);
			//Get the handle held by hkey
			SafeHandle handle = (SafeHandle)fieldInfo.GetValue(key);
			//Get the unsafe handle
			return handle.DangerousGetHandle();
		}

		/// <summary>
		/// Get a registry key from a pointer.
		/// </summary>
		/// <param name="hKey">Pointer to the registry key</param>
		/// <param name="writable">Whether or not the key is writable.</param>
		/// <param name="ownsHandle">Whether or not we own the handle.</param>
		/// <returns>Registry key pointed to by the specified pointer.</returns>
		public static RegistryKey PointerToRegistryKey(IntPtr hKey, bool writable, bool ownsHandle)
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

			//create a handle for the key (get type, get constructors, call best, get handle)
			Type handleType = typeof(SafeHandleZeroOrMinusOneIsInvalid).Assembly.GetType("Microsoft.Win32.SafeHandles.SafeRegistryHandle");
			Type[] handleConstructors = new Type[] { typeof(IntPtr), typeof(bool) };
			ConstructorInfo handleConstructor = handleType.GetConstructor(bindingFlags, null, handleConstructors, null);
			object handle = handleConstructor.Invoke(new object[] { hKey, ownsHandle });

			//Get the key (get type, get constructors, call best, get key)
			Type l_KeyType = typeof(RegistryKey);
			Type[] l_KeyConstructors = new Type[] { handleType, typeof(bool) };
			ConstructorInfo l_KeyConstructor = l_KeyType.GetConstructor(bindingFlags, null, l_KeyConstructors, null);
			RegistryKey result = (RegistryKey)l_KeyConstructor.Invoke(new object[] { handle, writable });

			return result;
		}

		/// <summary>
		/// Open a registry key using the Wow64 node instead of the default 32-bit node.
		/// </summary>
		/// <param name="parentKey">Parent key to the key to be opened.</param>
		/// <param name="subKeyName">Name of the key to be opened</param>
		/// <param name="writable">Whether or not this key is writable</param>
		/// <param name="options"><see cref="RegWow64Options"/> 32-bit node or 64-bit node </param>
		/// <returns></returns>
		public static RegistryKey OpenSubKey(RegistryKey parentKey, string subKeyName, bool writable, RegWow64Options options)
		{
			if (parentKey == null) throw new ArgumentNullException("ParentKey");
			IntPtr l_Key = GetRegistryKeyHandle(parentKey);
			if (l_Key == IntPtr.Zero) return null;

			int flags = (writable) ? (int)RegistryRights.WriteKey : (int)RegistryRights.ReadKey;

			IntPtr l_SubKeyHandle;
			ErrorCode result = ADVAPI32.UnsafeNativeMethods.RegOpenKeyEx(l_Key, subKeyName, 0, flags | (int)options, out l_SubKeyHandle);
			if (result != ErrorCode.SUCCESS)
			{
				throw new Win32ErrorException(result);
			}

			//Get the key represented by the pointer returned by RegOpenKeyEx
			return PointerToRegistryKey(l_SubKeyHandle, writable, false);
		}
	}
}

#pragma warning restore 612
#endif