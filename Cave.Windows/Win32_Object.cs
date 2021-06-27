using System;
using System.Management;

namespace Cave.Windows
{
    /// <summary>
    /// Provides a base class for ManagementObject interop
    /// </summary>
    public abstract class Win32_Object : IDisposable
    {
        /// <summary>
        /// Provides access to the <see cref="ManagementObject"/>
        /// </summary>
        protected ManagementObject Object { get; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="obj">The <see cref="ManagementObject"/> to use</param>
        public Win32_Object(ManagementObject obj) => Object = obj ?? throw new ArgumentNullException(nameof(obj));

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
            Object.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Reads an array of values (T1 enums) from the ManagementObject by using the specified T2 system type
        /// </summary>
        /// <typeparam name="T1">Enum type to read</typeparam>
        /// <typeparam name="T2">System type stored at ManagementObject (this is mainly int)</typeparam>
        /// <param name="name">Name of the value to read</param>
        /// <returns>Returns a new array of values</returns>
        protected T1[] ReadArray<T1, T2>(string name) where T2 : struct
        {
            if (!typeof(T1).IsEnum) throw new ArgumentException(string.Format("T1 has to be a enum type!"));
            if (!typeof(T2).IsPrimitive) throw new ArgumentException(string.Format("T2 has to be a primitive type!"));
            var obj = Object[name];
            if (obj == null)
            {
#if NET46 || NET47 || NETSTANDARD20
                return Array.Empty<T1>();
#else
                return new T1[0];
#endif
            }
            var array = (T2[])obj;
            var result = new T1[array.Length];
            for (var i = 0; i < array.Length; i++) result[i] = (T1)(object)array[i];
            return result;
        }

        /// <summary>
        /// Reads a value of the specified type from the ManagementObject
        /// </summary>
        /// <typeparam name="T">Type to read</typeparam>
        /// <param name="name">Name of the value to read</param>
        /// <returns>Returns the value</returns>
        protected T Read<T>(string name)
        {
            var obj = Object[name];
            if (obj != null)
            {
                if (!typeof(T).IsAssignableFrom(obj.GetType()))
                {
                    throw new ArgumentException(string.Format("Cannot assign value of type {0} to type {1}", obj.GetType(), typeof(T)));
                }
                return (T)obj;
            }
            return Activator.CreateInstance<T>();
        }
    }
}

