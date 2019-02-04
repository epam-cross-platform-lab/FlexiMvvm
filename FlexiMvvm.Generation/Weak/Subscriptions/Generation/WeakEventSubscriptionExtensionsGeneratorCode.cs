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
    public partial class WeakEventSubscriptionExtensionsGenerator
    {
        public WeakEventSubscriptionExtensionsGenerator([NotNull] string targetNamespace, [CanBeNull] params ExtensionsGenerationOptions[] extensionsGenerationOptions)
        {
            if (string.IsNullOrWhiteSpace(targetNamespace))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(targetNamespace));

            TargetNamespace = targetNamespace;
            TypesExtensionsGenerationOptions = extensionsGenerationOptions ?? Enumerable.Empty<ExtensionsGenerationOptions>();
        }

        [NotNull]
        private string TargetNamespace { get; }

        [NotNull]
        private IEnumerable<ExtensionsGenerationOptions> TypesExtensionsGenerationOptions { get; }

        [NotNull]
        private string GetNamespace([NotNull] ExtensionsGenerationOptions typeExtensionsGenerationOptions)
        {
            return string.IsNullOrEmpty(typeExtensionsGenerationOptions.TargetNamespace)
                ? TargetNamespace
                : typeExtensionsGenerationOptions.TargetNamespace;
        }

        [NotNull]
        private string GetClassName([NotNull] ExtensionsGenerationOptions typeExtensionsGenerationOptions)
        {
            var sanitizedClassName = string.IsNullOrWhiteSpace(typeExtensionsGenerationOptions.ExtensionsCustomClassName)
                ? typeExtensionsGenerationOptions.ClassName.WithoutNamespace().WithoutInterfacePrefix().WithoutGenericPart()
                : typeExtensionsGenerationOptions.ExtensionsCustomClassName.WithoutNamespace().WithoutInterfacePrefix().WithoutGenericPart();

            return $"{sanitizedClassName}WeakEventSubscriptionExtensions";
        }

        [NotNull]
        private string GetPassedEventHandlerDeclarationName([NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            return string.IsNullOrWhiteSpace(typeEventGenerationOptions.EventArgsClassName)
                ? nameof(EventHandler)
                : $"{nameof(EventHandler)}<{typeEventGenerationOptions.EventArgsClassName}>";
        }

        [NotNull]
        private string GetWeakEventSubscriptionClassName([NotNull] string typeClassName, [NotNull] EventGenerationOptions typeEventGenerationOptions)
        {
            if (string.IsNullOrWhiteSpace(typeClassName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(typeClassName));
            if (typeEventGenerationOptions == null)
                throw new ArgumentNullException(nameof(typeEventGenerationOptions));

            var sanitizedClassName = typeEventGenerationOptions.EventHandlerClassName.WithoutNamespace().WithoutGenericPart();

            return typeEventGenerationOptions.IsGenericEventHandler
                ? $"{sanitizedClassName}WeakEventSubscription<{typeClassName}, {typeEventGenerationOptions.EventArgsClassName}>"
                : $"{sanitizedClassName}WeakEventSubscription<{typeClassName}>";
        }
    }
}
