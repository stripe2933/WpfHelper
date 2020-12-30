using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Inherit this class to make converter as MarkupExtension.
    /// </summary>
    /// <typeparam name="T">Generic type of IValueConverter</typeparam>
    public abstract class ConverterExtension<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static Lazy<T> _converter = new Lazy<T>(() => new T());

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter.Value;
        }
    }
}
