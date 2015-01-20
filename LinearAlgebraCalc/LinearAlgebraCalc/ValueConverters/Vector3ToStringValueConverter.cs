using LinearAlgebraCalcLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinearAlgebraCalc.ValueConverters
{

    public class Vector3ToStringValueConverter : IValueConverter
    {
        // vector to string
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value == null)
            //    value = new Vector3();
            if (value is Vector3)
                return ((Vector3)value).ToString();
            else if (value is Vector2)
                return ((Vector2)value).ToString();

            value = new Vector3();
            return value.ToString();
                
        }

        // String to vector
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string vectorString = (string)value;
            try
            {
                Vector3 vec = Vector3.Parse(vectorString);
                return vec;
            }
            catch (Exception)
            {
                return new Vector3();
                return Binding.DoNothing;
                throw new FormatException();
            }
        }
    }
}
