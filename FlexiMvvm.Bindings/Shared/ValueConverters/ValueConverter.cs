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
using JetBrains.Annotations;

namespace FlexiMvvm.ValueConverters
{
    public abstract class ValueConverter<TSourceValue, TTargetValue> : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert((TSourceValue)value, targetType, parameter, culture).Value;
        }

        [NotNull]
        protected virtual ConversionResult<TTargetValue> Convert([CanBeNull] TSourceValue value, [NotNull] Type targetType, [CanBeNull] object parameter, [NotNull] CultureInfo culture)
        {
            return ConversionResult<TTargetValue>.UnsetValue();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack((TTargetValue)value, targetType, parameter, culture).Value;
        }

        [NotNull]
        protected virtual ConversionResult<TSourceValue> ConvertBack([CanBeNull] TTargetValue value, [NotNull] Type targetType, [CanBeNull] object parameter, [NotNull] CultureInfo culture)
        {
            return ConversionResult<TSourceValue>.UnsetValue();
        }
    }
}
