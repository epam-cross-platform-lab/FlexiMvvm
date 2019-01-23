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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence
{
    public interface IBundle : INotifyPropertyChanged
    {
        bool IsEmpty { get; }

        bool ContainsProperty([NotNull] string propertyName);

        bool GetBool(bool defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        bool[] GetBoolArray([CanBeNull] bool[] defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        byte[] GetByteArray([CanBeNull] byte[] defaultValue = default, [CallerMemberName] string propertyName = null);

        char GetChar(char defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        char[] GetCharArray([CanBeNull] char[] defaultValue = default, [CallerMemberName] string propertyName = null);

        DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string propertyName = null);

        DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string propertyName = null);

        double GetDouble(double defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        double[] GetDoubleArray([CanBeNull] double[] defaultValue = default, [CallerMemberName] string propertyName = null);

        T GetEnum<T>(T defaultValue = default, [CallerMemberName] string propertyName = null)
            where T : Enum;

        float GetFloat(float defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        float[] GetFloatArray([CanBeNull] float[] defaultValue = default, [CallerMemberName] string propertyName = null);

        int GetInt(int defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        int[] GetIntArray([CanBeNull] int[] defaultValue = default, [CallerMemberName] string propertyName = null);

        long GetLong(long defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        long[] GetLongArray([CanBeNull] long[] defaultValue = default, [CallerMemberName] string propertyName = null);

        short GetShort(short defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        short[] GetShortArray([CanBeNull] short[] defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        string GetString([CanBeNull] string defaultValue = default, [CallerMemberName] string propertyName = null);

        [CanBeNull]
        string[] GetStringArray([CanBeNull] string[] defaultValue = default, [CallerMemberName] string propertyName = null);

        bool SetBool(bool value, [CallerMemberName] string propertyName = null);

        bool SetBoolArray([CanBeNull] bool[] value, [CallerMemberName] string propertyName = null);

        bool SetByteArray([CanBeNull] byte[] value, [CallerMemberName] string propertyName = null);

        bool SetChar(char value, [CallerMemberName] string propertyName = null);

        bool SetCharArray([CanBeNull] char[] value, [CallerMemberName] string propertyName = null);

        bool SetDateTime(DateTime value, [CallerMemberName] string propertyName = null);

        bool SetDateTimeOffset(DateTimeOffset value, [CallerMemberName] string propertyName = null);

        bool SetDouble(double value, [CallerMemberName] string propertyName = null);

        bool SetDoubleArray([CanBeNull] double[] value, [CallerMemberName] string propertyName = null);

        bool SetEnum<T>(T value, [CallerMemberName] string propertyName = null)
            where T : Enum;

        bool SetFloat(float value, [CallerMemberName] string propertyName = null);

        bool SetFloatArray([CanBeNull] float[] value, [CallerMemberName] string propertyName = null);

        bool SetInt(int value, [CallerMemberName] string propertyName = null);

        bool SetIntArray([CanBeNull] int[] value, [CallerMemberName] string propertyName = null);

        bool SetLong(long value, [CallerMemberName] string propertyName = null);

        bool SetLongArray([CanBeNull] long[] value, [CallerMemberName] string propertyName = null);

        bool SetShort(short value, [CallerMemberName] string propertyName = null);

        bool SetShortArray([CanBeNull] short[] value, [CallerMemberName] string propertyName = null);

        bool SetString([CanBeNull] string value, [CallerMemberName] string propertyName = null);

        bool SetStringArray([CanBeNull] string[] value, [CallerMemberName] string propertyName = null);
    }
}
