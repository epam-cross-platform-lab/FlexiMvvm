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

namespace FlexiMvvm.Configuration
{
    /// <summary>
    /// Provides a set of static methods for <see cref="FlexiMvvmConfig"/>.
    /// </summary>
    public static class FlexiMvvmConfigExtensions
    {
        private const string ShouldRaisePropertyChangedKey = "ShouldRaisePropertyChanged";

        /// <summary>
        /// Determines whether FlexiMvvm classes which implement <see cref="INotifyPropertyChanged"/> should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="config">>The FlexiMvvm configuration.</param>
        /// <returns><c>true</c> if FlexiMvvm classes raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <c>null</c>.</exception>
        public static bool ShouldRaisePropertyChanged(this FlexiMvvmConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return config.GetValue(ShouldRaisePropertyChangedKey, true);
        }

        /// <summary>
        /// Determines whether FlexiMvvm classes which implement <see cref="INotifyPropertyChanged"/> should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="config">The FlexiMvvm configuration.</param>
        /// <param name="value"><c>true</c> if FlexiMvvm classes should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event; otherwise, <c>false</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <c>null</c>.</exception>
        public static void ShouldRaisePropertyChanged(this FlexiMvvmConfig config, bool value)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            config.SetValue(ShouldRaisePropertyChangedKey, value);
        }
    }
}
