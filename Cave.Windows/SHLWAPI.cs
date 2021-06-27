using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cave.Windows
{
    /// <summary>
    /// Native interface to the SHLWAPI.DLL
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    [SuppressMessage("Interoperability", "CA1401")]
    public static class SHLWAPI
    {
        /// <summary>
        /// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
        /// </summary>
        /// <param name="pszSource">A pointer to a buffer that contains the indirect string from which the resource will be retrieved. This string should begin with the '@' symbol and use one of the forms discussed in the Remarks section. This function will successfully accept a string that does not begin with an '@' symbol, but the string will be simply passed unchanged to pszOutBuf.</param>
        /// <param name="pszOutBuf">A pointer to a buffer that, when this function returns successfully, receives the text resource. Both pszOutBuf and pszSource can point to the same buffer, in which case the original string will be overwritten.</param>
        /// <param name="cchOutBuf">The size of the buffer pointed to by pszOutBuf, in characters.</param>
        /// <param name="ppvReserved">Not used; set to NULL.</param>
        /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
        public static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);

        /// <summary>
        /// Extracts a specified text resource when given that resource in the form of an indirect string (a string that begins with the '@' symbol).
        /// </summary>
        /// <param name="source">@fileName,resource[;version]</param>
        /// <returns></returns>
        public static string GetResource(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (!source.StartsWith("@")) throw new ArgumentOutOfRangeException(nameof(source));

            var str = new StringBuilder(2048);
            var result = SHLoadIndirectString(Environment.ExpandEnvironmentVariables(source), str, str.Capacity, IntPtr.Zero);
            if (result != 0) throw new Win32ErrorException(result & 0xFFFF);
            return result.ToString();
        }
    }
}
