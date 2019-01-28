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
using FlexiMvvm.Bindings.Custom.Core.Source;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Composite
{
    internal class CompositeItemBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        : CompositeItemBindingBase<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        where TSourceItem : class
        where TTargetItem : class
    {
        internal CompositeItemBinding(
            [NotNull] SourceItemBinding<TSourceItem, TSourceItemValue> sourceItemBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            BindingMode requestedBindingMode,
            [NotNull] ICompositeItemBindingValueConverter valueConverter)
            : base(sourceItemBinding, targetItemBinding, requestedBindingMode, valueConverter)
        {
        }

        protected override void SetInitialValues(TTargetItem targetItem)
        {
            if (IsFromSourceToTargetBindingMode())
            {
                if (SourceItemBinding.TryGetItem(out var sourceItem))
                {
                    if (TryGetSourceItemValue(sourceItem, out var sourceItemValue))
                    {
                        SetTargetItemValue(targetItem, sourceItem, sourceItemValue);
                    }
                }
                else
                {
                    SetTargetItemValue(targetItem, BindingValue.UnsetValue);
                }
            }
            else if (IsFromTargetToSourceBindingMode())
            {
                if (SourceItemBinding.TryGetItem(out var sourceItem))
                {
                    if (TryGetTargetItemValue(targetItem, out var targetItemValue))
                    {
                        SetSourceItemValue(sourceItem, targetItemValue);
                    }
                }
            }
        }

        protected override void SubscribeToSourceItemEvents()
        {
            if (SourceItemBinding.TryGetItem(out var sourceItem))
            {
                if (IsFromSourceToTargetBindingMode(includingOneTimeBindingMode: false))
                {
                    try
                    {
                        SourceItemBinding.SubscribeToEvents(sourceItem);
                    }
                    catch (Exception ex)
                    {
                        Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                            $"\"{LogFormatter.FormatTypeName(SourceItemBinding)}.{nameof(SourceItemBinding.SubscribeToEvents)}\" method.");
                    }
                }
            }
        }

        protected override void UnsubscribeFromSourceItemEvents()
        {
            if (SourceItemBinding.TryGetItem(out var sourceItem))
            {
                if (IsFromSourceToTargetBindingMode(includingOneTimeBindingMode: false))
                {
                    try
                    {
                        SourceItemBinding.UnsubscribeFromEvents(sourceItem);
                    }
                    catch (Exception ex)
                    {
                        Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while executing " +
                            $"\"{LogFormatter.FormatTypeName(SourceItemBinding)}.{nameof(SourceItemBinding.UnsubscribeFromEvents)}\" method.");
                    }
                }
            }
        }
    }
}
