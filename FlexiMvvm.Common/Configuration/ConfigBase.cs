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
using JetBrains.Annotations;

namespace FlexiMvvm.Configuration
{
    public abstract class ConfigBase : IConfig
    {
        [CanBeNull]
        private Dictionary<string, object> _values;

        [NotNull]
        private Dictionary<string, object> Values => _values ?? (_values = new Dictionary<string, object>());

        T IConfig.GetValue<T>(string key, T defaultValue)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (T)_values.GetValueOrDefault(key, defaultValue);
        }

        void IConfig.SetValue<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            Values[key] = value;
        }
    }
}
