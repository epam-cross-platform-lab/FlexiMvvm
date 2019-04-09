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
    /// <summary>
    /// Defines the contract for a container that stores data as a set of key/value pairs in view's persistent storage.
    /// </summary>
    public interface IBundle : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the number of key/value pairs contained in the bundle.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Determines whether the bundle contains the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key to locate in the bundle.</param>
        /// <returns><see langword="true"/> if the bundle contains an element with the specified key; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool ContainsKey(string key);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool GetBool(bool defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool[]? GetBoolArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        byte[]? GetByteArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        char GetChar(char defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        char[]? GetCharArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        DateTime GetDateTime(DateTime defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        DateTimeOffset GetDateTimeOffset(DateTimeOffset defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        double GetDouble(double defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        double[]? GetDoubleArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        T GetEnum<T>(T defaultValue = default, [CallerMemberName] string? key = null)
            where T : struct, Enum;

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        float GetFloat(float defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        float[]? GetFloatArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        int GetInt(int defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        int[]? GetIntArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        long GetLong(long defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        long[]? GetLongArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        short GetShort(short defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        short[]? GetShortArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <paramref name="defaultValue"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="defaultValue">The default value to return if no matching key is found in the bundle.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <paramref name="defaultValue"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        string? GetString(string? defaultValue = default, [CallerMemberName] string? key = null);

        /// <summary>
        /// Returns the value for a given <paramref name="key"/>, or <see langword="null"/> if no matching <paramref name="key"/> is found in the bundle.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value for the key, or <see langword="null"/> if no matching key was found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        string[]? GetStringArray([CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetBool(bool value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetBoolArray(bool[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetByteArray(byte[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetChar(char value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetCharArray(char[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetDateTime(DateTime value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetDateTimeOffset(DateTimeOffset value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetDouble(double value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetDoubleArray(double[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration.</typeparam>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetEnum<T>(T value, [CallerMemberName] string? key = null)
            where T : struct, Enum;

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetFloat(float value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetFloatArray(float[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetInt(int value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetIntArray(int[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetLong(long value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetLongArray(long[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetShort(short value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetShortArray(short[]? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if it is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetString(string? value, [CallerMemberName] string? key = null);

        /// <summary>
        /// Sets the value for a given <paramref name="key"/>, replacing the existing value if its reference is not equal to the new one.
        /// </summary>
        /// <param name="value">The value to set in the bundle. Can be <see langword="null"/>.</param>
        /// <param name="key">The key of the value to set.</param>
        /// <returns><see langword="true"/> if the new value was set; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <see langword="null"/>.</exception>
        bool SetStringArray(string[]? value, [CallerMemberName] string? key = null);
    }
}
