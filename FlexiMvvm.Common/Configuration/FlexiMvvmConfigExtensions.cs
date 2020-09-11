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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace FlexiMvvm.Configuration
{
    /// <summary>
    /// Provides a set of static methods for <see cref="FlexiMvvmConfig"/>.
    /// </summary>
    public static class FlexiMvvmConfigExtensions
    {
        private const string ShouldRaisePropertyChangedKey = "ShouldRaisePropertyChanged";
        private const string LoggerFactoryKey = "LoggerFactory";

        /// <summary>
        /// Determines whether FlexiMvvm classes which implement <see cref="INotifyPropertyChanged"/>
        /// should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="config">The FlexiMvvm configuration.</param>
        /// <returns><see langword="true"/> if FlexiMvvm classes raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event;
        /// otherwise, <see langword="false"/>. Returns <see langword="true"/> by default.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <see langword="null"/>.</exception>
        public static bool ShouldRaisePropertyChanged(this FlexiMvvmConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return config.GetValue(ShouldRaisePropertyChangedKey, true);
        }

        /// <summary>
        /// Allows to customize whether FlexiMvvm classes which implement <see cref="INotifyPropertyChanged"/>
        /// should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
        /// </summary>
        /// <param name="config">The FlexiMvvm configuration.</param>
        /// <param name="value"><see langword="true"/> if FlexiMvvm classes should raise <see cref="INotifyPropertyChanged.PropertyChanged"/> event;
        /// otherwise, <see langword="false"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <see langword="null"/>.</exception>
        public static void ShouldRaisePropertyChanged(this FlexiMvvmConfig config, bool value)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            config.SetValue(ShouldRaisePropertyChangedKey, value);
        }

        /// <summary>
        /// Returns a logger factory instance. This method is intended for internal use by FlexiMvvm.
        /// </summary>
        /// <param name="config">The FlexiMvvm configuration.</param>
        /// <returns>The logger factory instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is <see langword="null"/>.</exception>
        public static ILoggerFactory GetLoggerFactory(this FlexiMvvmConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return config.GetValue<ILoggerFactory>(LoggerFactoryKey, NullLoggerFactory.Instance);
        }

        /// <summary>
        /// Sets the logger factory instance. FlexiMvvm uses this logger factory to log its diagnostic events.
        /// </summary>
        /// <param name="config">The FlexiMvvm configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="config"/> or <paramref name="loggerFactory"/> is <see langword="null"/>.
        /// </exception>
        public static void SetLoggerFactory(this FlexiMvvmConfig config, ILoggerFactory loggerFactory)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            config.SetValue(LoggerFactoryKey, loggerFactory);
        }
    }
}
