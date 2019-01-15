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

namespace FlexiMvvm.Views.Generation.Ios
{
    public class ViewGenerationOptions
    {
        public ViewGenerationOptions([NotNull] string className, [NotNull] string baseClassName)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(className));
            if (string.IsNullOrWhiteSpace(baseClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(baseClassName));

            ClassName = className;
            BaseClassName = baseClassName;
        }

        [CanBeNull]
        public string TargetNamespace { get; set; }

        [NotNull]
        public string ClassName { get; }

        [NotNull]
        public string BaseClassName { get; }

        public bool HandleKeyboard { get; set; }
    }
}
