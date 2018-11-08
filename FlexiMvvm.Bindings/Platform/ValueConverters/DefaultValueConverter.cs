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

#if __IOS__
using Foundation;
#endif

namespace FlexiMvvm.ValueConverters
{
    internal class DefaultValueConverter : ValueConverter<object, object>
    {
        [Linking.Preserve(Conditional = true)]
        public DefaultValueConverter()
        {
        }

        protected override ConversionResult<object> Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.IsInstanceOfType(value))
            {
                return ConversionResult<object>.SetValue(value);
            }

            switch (value)
            {
#if __IOS__
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
                case DateTime dateTimeValue when targetType == typeof(NSDate):
                    return ConversionResult<object>.SetValue((NSDate)dateTimeValue);
                case DateTimeOffset dateTimeOffsetValue when targetType == typeof(NSDate):
                    return ConversionResult<object>.SetValue((NSDate)dateTimeOffsetValue.UtcDateTime);
                case Enum enumValue when targetType == typeof(nint):
                    return ConversionResult<object>.SetValue((nint)System.Convert.ToInt32(enumValue));
#endif
                case Enum enumValue when targetType == typeof(int):
                    return ConversionResult<object>.SetValue(System.Convert.ToInt32(enumValue));
                case NamedValue namedValue when targetType == typeof(string):
                    return ConversionResult<object>.SetValue(namedValue.ToString());
            }

            return ConversionResult<object>.SetValue(System.Convert.ChangeType(value, targetType));
        }

        protected override ConversionResult<object> ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.IsInstanceOfType(value))
            {
                return ConversionResult<object>.SetValue(value);
            }

            switch (value)
            {
#if __IOS__
                case NSDate dateTimeValue when targetType == typeof(DateTime):
                    return ConversionResult<object>.SetValue((DateTime)dateTimeValue);
                case NSDate dateTimeValue when targetType == typeof(DateTime?):
                    return ConversionResult<object>.SetValue((DateTime?)dateTimeValue);
                case NSDate dateTimeValue when targetType == typeof(DateTimeOffset):
                    return ConversionResult<object>.SetValue((DateTimeOffset)(DateTime)dateTimeValue);
                case NSDate dateTimeValue when targetType == typeof(DateTimeOffset?):
                    return ConversionResult<object>.SetValue((DateTimeOffset?)(DateTime?)dateTimeValue);
                case nint enumValue when targetType.IsEnum:
                    return ConversionResult<object>.SetValue(Enum.ToObject(targetType, enumValue));
#endif
                case int enumValue when targetType.IsEnum:
                    return ConversionResult<object>.SetValue(Enum.ToObject(targetType, enumValue));
            }

            return ConversionResult<object>.SetValue(System.Convert.ChangeType(value, targetType));
        }
    }
}
