﻿// =========================================================================
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
using FlexiMvvm.Collections;

namespace FlexiMvvm.Configuration
{
    /// <summary>
    /// Represents a FlexiMvvm configuration. Used for FlexiMvvm customization.
    /// </summary>
    public sealed class FlexiMvvmConfig : ValueSet
    {
        private static readonly Lazy<FlexiMvvmConfig> LazyInstance = new Lazy<FlexiMvvmConfig>(() => new FlexiMvvmConfig());

        private FlexiMvvmConfig()
        {
        }

        /// <summary>
        /// Gets the current instance of <see cref="FlexiMvvmConfig"/>.
        /// </summary>
        public static FlexiMvvmConfig Instance => LazyInstance.Value;
    }
}
