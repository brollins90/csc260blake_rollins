using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinearAlgebraCalc.ValueConverters
{

    public class FractionToStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Fraction r = (Fraction)value;
            return r.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string fractionString = (string)value;
            Fraction x;
            try
            {
                fractionString = fractionString.Replace('(', ' ');
                fractionString = fractionString.Replace(')', ' ');
                x = Fraction.Parse(fractionString);
            }
            catch (Exception)
            {
                throw new FormatException();
            }
            return x;
        }
    }
}
