using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// provides an interface to the windows Psapi.dll
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("Interoperability", "CA1401")]
    public static class PSAPI
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="processIDList"></param>
        /// <param name="size"></param>
        /// <param name="bytesRead"></param>
        /// <returns></returns>
        [DllImport("Psapi.dll", CallingConvention = CallingConvention.Winapi, ExactSpelling = true, SetLastError = true)]
        public static extern bool EnumProcesses([Out] IntPtr processIDList, [In] int size, [Out] out int bytesRead);

        /// <summary>
        /// Retrieves the full name of the executable image for the specified process.
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="exeName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("Psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetProcessImageFileName([In]IntPtr processHandle, [Out]StringBuilder exeName, [In]int count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="moduleHandle"></param>
        /// <param name="fileName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport("Psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetModuleFileNameEx([In]IntPtr processHandle, [In]IntPtr moduleHandle, [Out]StringBuilder fileName, [In]int count);
    }
}
