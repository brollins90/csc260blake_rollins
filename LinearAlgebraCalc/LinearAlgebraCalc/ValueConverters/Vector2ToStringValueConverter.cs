using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinearAlgebraCalc.ValueConverters
{

    public class Vector2ToStringValueConverter : IValueConverter
    {
        // vector to string
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                value = new Vector2();
            }
            return value.ToString();
        }

        // String to vector
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string vectorString = (string)value;
            try
            {
                Vector2 vec = Vector2.Parse(vectorString);
                return vec;
            }
            catch (Exception)
            {
                return new Vector2();
            }
        }
    }
}
