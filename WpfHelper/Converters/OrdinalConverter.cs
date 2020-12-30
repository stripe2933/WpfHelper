using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WpfHelper.Converters
{
    // http://csharphelper.com/blog/2014/11/convert-an-integer-into-an-ordinal-in-c/
    /// <summary>
    /// Return int value's ordinal extension.
    /// ex. 1 -> "st", 2 -> "nd", 11 -> "th", 47 -> "th"
    /// </summary>
    public class OrdinalConverter : ConverterExtension<OrdinalConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intConverted)
            {
                // Start with the most common extension.
                string extension = "th";

                // Examine the last 2 digits.
                int last_digits = intConverted % 100;

                // If the last digits are 11, 12, or 13, use th. Otherwise:
                if (last_digits < 11 || last_digits > 13)
                {
                    // Check the last digit.
                    switch (last_digits % 10)
                    {
                        case 1:
                            extension = "st";
                            break;
                        case 2:
                            extension = "nd";
                            break;
                        case 3:
                            extension = "rd";
                            break;
                    }
                }

                return extension;
            }

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
