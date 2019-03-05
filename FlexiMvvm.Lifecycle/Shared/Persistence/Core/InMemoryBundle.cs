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

namespace FlexiMvvm.Persistence.Core
{
    internal sealed class InMemoryBundle : IBundle
    {
        private const double ComparisonTolerance = 1E-10;

        private readonly IDictionary<string, object?> _bundle;

        internal InMemoryBundle(IDictionary<string, object?> bundle)
        {
            _bundle = bundle;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Count => _bundle.Count;

        public bool IsEmpty => _bundle.Count == 0;

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

            return (bool)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public bool[]? GetBoolArray(bool[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (bool[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public byte[]? GetByteArray(byte[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (byte[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public char GetChar(char defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (char)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public char[]? GetCharArray(char[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (char[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (DateTime)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (DateTimeOffset)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public double GetDouble(double defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (double)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public double[]? GetDoubleArray(double[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (double[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public T GetEnum<T>(T defaultValue = default, string? key = null)
            where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (T)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public float GetFloat(float defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (float)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public float[]? GetFloatArray(float[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (float[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public int GetInt(int defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (int)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public int[]? GetIntArray(int[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (int[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public long GetLong(long defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (long)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public long[]? GetLongArray(long[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (long[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public short GetShort(short defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (short)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public short[]? GetShortArray(short[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (short[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public string? GetString(string? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (string?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public string[]? GetStringArray(string[]? defaultValue = default, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (string[]?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        public bool SetBool(bool value, string? key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            var existingValue = GetBool(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
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
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        private void OnPropertyChanged(string key)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        }
    }
}
