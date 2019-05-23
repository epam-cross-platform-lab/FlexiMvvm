using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace Sample.Core.Presentation.ValueConverters
{
    public sealed class StringToDateTimeValueConverter : ValueConverter<string, DateTime>
    {
        private const string DateFormat = "d";

        protected override ConversionResult<DateTime> Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value, out var dt))
            {
                return ConversionResult<DateTime>.SetValue(new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, DateTimeKind.Utc));
            }

            return ConversionResult<DateTime>.SetValue(DateTime.UtcNow);
        }

        protected override ConversionResult<string> ConvertBack(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToString(DateFormat));
        }
    }
}
