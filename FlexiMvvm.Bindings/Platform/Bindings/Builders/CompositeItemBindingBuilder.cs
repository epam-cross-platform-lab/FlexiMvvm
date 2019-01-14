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
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Builders
{
    internal class CompositeItemBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>
        : ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue>
        where TSourceItem : class
        where TTargetItem : class
    {
        [NotNull]
        private readonly CompositeItemBindingBase<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue> _compositeItemBinding;

        internal CompositeItemBindingBuilder(
            [NotNull] SourceItemBinding<TSourceItem, TSourceItemValue> sourceItemBinding,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            [NotNull] BindingSet<TSourceItem> bindingSet)
        {
            _compositeItemBinding = new CompositeItemBinding<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                targetItemBinding,
                BindingMode.TwoWay,
                new CompositeItemBindingValueConverter<TSourceItem>(typeof(DefaultValueConverter)));

            bindingSet.Add(_compositeItemBinding);
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> TwoWay()
        {
            _compositeItemBinding.RequestedBindingMode = BindingMode.TwoWay;

            return this;
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneWay()
        {
            _compositeItemBinding.RequestedBindingMode = BindingMode.OneWay;

            return this;
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneWayToSource()
        {
            _compositeItemBinding.RequestedBindingMode = BindingMode.OneWayToSource;

            return this;
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneTime()
        {
            _compositeItemBinding.RequestedBindingMode = BindingMode.OneTime;

            return this;
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithConversion<TValueConverter>(
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

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithConversion<TValueConverter>(
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

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithFallbackValue(TTargetItemValue value)
        {
            _compositeItemBinding.FallbackValue = new CompositeItemBindingFallbackValue<TTargetItemValue>(value);

            return this;
        }
    }
}
