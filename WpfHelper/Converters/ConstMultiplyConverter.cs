using System;
using System.Globalization;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Return multiple of `value` and `parameter` where const (not bindable) `parameter`.
    /// </summary>
    public class ConstMultiplyConverter : ConverterExtension<MultiplyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double multiplicand && parameter is double multiplier)
            {
                return multiplicand * multiplier;
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double multiplyResult && parameter is double multiplier && multiplier.Equals(0.0) == false)
            {
                return multiplyResult / multiplier;
            }

            return null;
        }
    }
}
