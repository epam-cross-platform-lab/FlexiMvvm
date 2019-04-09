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
using System.Runtime.CompilerServices;

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

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        public int Count => _bundle.Count;

        /// <inheritdoc />
        public bool ContainsKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.ContainsKey(key);
        }

        /// <inheritdoc />
        public bool GetBool(bool defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (bool)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public bool[]? GetBoolArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (bool[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public byte[]? GetByteArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (byte[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public char GetChar(char defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (char)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public char[]? GetCharArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (char[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (DateTime)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (DateTimeOffset)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public double GetDouble(double defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (double)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public double[]? GetDoubleArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (double[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public T GetEnum<T>(T defaultValue = default, [CallerMemberName] string? key = null)
            where T : struct, Enum
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (T)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public float GetFloat(float defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (float)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public float[]? GetFloatArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (float[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public int GetInt(int defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (int)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public int[]? GetIntArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (int[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public long GetLong(long defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (long)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public long[]? GetLongArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (long[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public short GetShort(short defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (short)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public short[]? GetShortArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (short[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public string? GetString(string? defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (string?)_bundle.GetValueOrDefault(key, defaultValue);
        }

        /// <inheritdoc />
        public string[]? GetStringArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return (string[]?)_bundle.GetValueOrDefault(key, null);
        }

        /// <inheritdoc />
        public bool SetBool(bool value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetBool(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetBoolArray(bool[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetBoolArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetByteArray(byte[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetByteArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetChar(char value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetChar(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetCharArray(char[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetCharArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetDateTime(DateTime value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetDateTime(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetDateTimeOffset(DateTimeOffset value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetDateTimeOffset(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetDouble(double value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetDouble(key: key);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetDoubleArray(double[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetDoubleArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetEnum<T>(T value, [CallerMemberName] string? key = null)
            where T : struct, Enum
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetEnum<T>(key: key);

            if (!EqualityComparer<T>.Default.Equals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetFloat(float value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetFloat(key: key);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetFloatArray(float[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetFloatArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetInt(int value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetInt(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetIntArray(int[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetIntArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetLong(long value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetLong(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetLongArray(long[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetLongArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetShort(short value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetShort(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetShortArray(short[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetShortArray(key: key);

            if (!ReferenceEquals(existingValue, value) || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetString(string? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetString(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle[key] = value;
                OnPropertyChanged(key);

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public bool SetStringArray(string[]? value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

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
