// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using System.Collections.Generic;

namespace FlexiMvvm.Collections
{
    /// <summary>
    /// Represents a set for storing values of different types.
    /// </summary>
    public abstract class ValueSet
    {
        private Dictionary<string, object> _values;

        private Dictionary<string, object> Values => _values ?? (_values = new Dictionary<string, object>());

        /// <summary>
        /// Gets the value that is associated with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="defaultValue">The default value if the key not found.</param>
        /// <returns>The value that is associated with the specified key, if the key is found; otherwise, the default value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidCastException">The value cannot be cast to <typeparamref name="T"/>.</exception>
        public T GetValue<T>(string key, T defaultValue = default)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (T)_values.GetValueOrDefault(key, defaultValue);
        }

        /// <summary>
        /// Sets the value using the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="key">The key of the value to set.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        public void SetValue<T>(string key, T value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Values[key] = value;
        }
    }
}
