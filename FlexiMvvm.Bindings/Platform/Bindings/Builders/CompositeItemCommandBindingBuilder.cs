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
using System.Globalization;
using System.Linq.Expressions;
using FlexiMvvm.Bindings.Custom.Core;
using FlexiMvvm.Bindings.Custom.Core.Composite;
using FlexiMvvm.Bindings.Custom.Core.Source;
using FlexiMvvm.Bindings.Custom.Core.Target;
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Builders
{
    internal class CompositeItemCommandBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        : ICompositeItemCommandBindingBuilder<TSourceItem>
        where TSourceItem : class
        where TTargetItem : class
    {
        [NotNull]
        private readonly CompositeItemCommandBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue> _compositeItemBinding;
        [NotNull]
        private readonly BindingSet<TSourceItem> _bindingSet;

        internal CompositeItemCommandBindingBuilder(
            [NotNull] SourceItemCommandBinding<TSourceItem, TSourceItemValue> sourceItemBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            [NotNull] BindingSet<TSourceItem> bindingSet)
        {
            _compositeItemBinding = new CompositeItemCommandBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                targetItemBinding,
                BindingMode.OneWayToSource,
                new CompositeItemBindingValueConverter<TSourceItem>(typeof(DefaultValueConverter)));

            _bindingSet = bindingSet;
            _bindingSet.Add(_compositeItemBinding);
        }

        internal CompositeItemCommandBindingBuilder(
            [NotNull] SourceItemCommandBinding<TSourceItem, TSourceItemValue> sourceItemBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            [NotNull] BindingSet<TSourceItem> bindingSet,
            [NotNull] ICompositeItemBinding<TSourceItem> oldCompositeItemBinding)
        {
            _compositeItemBinding = new CompositeItemCommandBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                targetItemBinding,
                oldCompositeItemBinding.RequestedBindingMode,
                oldCompositeItemBinding.ValueConverter);

            _bindingSet = bindingSet;
            _bindingSet.Remove(oldCompositeItemBinding);
            _bindingSet.Add(_compositeItemBinding);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithCommandParameter<TCommandParameterTargetItem, TCommandParameterTargetItemValue>(
            TCommandParameterTargetItem targetItem,
            Expression<Func<TCommandParameterTargetItem, TCommandParameterTargetItemValue>> targetItemValue,
            ItemReferenceType referenceType)
            where TCommandParameterTargetItem : class
        {
            if (targetItem == null)
                throw new ArgumentNullException(nameof(targetItem));
            if (targetItemValue == null)
                throw new ArgumentNullException(nameof(targetItemValue));

            var targetItemReference = new ItemReference<TCommandParameterTargetItem>(targetItem, referenceType);
            var targetItemValueAccessor = new ItemValueAccessor<TCommandParameterTargetItem, TCommandParameterTargetItemValue>(targetItemValue);
            var targetItemCommandParameterBinding = new TargetItemPropertyBinding<TCommandParameterTargetItem, TCommandParameterTargetItemValue>(
                targetItemReference,
                targetItemValueAccessor);

            var targetItemCommandBinding = new TargetItemCommandBinding<TTargetItem, TTargetItemValue, TCommandParameterTargetItem, TCommandParameterTargetItemValue>(
                _compositeItemBinding.TargetItemBinding,
                targetItemCommandParameterBinding);

            return new CompositeItemCommandBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TCommandParameterTargetItemValue>(
                _compositeItemBinding.SourceItemBinding,
                targetItemCommandBinding,
                _bindingSet,
                _compositeItemBinding);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithCommandParameter<TCommandParameterItemValue>(
            TCommandParameterItemValue commandParameterTargetItemValue)
        {
            var commandParameterTargetItem = new TargetItemCommandParameter<TCommandParameterItemValue>(
                commandParameterTargetItemValue);

            return WithCommandParameter(
                commandParameterTargetItem,
                v => v.Value,
                ItemReferenceType.Strong);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithConversion<TValueConverter>(
            object parameter = null,
            CultureInfo culture = null)
            where TValueConverter : IValueConverter, new()
        {
            _compositeItemBinding.ValueConverter = new CompositeItemBindingValueConverter<TSourceItem>(
                typeof(TValueConverter),
                parameter,
                culture);

            return this;
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithConversion<TValueConverter>(
            Expression<Func<TSourceItem, object>> parameter,
            CultureInfo culture = null)
            where TValueConverter : IValueConverter, new()
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            _compositeItemBinding.ValueConverter = new CompositeItemBindingValueConverter<TSourceItem>(
                typeof(TValueConverter),
                parameter,
                culture);

            return this;
        }
    }
}
