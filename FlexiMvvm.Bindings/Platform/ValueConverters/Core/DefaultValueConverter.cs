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

namespace FlexiMvvm.ValueConverters.Core
{
    internal class DefaultValueConverter : ValueConverter<object, object>
    {
        protected override ConversionResult<object> Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.IsInstanceOfType(value))
            {
                return ConversionResult<object>.SetValue(value);
            }
#if __IOS__
            switch (value)
            {
                // https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/nativetypes
                case int intValue when targetType == typeof(nint):
                    return ConversionResult<object>.SetValue((nint)intValue);
                case long longValue when targetType == typeof(nint):
                    return ConversionResult<object>.SetValue((nint)longValue);
                case uint uintValue when targetType == typeof(nuint):
                    return ConversionResult<object>.SetValue((nuint)uintValue);
                case ulong ulongValue when targetType == typeof(nuint):
                    return ConversionResult<object>.SetValue((nuint)ulongValue);
                case float floatValue when targetType == typeof(nfloat):
                    return ConversionResult<object>.SetValue((nfloat)floatValue);
                case double doubleValue when targetType == typeof(nfloat):
                    return ConversionResult<object>.SetValue((nfloat)doubleValue);
                case DateTime dateTimeValue when targetType == typeof(Foundation.NSDate):
                    return ConversionResult<object>.SetValue((Foundation.NSDate)dateTimeValue);
                case DateTimeOffset dateTimeOffsetValue when targetType == typeof(Foundation.NSDate):
                    return ConversionResult<object>.SetValue((Foundation.NSDate)dateTimeOffsetValue.UtcDateTime);
        }
#endif
            return ConversionResult<object>.SetValue(System.Convert.ChangeType(value, targetType));
        }

        protected override ConversionResult<object> ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.IsInstanceOfType(value))
            {
                return ConversionResult<object>.SetValue(value);
            }
#if __IOS__
            switch (value)
            {
                case Foundation.NSDate dateTimeValue when targetType == typeof(DateTime):
                    return ConversionResult<object>.SetValue((DateTime)dateTimeValue);
                case Foundation.NSDate dateTimeValue when targetType == typeof(DateTime?):
                    return ConversionResult<object>.SetValue((DateTime?)dateTimeValue);
                case Foundation.NSDate dateTimeValue when targetType == typeof(DateTimeOffset):
                    return ConversionResult<object>.SetValue((DateTimeOffset)(DateTime)dateTimeValue);
                case Foundation.NSDate dateTimeValue when targetType == typeof(DateTimeOffset?):
                    return ConversionResult<object>.SetValue((DateTimeOffset?)(DateTime?)dateTimeValue);
        }
#endif
            return ConversionResult<object>.SetValue(System.Convert.ChangeType(value, targetType));
        }
    }
}
