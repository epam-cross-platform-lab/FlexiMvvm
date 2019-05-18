using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using FlexiMvvm.ValueConverters;

namespace FlexiMvvm.Bindings.Converters
{
    public sealed class StringToDateTimeValueConverter : ValueConverter<string, DateTime>
    {
        private const string DateFormat = "d";

        protected override ConversionResult<DateTime> Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value, out var dt))
            {
                return ConversionResult<DateTime>.SetValue(dt);
            }

            return ConversionResult<DateTime>.SetValue(DateTime.MinValue);
        }

        protected override ConversionResult<string> ConvertBack(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToString(DateFormat));
        }
    }
}
