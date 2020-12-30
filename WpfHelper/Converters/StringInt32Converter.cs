using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Convert string to int(Int32) value.
    /// </summary>
    public class StringInt32Converter : ConverterExtension<StringInt32Converter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int parsed = default;
            if (int.TryParse(value.ToString(), out parsed))
            {
                return parsed;
            }

            return null;
            //throw new FormatException($"{value} is not valid int.");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intConverted)
            {
                return value.ToString();
            }

            return null;
            //throw new ArgumentException($"Argument is not int value.");
        }
    }
}
