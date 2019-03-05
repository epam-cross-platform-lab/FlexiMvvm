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
using System.ComponentModel;
using Android.OS;
using FlexiMvvm.Views;

namespace FlexiMvvm.Persistence.Core
{
    internal sealed class AndroidBundle : IBundle, INativeBundleOwner
    {
        private const double ComparisonTolerance = 1E-10;

        private readonly Bundle _bundle;

        internal AndroidBundle(Bundle bundle)
        {
            _bundle = bundle;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Count => _bundle.KeySet().Count;

        public bool IsEmpty => _bundle.IsEmpty;

        public bool ContainsKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.ContainsKey(key);
        }

        public bool GetBool(bool defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetBoolean(key, defaultValue);
        }

        public bool[]? GetBoolArray(bool[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetBooleanArray(key) ?? defaultValue;
        }

        public byte[]? GetByteArray(byte[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetByteArray(key) ?? defaultValue;
        }

        public char GetChar(char defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetChar(key, defaultValue);
        }

        public char[]? GetCharArray(char[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetCharArray(key) ?? defaultValue;
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetDateTime(key, defaultValue);
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetDateTimeOffset(key, defaultValue);
        }

        public double GetDouble(double defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetDouble(key, defaultValue);
        }

        public double[]? GetDoubleArray(double[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetDoubleArray(key) ?? defaultValue;
        }

        public T GetEnum<T>(T defaultValue = default, string? key = null)
            where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetEnum(key, defaultValue);
        }

        public float GetFloat(float defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetFloat(key, defaultValue);
        }

        public float[]? GetFloatArray(float[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetFloatArray(key) ?? defaultValue;
        }

        public int GetInt(int defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetInt(key, defaultValue);
        }

        public int[]? GetIntArray(int[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetIntArray(key) ?? defaultValue;
        }

        public long GetLong(long defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetLong(key, defaultValue);
        }

        public long[]? GetLongArray(long[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetLongArray(key) ?? defaultValue;
        }

        public short GetShort(short defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetShort(key, defaultValue);
        }

        public short[]? GetShortArray(short[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetShortArray(key) ?? defaultValue;
        }

        public string? GetString(string? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetString(key, defaultValue);
        }

        public string[]? GetStringArray(string[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return _bundle.GetStringArray(key) ?? defaultValue;
        }

        public bool SetBool(bool value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetBool(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutBoolean(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetBoolArray(bool[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetBoolArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutBooleanArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetByteArray(byte[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetByteArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutByteArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetChar(char value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetChar(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutChar(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetCharArray(char[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetCharArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutCharArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetDateTime(DateTime value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetDateTime(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutDateTime(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetDateTimeOffset(DateTimeOffset value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetDateTimeOffset(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutDateTimeOffset(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetDouble(double value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetDouble(key: key);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsKey(key))
            {
                _bundle.PutDouble(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetDoubleArray(double[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetDoubleArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutDoubleArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetEnum<T>(T value, string? key = null)
            where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetEnum<T>(key: key);

            if (!EqualityComparer<T>.Default.Equals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutEnum(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetFloat(float value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetFloat(key: key);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsKey(key))
            {
                _bundle.PutFloat(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetFloatArray(float[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetFloatArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutFloatArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetInt(int value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetInt(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutInt(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetIntArray(int[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetIntArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutIntArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetLong(long value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetLong(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutLong(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetLongArray(long[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetLongArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutLongArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetShort(short value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetShort(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutShort(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetShortArray(short[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetShortArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutShortArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetString(string? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetString(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutString(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        public bool SetStringArray(string[]? value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetStringArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle.PutStringArray(key, value);
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        Bundle INativeBundleOwner.ExportNativeBundle()
        {
            return _bundle;
        }

        private void OnPropertyChanged(string key)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        }
    }
}
