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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FlexiMvvm.Persistence;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public class ViewModelState
    {
        [NotNull]
        private readonly IViewModel _viewModel;

        internal ViewModelState([NotNull] IViewModel viewModel, [NotNull] IBundle bundle)
        {
            _viewModel = viewModel;
            Bundle = bundle;
        }

        [NotNull]
        internal IBundle Bundle { get; }

        public bool IsEmpty => Bundle.IsEmpty;

        public bool ContainsProperty([NotNull] string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.ContainsKey(propertyName);
        }

        public bool GetBool(bool defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetBool(defaultValue, propertyName);
        }

        [CanBeNull]
        public bool[] GetBoolArray([CanBeNull] bool[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetBoolArray(defaultValue, propertyName);
        }

        [CanBeNull]
        public byte[] GetByteArray([CanBeNull] byte[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetByteArray(defaultValue, propertyName);
        }

        public char GetChar(char defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetChar(defaultValue, propertyName);
        }

        [CanBeNull]
        public char[] GetCharArray([CanBeNull] char[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetCharArray(defaultValue, propertyName);
        }

        public DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetDateTime(defaultValue, propertyName);
        }

        public DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetDateTimeOffset(defaultValue, propertyName);
        }

        public double GetDouble(double defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetDouble(defaultValue, propertyName);
        }

        [CanBeNull]
        public double[] GetDoubleArray([CanBeNull] double[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetDoubleArray(defaultValue, propertyName);
        }

        public float GetFloat(float defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetFloat(defaultValue, propertyName);
        }

        [CanBeNull]
        public float[] GetFloatArray([CanBeNull] float[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetFloatArray(defaultValue, propertyName);
        }

        public int GetInt(int defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetInt(defaultValue, propertyName);
        }

        [CanBeNull]
        public int[] GetIntArray([CanBeNull] int[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetIntArray(defaultValue, propertyName);
        }

        public long GetLong(long defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetLong(defaultValue, propertyName);
        }

        [CanBeNull]
        public long[] GetLongArray([CanBeNull] long[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetLongArray(defaultValue, propertyName);
        }

        public short GetShort(short defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetShort(defaultValue, propertyName);
        }

        [CanBeNull]
        public short[] GetShortArray([CanBeNull] short[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetShortArray(defaultValue, propertyName);
        }

        [CanBeNull]
        public string GetString([CanBeNull] string defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetString(defaultValue, propertyName);
        }

        [CanBeNull]
        public string[] GetStringArray([CanBeNull] string[] defaultValue = default, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return Bundle.GetStringArray(defaultValue, propertyName);
        }

        public bool SetBool(bool value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetBool(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetBool(value, propertyName));
        }

        public bool SetBoolArray([CanBeNull] bool[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetBoolArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetBoolArray(value, propertyName));
        }

        public bool SetByteArray([CanBeNull] byte[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetByteArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetByteArray(value, propertyName));
        }

        public bool SetChar(char value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetChar(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetChar(value, propertyName));
        }

        public bool SetCharArray([CanBeNull] char[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetCharArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetCharArray(value, propertyName));
        }

        public bool SetDateTime(DateTime value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetDateTime(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetDateTime(value, propertyName));
        }

        public bool SetDateTimeOffset(DateTimeOffset value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetDateTimeOffset(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetDateTimeOffset(value, propertyName));
        }

        public bool SetDouble(double value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

             return SetValue(GetDouble(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetDouble(value, propertyName));
        }

        public bool SetDoubleArray([CanBeNull] double[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetDoubleArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetDoubleArray(value, propertyName));
        }

        public bool SetFloat(float value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetFloat(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetFloat(value, propertyName));
        }

        public bool SetFloatArray([CanBeNull] float[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetFloatArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetFloatArray(value, propertyName));
        }

        public bool SetInt(int value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetInt(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetInt(value, propertyName));
        }

        public bool SetIntArray([CanBeNull] int[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetIntArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetIntArray(value, propertyName));
        }

        public bool SetLong(long value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetLong(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetLong(value, propertyName));
        }

        public bool SetLongArray([CanBeNull] long[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetLongArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetLongArray(value, propertyName));
        }

        public bool SetShort(short value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetShort(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetShort(value, propertyName));
        }

        public bool SetShortArray([CanBeNull] short[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetShortArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetShortArray(value, propertyName));
        }

        public bool SetString([CanBeNull] string value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetString(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetString(value, propertyName));
        }

        public bool SetStringArray([CanBeNull] string[] value, bool raisePropertyChanged = true, [CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(propertyName));

            return SetValue(GetStringArray(propertyName: propertyName), value, raisePropertyChanged, propertyName, () => Bundle.SetStringArray(value, propertyName));
        }

        private bool SetValue<T>(
            [CanBeNull] T existingValue,
            [CanBeNull] T newValue,
            bool raisePropertyChanged,
            [NotNull] string propertyName,
            [NotNull] Action setValue)
        {
            if (!EqualityComparer<T>.Default.NotNull().Equals(existingValue, newValue))
            {
                setValue();

                if (raisePropertyChanged)
                {
                    _viewModel.RaisePropertyChanged(propertyName);
                }

                return true;
            }

            return false;
        }
    }
}
