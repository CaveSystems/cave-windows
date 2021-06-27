using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a wrapper for SysListView32 controls
    /// </summary>
    public class SysListView32 : IDisposable
    {
        const uint LVM_FIRST = 0x1000;
        const uint LVM_GETITEMCOUNT = LVM_FIRST + 4;
        const uint LVM_GETITEM = LVM_FIRST + 75;
        const uint LVIF_TEXT = 0x0001;

        [StructLayout(LayoutKind.Sequential)]
        [SuppressMessage("Style", "IDE1006", Justification = "WinApi naming")]
        private struct LVITEM
        {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        readonly IntPtr ControlHandle;
        readonly int ProcessID;
        readonly IntPtr ProcessHandle;
        IntPtr foreignItemBuffer;
        IntPtr foreignTextBuffer;
        IntPtr localBuffer;

        /// <summary>
        /// Creates a new SysListView32 instance
        /// </summary>
        /// <param name="processHandle"></param>
        /// <param name="controlHandle"></param>
        public SysListView32(IntPtr processHandle, IntPtr controlHandle)
        {
            var className = USER32.GetClassName(controlHandle);
            if (className != "SysListView32") throw new ArgumentException("Control is not a SysListView32");
            ControlHandle = controlHandle;
            _ = USER32.GetWindowThreadProcessId(controlHandle, out ProcessID);
            ProcessHandle = processHandle;

            foreignTextBuffer = KERNEL32.SafeNativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, 512, MEM_STATE.ALLOCATE_NEW, MEM_PROTECT.PAGE_READWRITE);
            foreignItemBuffer = KERNEL32.SafeNativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, 512, MEM_STATE.ALLOCATE_NEW, MEM_PROTECT.PAGE_READWRITE);
            localBuffer = Marshal.AllocHGlobal(512);
        }

        /// <summary>
        /// Releases all unmanaged resources
        /// </summary>
        ~SysListView32()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes all managed and unmanaged resources
        /// </summary>
        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all managed and unmanaged resources
        /// </summary>
        /// <param name="finalizing"></param>
        protected virtual void Dispose(bool finalizing)
        {
            if (foreignItemBuffer != IntPtr.Zero)
            {
                KERNEL32.SafeNativeMethods.VirtualFreeEx(ProcessHandle, foreignItemBuffer, 0, MEM_STATE.RELEASE);
                foreignItemBuffer = IntPtr.Zero;
            }
            if (foreignTextBuffer != IntPtr.Zero)
            {
                KERNEL32.SafeNativeMethods.VirtualFreeEx(ProcessHandle, foreignTextBuffer, 0, MEM_STATE.RELEASE);
                foreignTextBuffer = IntPtr.Zero;
            }
            if (localBuffer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(localBuffer);
                localBuffer = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Obtains the cell text of the specified cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public string GetCellText(int row, int column)
        {
            var lvi = new LVITEM
            {
                mask = LVIF_TEXT,
                cchTextMax = 512,
                iItem = row,
                iSubItem = column,
                pszText = foreignTextBuffer
            };
            Marshal.StructureToPtr(lvi, localBuffer, false);
            //write to foreign process memory
            if (!KERNEL32.SafeNativeMethods.WriteProcessMemory(ProcessHandle, foreignItemBuffer, localBuffer, new IntPtr(512), out _))
            {
                throw new Exception("Could not write to foreign process.");
            }
            //tell control go give me the content
            USER32.SendMessage(ControlHandle, LVM_GETITEM, IntPtr.Zero, foreignItemBuffer);
            //read the result
            if (!KERNEL32.SafeNativeMethods.ReadProcessMemory(ProcessHandle, foreignTextBuffer, localBuffer, new IntPtr(512), out _))
            {
                throw new Exception("Could not read from foreign process.");
            }
            return Marshal.PtrToStringAuto(localBuffer);
        }

        /// <summary>
        /// Obtains the row count
        /// </summary>
        public int RowCount => USER32.SendMessage(ControlHandle, LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero).ToInt32();

        /// <summary>
        /// Controls the text of the control
        /// </summary>
        public string Text => USER32.GetWindowText(ControlHandle);

        /// <inheritdoc />
        public override string ToString() => $"Handle: {ControlHandle}, Process: {ProcessID}";
    }
}
