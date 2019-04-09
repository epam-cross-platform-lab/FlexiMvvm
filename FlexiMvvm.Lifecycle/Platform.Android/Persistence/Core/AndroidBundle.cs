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

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <inheritdoc />
        public int Count => _bundle.KeySet().Count;

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

            return _bundle.GetBoolean(key, defaultValue);
        }

        /// <inheritdoc />
        public bool[]? GetBoolArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetBooleanArray(key);
        }

        /// <inheritdoc />
        public byte[]? GetByteArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetByteArray(key);
        }

        /// <inheritdoc />
        public char GetChar(char defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetChar(key, defaultValue);
        }

        /// <inheritdoc />
        public char[]? GetCharArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetCharArray(key);
        }

        /// <inheritdoc />
        public DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetDateTime(key, defaultValue);
        }

        /// <inheritdoc />
        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetDateTimeOffset(key, defaultValue);
        }

        /// <inheritdoc />
        public double GetDouble(double defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetDouble(key, defaultValue);
        }

        /// <inheritdoc />
        public double[]? GetDoubleArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetDoubleArray(key);
        }

        /// <inheritdoc />
        public T GetEnum<T>(T defaultValue = default, [CallerMemberName] string? key = null)
            where T : struct, Enum
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetEnum(key, defaultValue);
        }

        /// <inheritdoc />
        public float GetFloat(float defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetFloat(key, defaultValue);
        }

        /// <inheritdoc />
        public float[]? GetFloatArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetFloatArray(key);
        }

        /// <inheritdoc />
        public int GetInt(int defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetInt(key, defaultValue);
        }

        /// <inheritdoc />
        public int[]? GetIntArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetIntArray(key);
        }

        /// <inheritdoc />
        public long GetLong(long defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetLong(key, defaultValue);
        }

        /// <inheritdoc />
        public long[]? GetLongArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetLongArray(key);
        }

        /// <inheritdoc />
        public short GetShort(short defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetShort(key, defaultValue);
        }

        /// <inheritdoc />
        public short[]? GetShortArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetShortArray(key);
        }

        /// <inheritdoc />
        public string? GetString(string? defaultValue = default, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetString(key, defaultValue);
        }

        /// <inheritdoc />
        public string[]? GetStringArray([CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            return _bundle.GetStringArray(key);
        }

        /// <inheritdoc />
        public bool SetBool(bool value, [CallerMemberName] string? key = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var existingValue = GetBool(key: key);

            if (existingValue != value || !ContainsKey(key))
            {
                _bundle.PutBoolean(key, value);
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
                _bundle.PutBooleanArray(key, value);
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
                _bundle.PutByteArray(key, value);
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
                _bundle.PutChar(key, value);
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
                _bundle.PutCharArray(key, value);
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
                _bundle.PutDateTime(key, value);
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
                _bundle.PutDateTimeOffset(key, value);
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
                _bundle.PutDouble(key, value);
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
                _bundle.PutDoubleArray(key, value);
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
                _bundle.PutEnum(key, value);
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
                _bundle.PutFloat(key, value);
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
                _bundle.PutFloatArray(key, value);
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
                _bundle.PutInt(key, value);
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
                _bundle.PutIntArray(key, value);
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
                _bundle.PutLong(key, value);
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
                _bundle.PutLongArray(key, value);
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
                _bundle.PutShort(key, value);
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
                _bundle.PutShortArray(key, value);
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
                _bundle.PutString(key, value);
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
