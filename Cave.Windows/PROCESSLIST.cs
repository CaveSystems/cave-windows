using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a list of all running process ids
    /// </summary>
    public class PROCESSLIST : IEnumerable, IDisposable
    {
        IntPtr m_ListPointer;
        int m_Count = 0;
        int[] m_Items = null;
        int m_Size = 65536;

        /// <summary>
        ///
        /// </summary>
        public PROCESSLIST()
        {
            m_ListPointer = Marshal.AllocHGlobal(m_Size);
            Update();
        }

        /// <summary>
        /// Cleans up
        /// </summary>
        ~PROCESSLIST()
        {
            FreeHandle();
        }

        void FreeHandle()
        {
            if (m_ListPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(m_ListPointer);
                m_ListPointer = IntPtr.Zero;
            }
        }

        /// <summary>
        /// updates the process id list and returns the number of processes in the list
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            if (!PSAPI.EnumProcesses(m_ListPointer, 32768, out var len))
            {
                if (len > m_Size)
                {
                    m_Size = len * 2;
                    Marshal.FreeHGlobal(m_ListPointer);
                    m_ListPointer = Marshal.AllocHGlobal(m_Size);
                    return Update();
                }
                throw new Win32ErrorException();
            }
            m_Count = len / 4;
            m_Items = null;
            return m_Count;
        }

        /// <summary>
        /// Obtains all process ids currently existing
        /// </summary>
        public int[] Items
        {
            get
            {
                if (m_Items == null)
                {
                    var result = new int[m_Count];
                    Marshal.Copy(m_ListPointer, result, 0, m_Count);
                    m_Items = result;
                }
                return m_Items;
            }
        }

        /// <summary>
        /// returns the number of process ids currently in the list. The process count is updated with <see cref="Update"/>
        /// </summary>
        public int Count => m_Count;

        #region IEnumerable Member

        /// <summary>
        /// Obtains a Process ID enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator() => Items.GetEnumerator();

        #endregion

        #region IDisposable Member

        /// <summary>
        /// frees all resources needed to provide the process list
        /// </summary>
        public void Dispose()
        {
            FreeHandle();
            //surpress finalizer
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
