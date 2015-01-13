using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraCalcLib
{
    public class Fraction
    {
        public int Top { get; protected set; }
        public int Bottom { get; protected set; }

        public Fraction() : this(1, 1) { }

        public Fraction(int top) : this(top, 1) { }

        public Fraction(int top, int bottom)
        {
            this.Top = top;
            this.Bottom = bottom;
            SimplifyFraction();
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int top = (f1.Top * f2.Bottom) + (f1.Bottom * f2.Top);
            int bottom = f1.Bottom * f2.Bottom;
            return new Fraction(top, bottom);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int top = (f1.Top * f2.Bottom) - (f1.Bottom * f2.Top);
            int bottom = f1.Bottom * f2.Bottom;
            return new Fraction(top, bottom);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int top = f1.Top * f2.Top;
            int bottom = f1.Bottom * f2.Bottom;
            return new Fraction(top, bottom);
        }

        public static Fraction operator *(Fraction f1, Double d1)
        {
            Fraction f2 = Fraction.Parse(d1);
            int top = f1.Top * f2.Top;
            int bottom = f1.Bottom * f2.Bottom;
            return new Fraction(top, bottom);
        }

        public static Fraction operator *(Double d1, Fraction f1)
        {
            return d1 * f1;
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            int top = f1.Top * f2.Bottom;
            int bottom = f1.Bottom * f2.Top;
            return new Fraction(top, bottom);
        }

        public static Fraction operator /(Fraction f1, Double d1)
        {
            Fraction f2 = Fraction.Parse(d1);
            int top = f1.Top * f2.Bottom;
            int bottom = f1.Bottom * f2.Top;
            return new Fraction(top, bottom);
        }

        public static Fraction Parse(double d)
        {
            return ApproximateFraction(d);
        }

        public double ToDouble(int decimalPlaces)
        {
            if (this.Bottom == 0)
                return double.NaN;

            return System.Math.Round(
                Top / (double)Bottom,
                decimalPlaces
            );
        }

        // http://stackoverflow.com/questions/95727/how-to-convert-floats-to-human-readable-fractions
        private static Fraction ApproximateFraction(double value)
        {
            const double EPSILON = .000001d;

            int n = 1;  // numerator
            int d = 1;  // denominator
            double fraction = n / d;

            while (System.Math.Abs(fraction - value) > EPSILON)
            {
                if (fraction < value)
                {
                    n++;
                }
                else
                {
                    d++;
                    n = (int)System.Math.Round(value * d);
                }

                fraction = n / (double)d;
            }

            return new Fraction(n, d);
        }

        // http://stackoverflow.com/questions/2941048/how-to-simplify-fractions-in-c
        void SimplifyFraction()
        {
            bool negative = (this.Top < 0 ^ this.Bottom < 0);
            Top = Math.Abs(Top);
            Bottom = Math.Abs(Bottom);

            int gcd = GCD();
            Top /= gcd;
            Bottom /= gcd;

            if (negative)
            {
                Top = Top * -1;
            }
        }

        private int GCD()
        {
            int a = Top;
            int b = Bottom;

            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }

        public override string ToString()
        {
            string retVal = null;
            if (this.Bottom != 1)
            {
                retVal = (String.Format("({0}/{1})", this.Top, this.Bottom));
            }
            else
            {
                retVal = (String.Format("({0})", this.Top));
            }
            return retVal;
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Fraction other = obj as Fraction;
            if ((System.Object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Top == other.Top) && (Bottom == other.Bottom);
        }

        public bool Equals(Fraction other)
        {
            // If parameter is null return false:
            if ((object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Top == other.Top) && (Bottom == other.Bottom);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + Top.GetHashCode();
            hash *= 23 + Bottom.GetHashCode();
            return hash;
        }
    }
}
