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

namespace FlexiMvvm.Persistence
{
    public interface IBundle : INotifyPropertyChanged
    {
        int Count { get; }

        bool IsEmpty { get; }

        bool ContainsKey(string key);

        bool GetBool(bool defaultValue = default, [CallerMemberName] string? key = null);

        bool[]? GetBoolArray(bool[]? defaultValue = default, [CallerMemberName] string? key = null);

        byte[]? GetByteArray(byte[]? defaultValue = default, [CallerMemberName] string? key = null);

        char GetChar(char defaultValue = default, [CallerMemberName] string? key = null);

        char[]? GetCharArray(char[]? defaultValue = default, [CallerMemberName] string? key = null);

        DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string? key = null);

        DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string? key = null);

        double GetDouble(double defaultValue = default, [CallerMemberName] string? key = null);

        double[]? GetDoubleArray(double[]? defaultValue = default, [CallerMemberName] string? key = null);

        T GetEnum<T>(T defaultValue = default, [CallerMemberName] string? key = null)
            where T : struct, Enum;

        float GetFloat(float defaultValue = default, [CallerMemberName] string? key = null);

        float[]? GetFloatArray(float[]? defaultValue = default, [CallerMemberName] string? key = null);

        int GetInt(int defaultValue = default, [CallerMemberName] string? key = null);

        int[]? GetIntArray(int[]? defaultValue = default, [CallerMemberName] string? key = null);

        long GetLong(long defaultValue = default, [CallerMemberName] string? key = null);

        long[]? GetLongArray(long[]? defaultValue = default, [CallerMemberName] string? key = null);

        short GetShort(short defaultValue = default, [CallerMemberName] string? key = null);

        short[]? GetShortArray(short[]? defaultValue = default, [CallerMemberName] string? key = null);

        string? GetString(string? defaultValue = default, [CallerMemberName] string? key = null);

        string[]? GetStringArray(string[]? defaultValue = default, [CallerMemberName] string? key = null);

        bool SetBool(bool value, [CallerMemberName] string? key = null);

        bool SetBoolArray(bool[]? value, [CallerMemberName] string? key = null);

        bool SetByteArray(byte[]? value, [CallerMemberName] string? key = null);

        bool SetChar(char value, [CallerMemberName] string? key = null);

        bool SetCharArray(char[]? value, [CallerMemberName] string? key = null);

        bool SetDateTime(DateTime value, [CallerMemberName] string? key = null);

        bool SetDateTimeOffset(DateTimeOffset value, [CallerMemberName] string? key = null);

        bool SetDouble(double value, [CallerMemberName] string? key = null);

        bool SetDoubleArray(double[]? value, [CallerMemberName] string? key = null);

        bool SetEnum<T>(T value, [CallerMemberName] string? key = null)
            where T : struct, Enum;

        bool SetFloat(float value, [CallerMemberName] string? key = null);

        bool SetFloatArray(float[]? value, [CallerMemberName] string? key = null);

        bool SetInt(int value, [CallerMemberName] string? key = null);

        bool SetIntArray(int[]? value, [CallerMemberName] string? key = null);

        bool SetLong(long value, [CallerMemberName] string? key = null);

        bool SetLongArray(long[]? value, [CallerMemberName] string? key = null);

        bool SetShort(short value, [CallerMemberName] string? key = null);

        bool SetShortArray(short[]? value, [CallerMemberName] string? key = null);

        bool SetString(string? value, [CallerMemberName] string? key = null);

        bool SetStringArray(string[]? value, [CallerMemberName] string? key = null);
    }
}
