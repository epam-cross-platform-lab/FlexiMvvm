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
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.Formatters;
using FlexiMvvm.ValueConverters;
using FlexiMvvm.ValueConverters.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Composite
{
    internal class CompositeItemBindingValueConverter<TValueConverter> : ICompositeItemBindingValueConverter
        where TValueConverter : IValueConverter, new()
    {
        [CanBeNull]
        private readonly object _parameter;
        [NotNull]
        private readonly CultureInfo _converterCulture;
        [CanBeNull]
        private DelegatingLogger _delegatingLogger;

        protected CompositeItemBindingValueConverter([CanBeNull] CultureInfo converterCulture = null)
        {
            _converterCulture = converterCulture ?? CultureInfo.CurrentUICulture.NotNull();
        }

        internal CompositeItemBindingValueConverter([CanBeNull] object parameter = null, [CanBeNull] CultureInfo converterCulture = null)
            : this(converterCulture)
        {
            _parameter = parameter;
        }

        [NotNull]
        private DelegatingLogger DelegatingLogger => _delegatingLogger ?? (_delegatingLogger = new DelegatingLogger());

        [ContractAnnotation("=> true, parameter: notnull; => false, parameter: null")]
        private protected virtual bool TryGetParameter(out object parameter)
        {
            parameter = _parameter;

            return true;
        }

        public object Convert(object value, Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            var valueConverter = ValueConverterProvider.Get<TValueConverter>();
            var convertedValue = BindingValue.UnsetValue;

            if (TryGetParameter(out var parameter))
            {
                try
                {
                    convertedValue = valueConverter.Convert(value, targetType, parameter, _converterCulture);
                }
                catch (Exception ex)
                {
                    Log($"An '{LogFormatter.FormatException(ex)}' exception occurred while converting '{value ?? "null"}' value from the source item to the target one " +
                        $"using '{TypeFormatter.FormatName<TValueConverter>()}' value converter.");
                }
            }

            return convertedValue;
        }

        public object ConvertBack(object value, Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            var valueConverter = ValueConverterProvider.Get<TValueConverter>();
            var convertedValue = BindingValue.UnsetValue;

            if (TryGetParameter(out var parameter))
            {
                try
                {
                    convertedValue = valueConverter.ConvertBack(value, targetType, parameter, _converterCulture);
                }
                catch (Exception ex)
                {
                    Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while converting \"{value ?? "null"}\" value from the target item to the source one " +
                        $"using \"{TypeFormatter.FormatName<TValueConverter>()}\" value converter.");
                }
            }

            return convertedValue;
        }

        public void SetLogger(ILogger logger)
        {
            DelegatingLogger.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Conditional("DEBUG")]
        protected void Log([CanBeNull] string message)
        {
            DelegatingLogger.Log(message);
        }
    }

    internal class CompositeItemBindingValueConverter<TValueConverter, TItem> : CompositeItemBindingValueConverter<TValueConverter>
        where TValueConverter : IValueConverter, new()
        where TItem : class
    {
        [NotNull]
        private readonly IItemReference<TItem> _itemReference;
        [NotNull]
        private readonly ItemValueAccessor<TItem, object> _parameterAccessor;

        internal CompositeItemBindingValueConverter(
            [NotNull] IItemReference<TItem> itemReference,
            [NotNull] Expression<Func<TItem, object>> parameterExpression,
            [CanBeNull] CultureInfo converterCulture = null)
            : base(converterCulture)
        {
            _itemReference = itemReference ?? throw new ArgumentNullException(nameof(itemReference));
            _parameterAccessor = new ItemValueAccessor<TItem, object>(parameterExpression);
        }

        private protected override bool TryGetParameter(out object parameter)
        {
            parameter = null;
            var succeed = false;

            if (_itemReference.TryGetItem(out var item))
            {
                succeed = _parameterAccessor.TryGetValue(item, out parameter);
            }

            return succeed;
        }
    }
}
