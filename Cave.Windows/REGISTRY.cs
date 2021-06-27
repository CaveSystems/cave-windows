using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

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
        public static HKEY GetHiveHandle(RegistryHive hive) => (HKEY)(int)hive;

        /// <summary>
        /// Obtains the windows handle to a registry path
        /// </summary>
        /// <param name="registryPath"></param>
        /// <returns></returns>
        public static HKEY GetHiveHandle(string registryPath) => GetHiveHandle(GetHive(registryPath));

        /// <summary>
        /// Obtains the <see cref="RegistryHive"/> from a given <see cref="HKEY"/>
        /// </summary>
        /// <param name="hKey"></param>
        /// <returns></returns>
        public static RegistryHive GetHive(HKEY hKey) => (RegistryHive)(int)hKey;

		/// <summary>
		/// Obtains the <see cref="RegistryHive"/> from a given path
		/// </summary>
		/// <param name="registryPath"></param>
		/// <returns></returns>
		public static RegistryHive GetHive(string registryPath)
		{
			var parts = registryPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length < 1) throw new Exception(string.Format("Invalid registry path '{0}' given!", registryPath));
            return parts[0].ToUpper() switch
            {
                "HKEY_CLASSES_ROOT" or "HKEY_CLASSESROOT" or "CLASSES_ROOT" or "CLASSESROOT" or "HKCR" => RegistryHive.ClassesRoot,
                "HKEY_LOCAL_MACHINE" or "HKEY_LOCALMACHINE" or "LOCAL_MACHINE" or "LOCALMACHINE" or "HKLM" => RegistryHive.LocalMachine,
                "HKEY_CURRENT_USER" or "HKEY_CURRENTUSER" or "CURRENT_USER" or "CURRENTUSER" or "HKCU" => RegistryHive.CurrentUser,
                "HKEY_CURRENT_CONFIG" or "HKEY_CURRENTCONFIG" or "CURRENT_CONFIG" or "CURRENTCONFIG" or "HKCC" => RegistryHive.CurrentConfig,
                "HKEY_USERS" or "USERS" or "HKU" => RegistryHive.Users,
                "PERFORMANCE_DATA" or "PERFORMANCEDATA" or "HKPD" => RegistryHive.PerformanceData,
                _ => throw new NotSupportedException(string.Format("The registry path '{0}' is not supported!", registryPath)),
            };
        }

        /// <summary>
        /// Obtains the <see cref="RegistryKey"/> for a given <see cref="RegistryHive"/>
        /// </summary>
        /// <param name="hive"></param>
        /// <returns></returns>
        public static RegistryKey GetKey(RegistryHive hive)
        {
            return hive switch
            {
                RegistryHive.ClassesRoot => Registry.ClassesRoot,
                RegistryHive.CurrentConfig => Registry.CurrentConfig,
                RegistryHive.CurrentUser => Registry.CurrentUser,
                RegistryHive.LocalMachine => Registry.LocalMachine,
                RegistryHive.PerformanceData => Registry.PerformanceData,
                RegistryHive.Users => Registry.Users,
                _ => throw new NotSupportedException(string.Format("The RegistryHive {0} is not supported!", hive)),
            };
        }

		/// <summary>
		/// Obtains the <see cref="RegistryKey"/> for a given path
		/// </summary>
		/// <param name="registryPath"></param>
		/// <param name="writeAble"></param>
		/// <returns></returns>
		public static RegistryKey GetKey(string registryPath, bool writeAble)
		{
			var parts = new Queue<string>(registryPath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries));
			if (parts.Count < 1) throw new Exception(string.Format("Invalid registry path '{0}' given!", registryPath));
			var key = GetKey(GetHive(parts.Dequeue()));

			while (parts.Count > 0)
			{
				var isWriteAble = writeAble && (parts.Count == 1);
				var subKeyName = parts.Dequeue();
				var nextKey = key.OpenSubKey(subKeyName, isWriteAble);
				if (nextKey == null)
				{
					if (!writeAble)
					{
						throw new Exception(string.Format("The RegistryKey '{0}' does not exist!", registryPath));
					}
					nextKey = key.CreateSubKey(subKeyName);
					if (nextKey == null)
					{
						throw new AccessViolationException(string.Format("The RegistryKey '{0}' cannot be created!", registryPath));
					}
					if (!isWriteAble)
					{
						nextKey.Close();
						nextKey = key.OpenSubKey(subKeyName, false);
						if (nextKey == null) throw new Exception(string.Format("The RegistryKey '{0}' cannot be opened!", registryPath));
					}
					key.Close();
					key = nextKey;
				}
			}
			return key;
		}



		/// <summary>
		/// Get a pointer to a registry key.
		/// </summary>
		/// <param name="key">Registry key to obtain the pointer of.</param>
		/// <returns>Pointer to the specified registry key.</returns>
		public static IntPtr GetRegistryKeyHandle(RegistryKey key)
		{
			//Get the type of the RegistryKey
			var keyType = typeof(RegistryKey);
			//Get the FieldInfo of the 'hkey' member of RegistryKey
			var fieldInfo = keyType.GetField("hkey", BindingFlags.NonPublic | BindingFlags.Instance);
			//Get the handle held by hkey
			var handle = (SafeHandle)fieldInfo.GetValue(key);
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
			var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

			//create a handle for the key (get type, get constructors, call best, get handle)
			var handleType = typeof(SafeHandleZeroOrMinusOneIsInvalid).Assembly.GetType("Microsoft.Win32.SafeHandles.SafeRegistryHandle");
			var handleConstructors = new Type[] { typeof(IntPtr), typeof(bool) };
			var handleConstructor = handleType.GetConstructor(bindingFlags, null, handleConstructors, null);
			var handle = handleConstructor.Invoke(new object[] { hKey, ownsHandle });

			//Get the key (get type, get constructors, call best, get key)
			var keyType = typeof(RegistryKey);
			var keyConstructors = new Type[] { handleType, typeof(bool) };
			var keyConstructor = keyType.GetConstructor(bindingFlags, null, keyConstructors, null);
			var result = (RegistryKey)keyConstructor.Invoke(new object[] { handle, writable });

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
			if (parentKey == null) throw new ArgumentNullException(nameof(parentKey));
			var key = GetRegistryKeyHandle(parentKey);
			if (key == IntPtr.Zero) return null;

			var flags = (writable) ? (int)RegistryRights.WriteKey : (int)RegistryRights.ReadKey;

            var result = ADVAPI32.UnsafeNativeMethods.RegOpenKeyEx(key, subKeyName, 0, flags | (int)options, out var subKeyHandle);
            if (result != ErrorCode.SUCCESS)
			{
				throw new Win32ErrorException(result);
			}

			//Get the key represented by the pointer returned by RegOpenKeyEx
			return PointerToRegistryKey(subKeyHandle, writable, false);
		}
	}
}

