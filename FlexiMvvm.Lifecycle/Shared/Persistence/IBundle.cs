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
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace FlexiMvvm.Persistence
{
    public interface IBundle
    {
        bool IsEmpty { get; }

        bool ContainsKey([NotNull] string key);

        bool GetBool(bool defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        bool[] GetBoolArray([CanBeNull] bool[] defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        byte[] GetByteArray([CanBeNull] byte[] defaultValue = default, [CallerMemberName] string key = null);

        char GetChar(char defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        char[] GetCharArray([CanBeNull] char[] defaultValue = default, [CallerMemberName] string key = null);

        DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string key = null);

        DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string key = null);

        double GetDouble(double defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        double[] GetDoubleArray([CanBeNull] double[] defaultValue = default, [CallerMemberName] string key = null);

        float GetFloat(float defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        float[] GetFloatArray([CanBeNull] float[] defaultValue = default, [CallerMemberName] string key = null);

        int GetInt(int defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        int[] GetIntArray([CanBeNull] int[] defaultValue = default, [CallerMemberName] string key = null);

        long GetLong(long defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        long[] GetLongArray([CanBeNull] long[] defaultValue = default, [CallerMemberName] string key = null);

        short GetShort(short defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        short[] GetShortArray([CanBeNull] short[] defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        string GetString([CanBeNull] string defaultValue = default, [CallerMemberName] string key = null);

        [CanBeNull]
        string[] GetStringArray([CanBeNull] string[] defaultValue = default, [CallerMemberName] string key = null);

        void SetBool(bool value, [CallerMemberName] string key = null);

        void SetBoolArray([CanBeNull] bool[] value, [CallerMemberName] string key = null);

        void SetByteArray([CanBeNull] byte[] value, [CallerMemberName] string key = null);

        void SetChar(char value, [CallerMemberName] string key = null);

        void SetCharArray([CanBeNull] char[] value, [CallerMemberName] string key = null);

        void SetDateTime(DateTime value, [CallerMemberName] string key = null);

        void SetDateTimeOffset(DateTimeOffset value, [CallerMemberName] string key = null);

        void SetDouble(double value, [CallerMemberName] string key = null);

        void SetDoubleArray([CanBeNull] double[] value, [CallerMemberName] string key = null);

        void SetFloat(float value, [CallerMemberName] string key = null);

        void SetFloatArray([CanBeNull] float[] value, [CallerMemberName] string key = null);

        void SetInt(int value, [CallerMemberName] string key = null);

        void SetIntArray([CanBeNull] int[] value, [CallerMemberName] string key = null);

        void SetLong(long value, [CallerMemberName] string key = null);

        void SetLongArray([CanBeNull] long[] value, [CallerMemberName] string key = null);

        void SetShort(short value, [CallerMemberName] string key = null);

        void SetShortArray([CanBeNull] short[] value, [CallerMemberName] string key = null);

        void SetString([CanBeNull] string value, [CallerMemberName] string key = null);

        void SetStringArray([CanBeNull] string[] value, [CallerMemberName] string key = null);

        [CanBeNull]
        object ToNative();
    }
}
