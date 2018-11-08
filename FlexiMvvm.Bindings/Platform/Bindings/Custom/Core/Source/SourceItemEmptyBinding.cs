// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using System.Linq.Expressions;
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Source
{
    internal class SourceItemEmptyBinding<TItem, TValue> : SourceItemBinding<TItem, TValue>
        where TItem : class
    {
        internal SourceItemEmptyBinding(
            [NotNull] ItemReference<TItem> itemReference,
            [NotNull] Type sourceItemBindingType,
            [CanBeNull] LambdaExpression itemValue,
            [NotNull] Exception ex)
            : base(itemReference, () => LogFormatter.FormatExpression(itemValue))
        {
            Log($"\"{LogFormatter.FormatException(ex)}\" exception occurred while creating " +
                $"\"{LogFormatter.FormatTypeName(sourceItemBindingType)}\" instance.");
        }
    }
}
