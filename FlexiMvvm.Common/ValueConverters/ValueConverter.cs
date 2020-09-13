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

namespace FlexiMvvm.ValueConverters
{
    /// <summary>
    /// Exposes methods that allow the value to be modified as it passes through the binding engine.
    /// </summary>
    /// <typeparam name="TSourceValue">The type of the source value.</typeparam>
    /// <typeparam name="TTargetValue">The type of the target value.</typeparam>
    public abstract class ValueConverter<TSourceValue, TTargetValue> : IValueConverter
    {
        /// <inheritdoc />
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

#nullable disable
            return Convert((TSourceValue)value, targetType, parameter, culture).Value;
#nullable enable
        }

        /// <summary>
        /// Modifies the source value before passing it to the target for display in the UI. Returns unset value conversion result by default.
        /// </summary>
        /// <param name="value">The source value being passed to the target.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">The parameter to be used in the converter logic. Can be <see langword="null"/>.</param>
        /// <param name="culture">The culture to be used in the converter.</param>
        /// <returns>The conversion result instance.</returns>
        protected virtual ConversionResult<TTargetValue> Convert(TSourceValue value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ConversionResult<TTargetValue>.UnsetValue();
        }

        /// <inheritdoc />
        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

#nullable disable
            return ConvertBack((TTargetValue)value, targetType, parameter, culture).Value;
#nullable enable
        }

        /// <summary>
        /// Modifies the target value before passing it to the source object. Returns unset value conversion result by default.
        /// </summary>
        /// <param name="value">The target value being passed to the source.</param>
        /// <param name="targetType">The type of the target property, as a type reference.</param>
        /// <param name="parameter">The parameter to be used in the converter logic. Can be <see langword="null"/>.</param>
        /// <param name="culture">The culture to be used in the converter.</param>
        /// <returns>The conversion result instance.</returns>
        protected virtual ConversionResult<TSourceValue> ConvertBack(TTargetValue value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ConversionResult<TSourceValue>.UnsetValue();
        }
    }
}
