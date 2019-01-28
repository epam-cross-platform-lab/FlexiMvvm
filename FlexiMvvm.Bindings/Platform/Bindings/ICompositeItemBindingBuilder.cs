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
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public interface ICompositeItemBindingBuilder<TSourceItem, in TTargetItemValue>
    {
        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> TwoWay();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneWay();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneWayToSource();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> OneTime();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithConversion<TValueConverter>(
            [CanBeNull] object parameter = null,
            [CanBeNull] CultureInfo culture = null)
            where TValueConverter : IValueConverter, new();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithConversion<TValueConverter>(
            [NotNull] Expression<Func<TSourceItem, object>> parameterExpression,
            [CanBeNull] CultureInfo culture = null)
            where TValueConverter : IValueConverter, new();

        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> WithFallbackValue([CanBeNull] TTargetItemValue value);
    }
}
