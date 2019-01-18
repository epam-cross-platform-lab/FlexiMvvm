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
using System.Linq;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions.Generation
{
    public class ExtensionsGenerationOptions
    {
        public ExtensionsGenerationOptions([NotNull] string className, [CanBeNull] params EventGenerationOptions[] eventsGenerationOptions)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ClassName));

            ClassName = className;
            TypeEventsGenerationOptions = eventsGenerationOptions ?? Enumerable.Empty<EventGenerationOptions>();
            TypeEventsWithCustomEventHandlerGenerationOptions = TypeEventsGenerationOptions
                .Where(options => !options.NotNull().EventHandlerClassName.WithoutNamespace().WithoutGenericPart().Equals(nameof(EventHandler)))
                .DistinctBy(options => options.NotNull().EventHandlerClassName)
                .ToList();
        }

        [CanBeNull]
        public string TargetNamespace { get; set; }

        [NotNull]
        public string ClassName { get; }

        [NotNull]
        public IEnumerable<EventGenerationOptions> TypeEventsGenerationOptions { get; }

        [NotNull]
        public IEnumerable<EventGenerationOptions> TypeEventsWithCustomEventHandlerGenerationOptions { get; }
    }
}
