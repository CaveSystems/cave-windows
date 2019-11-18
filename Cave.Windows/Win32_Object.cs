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
        protected ManagementObject m_Object { get; }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="obj">The <see cref="ManagementObject"/> to use</param>
        public Win32_Object(ManagementObject obj)
        {
            if (obj == null) throw new ArgumentNullException("Object");
            m_Object = obj;
        }

        /// <summary>
        /// Disposes the object
        /// </summary>
        public void Dispose()
        {
            m_Object.Dispose();
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
            object obj = m_Object[name];
            if (obj == null) return new T1[0];
            T2[] array = (T2[])obj;
            T1[] result = new T1[array.Length];
            for (int i = 0; i < array.Length; i++) result[i] = (T1)(object)array[i];
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
            object obj = m_Object[name];
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

#endif