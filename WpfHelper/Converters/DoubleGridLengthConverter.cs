using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Convert double value to GridLength object.
    /// </summary>
    public class DoubleGridLengthConverter : ConverterExtension<DoubleGridLengthConverter>, IValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double pixel)
            {
                return new GridLength(pixel);
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GridLength gridLength && gridLength.GridUnitType == GridUnitType.Pixel)
            {
                return gridLength.Value;
            }

            throw new NotImplementedException("Value is not type of GridLength, or it does not represent pixel value.");
        }
    }
}
