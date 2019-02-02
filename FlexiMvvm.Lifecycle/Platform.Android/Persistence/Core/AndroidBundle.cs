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
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence.Core
{
    internal sealed class AndroidBundle : IBundle, INativeBundleOwner
    {
        private const double ComparisonTolerance = 1E-10;

        [NotNull]
        private readonly Bundle _bundle;

        internal AndroidBundle([NotNull] Bundle bundle)
        {
            _bundle = bundle;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEmpty => _bundle.IsEmpty;

        public bool ContainsProperty(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.ContainsKey(propertyName);
        }

        public bool GetBool(bool defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetBoolean(propertyName, defaultValue);
        }

        public bool[] GetBoolArray(bool[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetBooleanArray(propertyName) ?? defaultValue;
        }

        public byte[] GetByteArray(byte[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetByteArray(propertyName) ?? defaultValue;
        }

        public char GetChar(char defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetChar(propertyName, defaultValue);
        }

        public char[] GetCharArray(char[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetCharArray(propertyName) ?? defaultValue;
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetDateTime(propertyName, defaultValue);
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetDateTimeOffset(propertyName, defaultValue);
        }

        public double GetDouble(double defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetDouble(propertyName, defaultValue);
        }

        public double[] GetDoubleArray(double[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetDoubleArray(propertyName) ?? defaultValue;
        }

        public T GetEnum<T>(T defaultValue = default, string propertyName = null)
            where T : Enum
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetEnum(propertyName, defaultValue);
        }

        public float GetFloat(float defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetFloat(propertyName, defaultValue);
        }

        public float[] GetFloatArray(float[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetFloatArray(propertyName) ?? defaultValue;
        }

        public int GetInt(int defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetInt(propertyName, defaultValue);
        }

        public int[] GetIntArray(int[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetIntArray(propertyName) ?? defaultValue;
        }

        public long GetLong(long defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetLong(propertyName, defaultValue);
        }

        public long[] GetLongArray(long[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetLongArray(propertyName) ?? defaultValue;
        }

        public short GetShort(short defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetShort(propertyName, defaultValue);
        }

        public short[] GetShortArray(short[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetShortArray(propertyName) ?? defaultValue;
        }

        public string GetString(string defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetString(propertyName, defaultValue);
        }

        public string[] GetStringArray(string[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return _bundle.GetStringArray(propertyName) ?? defaultValue;
        }

        public bool SetBool(bool value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetBool(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutBoolean(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetBoolArray(bool[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetBoolArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutBooleanArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetByteArray(byte[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetByteArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutByteArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetChar(char value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetChar(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutChar(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetCharArray(char[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetCharArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutCharArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetDateTime(DateTime value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetDateTime(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutDateTime(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetDateTimeOffset(DateTimeOffset value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetDateTimeOffset(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutDateTimeOffset(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetDouble(double value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetDouble(propertyName: propertyName);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsProperty(propertyName))
            {
                _bundle.PutDouble(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetDoubleArray(double[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetDoubleArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutDoubleArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetEnum<T>(T value, string propertyName = null)
            where T : Enum
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetEnum<T>(propertyName: propertyName);

            if (!EqualityComparer<T>.Default.Equals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutEnum(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetFloat(float value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetFloat(propertyName: propertyName);

            if (Math.Abs(existingValue - value) > ComparisonTolerance || !ContainsProperty(propertyName))
            {
                _bundle.PutFloat(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetFloatArray(float[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetFloatArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutFloatArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetInt(int value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetInt(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutInt(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetIntArray(int[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetIntArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutIntArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetLong(long value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetLong(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutLong(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetLongArray(long[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetLongArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutLongArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetShort(short value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetShort(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutShort(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetShortArray(short[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetShortArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutShortArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetString(string value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetString(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle.PutString(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        public bool SetStringArray(string[] value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetStringArray(propertyName: propertyName);

            if (!ReferenceEquals(existingValue, value) || !ContainsProperty(propertyName))
            {
                _bundle.PutStringArray(propertyName, value);
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        Bundle INativeBundleOwner.ExportNativeBundle()
        {
            return _bundle;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([NotNull] string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
