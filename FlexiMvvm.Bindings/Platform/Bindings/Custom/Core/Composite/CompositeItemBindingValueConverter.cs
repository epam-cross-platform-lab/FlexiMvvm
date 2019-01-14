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
using FlexiMvvm.ValueConverters;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Composite
{
    internal class CompositeItemBindingValueConverter<TSourceItem>
    {
        [NotNull]
        private readonly Type _converterType;
        [NotNull]
        private readonly CultureInfo _converterCulture;
        [CanBeNull]
        private DelegatingLogger _delegatingLogger;

        internal CompositeItemBindingValueConverter(
            [NotNull] Type converterType,
            [CanBeNull] object parameter = null,
            [CanBeNull] CultureInfo converterCulture = null)
        {
            _converterType = converterType;
            ParameterAccessor = new CompositeItemBindingValueConverterParameterAccessor<TSourceItem>(parameter);
            _converterCulture = converterCulture ?? CultureInfo.CurrentUICulture.NotNull();
        }

        internal CompositeItemBindingValueConverter(
            [NotNull] Type converterType,
            [NotNull] Expression<Func<TSourceItem, object>> parameter,
            [CanBeNull] CultureInfo converterCulture = null)
        {
            _converterType = converterType;
            ParameterAccessor = new CompositeItemBindingValueConverterParameterAccessor<TSourceItem>(parameter);
            _converterCulture = converterCulture ?? CultureInfo.CurrentUICulture.NotNull();
        }

        [NotNull]
        private DelegatingLogger DelegatingLogger => _delegatingLogger ?? (_delegatingLogger = new DelegatingLogger());

        [NotNull]
        internal CompositeItemBindingValueConverterParameterAccessor<TSourceItem> ParameterAccessor { get; }

        [CanBeNull]
        internal object Convert([CanBeNull] object value, [NotNull] Type targetType, [CanBeNull] object parameter)
        {
            var valueConverter = ValueConverterFactory.GetOrCreate(_converterType);

            try
            {
                return valueConverter.Convert(value, targetType, parameter, _converterCulture);
            }
            catch (Exception ex)
            {
                Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while converting \"{value ?? "null"}\" value from the source item to the target one " +
                    $"using \"{LogFormatter.FormatTypeName(_converterType)}\" value converter. This might reduce binding performance. " +
                    $"Please return \"{nameof(BindingValue)}.{nameof(BindingValue.UnsetValue)}\" value instead of rising an exception.");

                return BindingValue.UnsetValue;
            }
        }

        [CanBeNull]
        internal object ConvertBack([CanBeNull] object value, [NotNull] Type targetType, [CanBeNull] object parameter)
        {
            var valueConverter = ValueConverterFactory.GetOrCreate(_converterType);

            try
            {
                return valueConverter.ConvertBack(value, targetType, parameter, _converterCulture);
            }
            catch (Exception ex)
            {
                Log($"An \"{LogFormatter.FormatException(ex)}\" exception occurred while converting \"{value ?? "null"}\" value from the target item to the source one " +
                    $"using \"{LogFormatter.FormatTypeName(_converterType)}\" value converter. This might reduce binding performance. " +
                    $"Please return \"{nameof(BindingValue)}.{nameof(BindingValue.UnsetValue)}\" value instead of rising an exception.");

                return BindingValue.UnsetValue;
            }
        }

        [Conditional("DEBUG")]
        internal void SetLogger([NotNull] ILogger logger)
        {
            DelegatingLogger.Logger = logger;
        }

        [Conditional("DEBUG")]
        protected void Log([CanBeNull] string message)
        {
            DelegatingLogger.Log(message);
        }
    }
}
