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
using JetBrains.Annotations;

namespace FlexiMvvm.Configuration
{
    public static class FlexiMvvmConfigExtensions
    {
        private const string ShouldRaisePropertyChangedKey = "ShouldRaisePropertyChanged";

        public static bool ShouldRaisePropertyChanged([NotNull] this FlexiMvvmConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return config.GetValue(ShouldRaisePropertyChangedKey, true);
        }

        public static void ShouldRaisePropertyChanged([NotNull] this FlexiMvvmConfig config, bool value)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            config.SetValue(ShouldRaisePropertyChangedKey, value);
        }
    }
}
