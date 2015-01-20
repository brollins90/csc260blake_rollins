using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraCalcLib
{
    public class Vector2
    {
        public readonly Fraction X;
        public readonly Fraction Y;

        public Vector2() : this(new Fraction(0), new Fraction(0)) { }

        public Vector2(int x, int y)
        {
            this.X = new Fraction(x);
            this.Y = new Fraction(y);
        }

        public Vector2(Fraction x, Fraction y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2 operator *(Vector2 v1, Fraction scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }

        public static Vector2 operator *(Fraction scalar, Vector2 v1)
        {
            return v1 * scalar;
        }

        public static Vector2 operator *(Vector2 v1, double scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }

        public static Vector2 operator *(double scalar, Vector2 v1)
        {
            return v1 * scalar;
        }

        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            if (v1.X.Top != 0 && v2.Y.Top != 0)
            {
                return new Vector2(v1.X / v2.X, v1.Y / v2.Y);
            }
            else
            {
                return new Vector2();
            }
        }

        public static Vector2 operator /(Vector2 v1, Fraction divisor)
        {
            if (divisor.Top != 0)
            {
                return new Vector2(v1.X / divisor, v1.Y / divisor);
            }
            else
            {
                return new Vector2();
            }
        }

        public static Vector2 operator /(Vector2 v1, double divisor)
        {
            if (divisor != 0)
            {
                return new Vector2(v1.X / divisor, v1.Y / divisor);
            }
            else
            {
                return new Vector2();
            }
        }

        public virtual Fraction Dot(Vector2 other) 
        {
            return ((this.X * other.X) + (this.Y * other.Y)); 
        }

        public virtual Fraction Length() 
        {
            return Fraction.Parse(Math.Sqrt(LengthSquared().ToDouble(8)));
        }

        public virtual Fraction LengthSquared()
        {
            return (X * X + Y * Y);
        }

        public Vector2 Normalize()
        {
            Vector2 vect = null;
            Fraction length = this.Length();

            if (length.Top != 0)
            {
                vect = new Vector2(
                    (X / length),
                    (Y / length)
                );
            }
            return vect;
        }

        public override string ToString()
        {
            return (String.Format("({0},{1})", this.X, this.Y));
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to v2 return false.
            Vector2 other = obj as Vector2;
            if ((System.Object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (X == other.X) && (Y == other.Y);
        }

        public bool Equals(Vector2 other)
        {
            // If parameter is null return false:
            if ((object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (X == other.X) && (Y == other.Y);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + X.GetHashCode();
            hash *= 23 + Y.GetHashCode();
            return hash;
        }

        public static Vector2 Parse(string vectorString)
        {
            Fraction x;
            Fraction y;
            try
            {
                vectorString = vectorString.Replace('(', ' ');
                vectorString = vectorString.Replace(')', ' ');
                string[] strings = vectorString.Split(',');
                if (strings.Count() > 2)
                {
                    throw new FormatException();
                }
                x = Fraction.Parse(strings[0]);
                y = Fraction.Parse(strings[1]);
            }
            catch (Exception)
            {
                throw new FormatException();
            }
            return new Vector2(x, y);

        }
    }
}
