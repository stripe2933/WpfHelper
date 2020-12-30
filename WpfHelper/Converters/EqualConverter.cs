using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WpfHelper.Converters
{
    /// <summary>
    /// Return each value's equality.
    /// </summary>
    public class EqualConverter : MultiConverterExtension<EqualConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length >= 2)
            {
                bool flag = true;
                var first = values.FirstOrDefault();
                foreach (var element in values.Skip(1))
                {
                    flag = first.Equals(element);
                    if (flag == false)
                    {
                        break;
                    }
                }

                return flag;
            }

            return null;
            //throw new ArgumentException("Argument is null or its length is less than two.");
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
