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
using System.Globalization;
using System.Linq.Expressions;
using FlexiMvvm.Bindings.Custom.Core;
using FlexiMvvm.Bindings.Custom.Core.Composite;
using FlexiMvvm.Bindings.Custom.Core.Source;
using FlexiMvvm.Bindings.Custom.Core.Target;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.ValueConverters.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Builders
{
    internal class CompositeItemCommandBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue> : ICompositeItemCommandBindingBuilder<TSourceItem>
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
                new CompositeItemBindingValueConverter<DefaultValueConverter>());

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

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithCommandParameter<TCommandParameter>(TCommandParameter parameter)
        {
            var targetItemBinding = new TargetItemCustomValueBinding<TTargetItem, TTargetItemValue, TCommandParameter>(
                _compositeItemBinding.TargetItemBinding,
                parameter);

            return new CompositeItemCommandBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TCommandParameter>(
                _compositeItemBinding.SourceItemBinding,
                targetItemBinding,
                _bindingSet,
                _compositeItemBinding);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithConversion<TValueConverter>(
            object parameter = null,
            CultureInfo culture = null)
            where TValueConverter : IValueConverter, new()
        {
            _compositeItemBinding.ValueConverter = new CompositeItemBindingValueConverter<TValueConverter>(parameter, culture);

            return this;
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> WithConversion<TValueConverter>(
            Expression<Func<TSourceItem, object>> parameterExpression,
            CultureInfo culture = null)
            where TValueConverter : IValueConverter, new()
        {
            if (parameterExpression == null)
                throw new ArgumentNullException(nameof(parameterExpression));

            _compositeItemBinding.ValueConverter = new CompositeItemBindingValueConverter<TValueConverter, TSourceItem>(
                _compositeItemBinding.SourceItemBinding.ItemReference,
                parameterExpression,
                culture);

            return this;
        }
    }
}
