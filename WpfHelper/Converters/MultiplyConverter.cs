using System;
using System.Globalization;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Return multiple of `values[0]` and `values[1]`.
    /// </summary>
    public class MultiplyConverter : MultiConverterExtension<MultiplyConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values[0] is double multiplicand && values[1] is double multiplier)
            {
                return multiplicand * multiplier;
            }

            return null;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
