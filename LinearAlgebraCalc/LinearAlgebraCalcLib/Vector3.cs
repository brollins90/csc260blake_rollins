using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraCalcLib
{
    public class Vector3 : Vector2
    {
        public readonly Fraction Z;

        public Vector3() : this(new Fraction(0), new Fraction(0), new Fraction(0)) { }

        public Vector3(int x, int y, int z)
            : base(x, y)
        {
            this.Z = new Fraction(z);
        }

        public Vector3(Fraction x, Fraction y, Fraction z)
            : base(x, y)
        {
            this.Z = z;
        }


        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3 operator *(Vector3 v1, Fraction scalar)
        {
            return new Vector3(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);
        }

        public static Vector3 operator *(Fraction scalar, Vector3 v1)
        {
            return v1 * scalar;
        }

        public static Vector3 operator *(Vector3 v1, double scalar)
        {
            return new Vector3(v1.X * scalar, v1.Y * scalar, v1.Z * scalar);
        }

        public static Vector3 operator *(double scalar, Vector3 v1)
        {
            return v1 * scalar;
        }

        public static Vector3 operator /(Vector3 v1, Vector3 v2)
        {
            if (
                v2.X.Equals(new Fraction(0)) ||
                v2.Y.Equals(new Fraction(0)) ||
                v2.Z.Equals(new Fraction(0)))
            {
                throw new DivideByZeroException();
            }
            return new Vector3(v1.X / v2.X, v1.Y / v2.Y, v1.Z / v2.Z);
        }

        public static Vector3 operator /(Vector3 v1, double d1)
        {
            if (d1 == 0)
            {
                throw new DivideByZeroException();
            }
            return new Vector3(v1.X / d1, v1.Y / d1, v1.Z / d1);
        }

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                (this.Y * other.Z) - (this.Z * other.Y),
                (this.Z * other.X) - (this.X * other.Z),
                (this.X * other.Y) - (this.Y * other.X));
        }

        public Fraction Dot(Vector3 other)
        {
            return ((this.X * other.X) + (this.Y * other.Y) + (this.Z * other.Z));
        }

        public override Fraction Length()
        {
            return Fraction.Parse(Math.Sqrt(LengthSquared().ToDouble(8)));
        }

        public override Fraction LengthSquared()
        {
            return (X * X + Y * Y + Z * Z);
        }

        public Vector3 Normalize()
        {
            Vector3 vect = new Vector3();
            Fraction length = this.Length();

            if (length.Top != 0)
            {
                vect = new Vector3(
                    (X / length),
                    (Y / length),
                    (Z / length)
                );
            }
            return vect;
        }

        public override string ToString()
        {
            return (String.Format("({0},{1},{2})", this.X, this.Y, this.Z));
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to v2 return false.
            Vector3 other = obj as Vector3;
            if ((System.Object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return base.Equals(obj) && (Z == other.Z);
        }

        public bool Equals(Vector3 other)
        {
            // If parameter is null return false:
            if ((object)other == null)
            {
                return false;
            }

            // Return true if the fields match:
            return base.Equals(other) && (Z == other.Z);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash *= 23 + X.GetHashCode();
            hash *= 23 + Y.GetHashCode();
            hash *= 23 + Z.GetHashCode();
            return hash;
        }

        public static Vector3 Parse(string vectorString)
        {
            Fraction x;
            Fraction y;
            Fraction z;
            try
            {
                vectorString = vectorString.Replace('(', ' ');
                vectorString = vectorString.Replace(')', ' ');
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
