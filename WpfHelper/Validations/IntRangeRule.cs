using System.Globalization;
using System.Windows.Controls;

namespace WpfHelper.Validations
{
    public class IntRangeRule : ValidationRule
    {
        public IntRangeRuleWrapper Wrapper { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int parsed;
            if (value is string strValue && int.TryParse(strValue, out parsed))
            {
                if (parsed >= Wrapper.Minimum && parsed <= Wrapper.Maximum)
                {
                    return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, $"{parsed} is not in range [{Wrapper.Minimum}, {Wrapper.Maximum}].");
            }
            return new ValidationResult(false, $"{value} is not int-type value.");
        }
    }
}
