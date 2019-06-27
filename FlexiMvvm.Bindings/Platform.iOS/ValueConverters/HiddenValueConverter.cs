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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FlexiMvvm.ValueConverters
{
    public class HiddenValueConverter : ValueConverter<object, bool>
    {
        protected override ConversionResult<bool> Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case bool boolValue:
                    return ConversionResult<bool>.SetValue(boolValue);
                case int intValue:
                    return ConversionResult<bool>.SetValue(intValue > 0);
                case float floatValue:
                    return ConversionResult<bool>.SetValue(floatValue > 0);
                case double doubleValue:
                    return ConversionResult<bool>.SetValue(doubleValue > 0);
                case string stringValue:
                    return ConversionResult<bool>.SetValue(!string.IsNullOrEmpty(stringValue));
                case IEnumerable<object> enumerableValue:
                    return ConversionResult<bool>.SetValue(enumerableValue?.Any() ?? false);
                default:
                    return ConversionResult<bool>.SetValue(value != null);
            }
        }

        protected override ConversionResult<object> ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (targetType)
            {
                case Type boolType when boolType == typeof(bool):
                    return ConversionResult<object>.SetValue(value);
                case Type intType when intType == typeof(int):
                    return ConversionResult<object>.SetValue(value ? 1 : 0);
                case Type floatType when floatType == typeof(float):
                    return ConversionResult<object>.SetValue(value ? 1 : 0);
                case Type doubleType when doubleType == typeof(double):
                    return ConversionResult<object>.SetValue(value ? 1 : 0);
                default:
                    return ConversionResult<object>.UnsetValue();
            }
        }
    }
}
