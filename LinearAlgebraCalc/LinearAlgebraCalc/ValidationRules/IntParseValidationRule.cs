using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LinearAlgebraCalc.ValidationRules
{
    class IntParseValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string testString = (string)value;
                int f = int.Parse(testString);
                
                return new ValidationResult(true, null);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "The string is not parsable.");
            }
        }
    }
}
