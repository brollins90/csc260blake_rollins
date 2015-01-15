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
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Vector3 r = (Vector3)value;
            return r.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string vectorString = (string)value;
            Fraction x;
            Fraction y;
            Fraction z;
            try
            {
                vectorString = vectorString.Replace('(',' ');
                vectorString = vectorString.Replace(')',' ');
                string[] strings = vectorString.Split(',');
                if (strings.Count() > 3)
                {
                    throw new FormatException();
                }
                x = Fraction.Parse(strings[0]);
                y = Fraction.Parse(strings[1]);
                z = Fraction.Parse(strings[2]);
            }
            catch (Exception)
            {
                throw new FormatException();
            }
            return new Vector3(x, y, z);
        }
    }
}
