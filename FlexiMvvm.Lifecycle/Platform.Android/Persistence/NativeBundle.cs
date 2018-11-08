// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using Android.OS;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence
{
    public class NativeBundle : IBundle
    {
        [CanBeNull]
        private Bundle _bundle;

        public NativeBundle([CanBeNull] Bundle bundle)
        {
            _bundle = bundle;
        }

        public bool IsEmpty => GetValue(true, bundle => bundle.NotNull().IsEmpty);

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

            return GetValue(defaultValue, bundle => bundle.NotNull().GetBoolean(key, defaultValue));
        }

        public bool[] GetBoolArray(bool[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetBooleanArray(key) ?? defaultValue);
        }

        public byte[] GetByteArray(byte[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetByteArray(key) ?? defaultValue);
        }

        public char GetChar(char defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetChar(key, defaultValue));
        }

        public char[] GetCharArray(char[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetCharArray(key) ?? defaultValue);
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetDateTime(key, defaultValue));
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetDateTimeOffset(key, defaultValue));
        }

        public double GetDouble(double defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetDouble(key, defaultValue));
        }

        public double[] GetDoubleArray(double[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetDoubleArray(key) ?? defaultValue);
        }

        public float GetFloat(float defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetFloat(key, defaultValue));
        }

        public float[] GetFloatArray(float[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetFloatArray(key) ?? defaultValue);
        }

        public int GetInt(int defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetInt(key, defaultValue));
        }

        public int[] GetIntArray(int[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetIntArray(key) ?? defaultValue);
        }

        public long GetLong(long defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetLong(key, defaultValue));
        }

        public long[] GetLongArray(long[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetLongArray(key) ?? defaultValue);
        }

        public short GetShort(short defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetShort(key, defaultValue));
        }

        public short[] GetShortArray(short[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetShortArray(key) ?? defaultValue);
        }

        public string GetString(string defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetString(key, defaultValue));
        }

        public string[] GetStringArray(string[] defaultValue = default, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return GetValue(defaultValue, bundle => bundle.NotNull().GetStringArray(key) ?? defaultValue);
        }

        public void SetBool(bool value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutBoolean(key, value));
        }

        public void SetBoolArray(bool[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutBooleanArray(key, value));
        }

        public void SetByteArray(byte[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutByteArray(key, value));
        }

        public void SetChar(char value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutChar(key, value));
        }

        public void SetCharArray(char[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutCharArray(key, value));
        }

        public void SetDateTime(DateTime value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutDateTime(key, value));
        }

        public void SetDateTimeOffset(DateTimeOffset value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutDateTimeOffset(key, value));
        }

        public void SetDouble(double value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutDouble(key, value));
        }

        public void SetDoubleArray(double[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutDoubleArray(key, value));
        }

        public void SetFloat(float value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutFloat(key, value));
        }

        public void SetFloatArray(float[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutFloatArray(key, value));
        }

        public void SetInt(int value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutInt(key, value));
        }

        public void SetIntArray(int[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutIntArray(key, value));
        }

        public void SetLong(long value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutLong(key, value));
        }

        public void SetLongArray(long[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutLongArray(key, value));
        }

        public void SetShort(short value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutShort(key, value));
        }

        public void SetShortArray(short[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutShortArray(key, value));
        }

        public void SetString(string value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutString(key, value));
        }

        public void SetStringArray(string[] value, string key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            SetValue(bundle => bundle.NotNull().PutStringArray(key, value));
        }

        public object ToNative()
        {
            return _bundle;
        }

        [CanBeNull]
        private T GetValue<T>([CanBeNull] T defaultValue, [NotNull] Func<Bundle, T> getValue)
        {
            return _bundle != null ? getValue(_bundle) : defaultValue;
        }

        private void SetValue([NotNull] Action<Bundle> setValue)
        {
            if (_bundle == null)
                _bundle = new Bundle();

            setValue(_bundle);
        }
    }
}
