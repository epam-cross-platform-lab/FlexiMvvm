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
using System.Linq;
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence
{
    public class InMemoryBundle : IBundle
    {
        [CanBeNull]
        private Dictionary<string, object> _bundle;

        public bool IsEmpty => GetValue(true, bundle => !bundle.NotNull().Any());

        public bool ContainsKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(false, bundle => bundle.NotNull().ContainsKey(key));
        }

        public bool GetBool(bool defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public bool[] GetBoolArray(bool[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public byte[] GetByteArray(byte[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public char GetChar(char defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public char[] GetCharArray(char[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public double GetDouble(double defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public double[] GetDoubleArray(double[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public float GetFloat(float defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public float[] GetFloatArray(float[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public int GetInt(int defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public int[] GetIntArray(int[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public long GetLong(long defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public long[] GetLongArray(long[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public short GetShort(short defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public short[] GetShortArray(short[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public string GetString(string defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public string[] GetStringArray(string[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, key);
        }

        public void SetBool(bool value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetBoolArray(bool[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetByteArray(byte[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetChar(char value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetCharArray(char[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetDateTime(DateTime value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetDateTimeOffset(DateTimeOffset value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetDouble(double value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetDoubleArray(double[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetFloat(float value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetFloatArray(float[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetInt(int value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetIntArray(int[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetLong(long value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetLongArray(long[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetShort(short value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetShortArray(short[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetString(string value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public void SetStringArray(string[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(value, key);
        }

        public object ToNative()
        {
            return null;
        }

        [CanBeNull]
        private T GetValue<T>([CanBeNull] T defaultValue, [NotNull] Func<Dictionary<string, object>, T> getValue)
        {
            return _bundle != null ? getValue(_bundle) : defaultValue;
        }

        [CanBeNull]
        private T GetValue<T>([CanBeNull] T defaultValue, [NotNull] string key)
        {
            return _bundle != null
                ? _bundle.TryGetValue(key, out var value)
                    ? (T)value
                    : defaultValue
                : defaultValue;
        }

        private void SetValue<T>([CanBeNull] T value, [NotNull] string key)
        {
            if (_bundle == null)
                _bundle = new Dictionary<string, object>();

            _bundle[key] = value;
        }
    }
}
