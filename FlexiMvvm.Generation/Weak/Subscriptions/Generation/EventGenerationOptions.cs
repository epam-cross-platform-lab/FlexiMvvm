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

namespace FlexiMvvm.Weak.Subscriptions.Generation
{
    public class EventGenerationOptions
    {
        public EventGenerationOptions([NotNull] string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(eventName));

            EventName = eventName;
        }

        public EventGenerationOptions([NotNull] string eventName, [NotNull] string eventArgsClassName)
            : this(eventName)
        {
            if (string.IsNullOrWhiteSpace(eventArgsClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(eventArgsClassName));

            EventArgsClassName = eventArgsClassName;
        }

        public EventGenerationOptions([NotNull] string eventName, [NotNull] string eventArgsClassName, [NotNull] string eventHandlerClassName)
            : this(eventName, eventArgsClassName)
        {
            if (string.IsNullOrWhiteSpace(eventHandlerClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(eventHandlerClassName));

            EventHandlerClassName = eventHandlerClassName;
        }

        [NotNull]
        public string EventName { get; }

        [CanBeNull]
        public string EventHandlerClassName { get; }

        [CanBeNull]
        public string EventArgsClassName { get; }
    }
}
