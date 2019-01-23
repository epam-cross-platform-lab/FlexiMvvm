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
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence.Core
{
    internal sealed class InMemoryBundle : IBundle
    {
        private const double ComparisonTolerance = 1E-10;

        [NotNull]
        private readonly IDictionary<string, object> _bundle;

        internal InMemoryBundle(IDictionary<string, object> bundle)
        {
            _bundle = bundle ?? throw new ArgumentNullException(nameof(bundle));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEmpty => _bundle.Count == 0;

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

            return (bool)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public bool[] GetBoolArray(bool[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (bool[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public byte[] GetByteArray(byte[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (byte[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public char GetChar(char defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (char)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public char[] GetCharArray(char[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (char[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public DateTime GetDateTime(DateTime defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (DateTime)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (DateTimeOffset)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public double GetDouble(double defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (double)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public double[] GetDoubleArray(double[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (double[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public float GetFloat(float defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (float)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public float[] GetFloatArray(float[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (float[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public int GetInt(int defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (int)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public int[] GetIntArray(int[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (int[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public long GetLong(long defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (long)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public long[] GetLongArray(long[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (long[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public short GetShort(short defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (short)_bundle.GetValueOrDefault(propertyName, defaultValue).NotNull();
        }

        public short[] GetShortArray(short[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (short[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public string GetString(string defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (string)_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public string[] GetStringArray(string[] defaultValue = default, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return (string[])_bundle.GetValueOrDefault(propertyName, defaultValue);
        }

        public bool SetBool(bool value, string propertyName = null)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            var existingValue = GetBool(propertyName: propertyName);

            if (existingValue != value || !ContainsProperty(propertyName))
            {
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
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
                _bundle[propertyName] = value;
                OnPropertyChanged(propertyName);

                return true;
            }

            return false;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([NotNull] string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
