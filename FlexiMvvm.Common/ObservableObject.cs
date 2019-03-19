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
using FlexiMvvm.Configuration;

namespace FlexiMvvm
{
    /// <inheritdoc />
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the new <paramref name="value"/> if it was changed to the <paramref name="field"/> and
        /// raises <see cref="INotifyPropertyChanged.PropertyChanged"/> event with the <paramref name="propertyName"/> value.
        /// <para><see cref="INotifyPropertyChanged.PropertyChanged"/> event won't be raised if it is suppressed by setting <c>false</c> for
        /// <see cref="FlexiMvvmConfigExtensions.ShouldRaisePropertyChanged(FlexiMvvmConfig, bool)"/>.</para>
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="field">The backing field for the value.</param>
        /// <param name="value">The new value.</param>
        /// <param name="propertyName">The property name to which set the value.</param>
        /// <returns><c>true</c> if the new value was set; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is a zero-length string or whitespace.</exception>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be a zero-length string or whitespace.", nameof(propertyName));

            if (!EqualityComparer<T>.Default.NotNull().Equals(field, value))
            {
                field = value;

                if (FlexiMvvmConfig.Instance.ShouldRaisePropertyChanged())
                {
                    RaisePropertyChanged(propertyName);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Raises <see cref="INotifyPropertyChanged.PropertyChanged"/> event with the <paramref name="propertyName"/> value.
        /// </summary>
        /// <param name="propertyName">The property name which value was changed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is a zero-length string or whitespace.</exception>
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Value cannot be a zero-length string or whitespace.", nameof(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
