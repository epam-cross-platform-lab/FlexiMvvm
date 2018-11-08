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
using FlexiMvvm.Bindings.Custom.Core.Source;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Composite
{
    internal class CompositeItemCommandBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        : CompositeItemBindingBase<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        where TSourceItem : class
        where TTargetItem : class
    {
        internal CompositeItemCommandBinding(
            [NotNull] SourceItemCommandBinding<TSourceItem, TSourceItemValue> sourceItemCommandBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            BindingMode requestedBindingMode,
            [NotNull] CompositeItemBindingValueConverter<TSourceItem> valueConverter)
            : base(sourceItemCommandBinding, targetItemBinding, requestedBindingMode, valueConverter)
        {
        }

        [NotNull]
        internal new SourceItemCommandBinding<TSourceItem, TSourceItemValue> SourceItemBinding =>
            (SourceItemCommandBinding<TSourceItem, TSourceItemValue>)base.SourceItemBinding;

        protected override void SetInitialValues(TTargetItem targetItem)
        {
        }

        protected override void SubscribeToSourceItemEvents()
        {
            if (SourceItemBinding.TryGetItem(out var sourceItem))
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

                SourceItemBinding.CanExecuteChanged += SourceItemCommandBinding_CanExecuteChanged;
            }
        }

        protected override void UnsubscribeFromSourceItemEvents()
        {
            if (SourceItemBinding.TryGetItem(out var sourceItem))
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

                SourceItemBinding.CanExecuteChanged -= SourceItemCommandBinding_CanExecuteChanged;
            }
        }

        private void SourceItemCommandBinding_CanExecuteChanged([NotNull] object sender, [NotNull] EventArgs e)
        {
            if (TargetItemBinding is ITargetItemCommandListener<TTargetItem> targetItemCommandListener &&
                TargetItemBinding.TryGetItem(out var targetItem) &&
                SourceItemBinding.TryGetItem(out var sourceItem))
            {
                if (TryGetTargetItemValue(targetItem, out var targetItemCommandParameter))
                {
                    var valueConverterParameter = ValueConverter.ParameterAccessor.Get(sourceItem);
                    var sourceItemCommandParameter = ValueConverter.ConvertBack(
                        targetItemCommandParameter,
                        typeof(TSourceItemValue),
                        valueConverterParameter);

                    if (sourceItemCommandParameter != BindingValue.UnsetValue)
                    {
                        var canExecute = SourceItemBinding.CanExecute(sourceItem, (TSourceItemValue)sourceItemCommandParameter);

                        targetItemCommandListener.HandleCanExecuteCommandChanged(targetItem, canExecute);
                    }
                }
            }
        }
    }
}
