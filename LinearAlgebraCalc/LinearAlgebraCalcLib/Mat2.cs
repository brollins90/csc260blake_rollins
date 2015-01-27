//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinearAlgebraCalcLib
//{
//    public class Mat2
//    {
//        public readonly Fraction A11;
//        public readonly Fraction A12;
//        public readonly Fraction A21;
//        public readonly Fraction A22;

//        public Mat2() : this(new Fraction(0), new Fraction(0),new Fraction(0), new Fraction(0)) { }

//        public Mat2(int a11, int a12, int a21, int a22)
//        {
//            this.A11 = new Fraction(a11);
//            this.A12 = new Fraction(a12);
//            this.A21 = new Fraction(a21);
//            this.A22 = new Fraction(a22);
//        }

//        public Mat2(Fraction a11, Fraction a12, Fraction a21, Fraction a22)
//        {
//            this.A11 = a11;
//            this.A12 = a12;
//            this.A21 = a21;
//            this.A22 = a22;
//        }

//        public static Mat2 operator +(Mat2 lhs, Mat2 rhs)
//        {
//            return new Mat2(
//                lhs.A11 + rhs.A11, lhs.A12 + rhs.A12,
//                lhs.A21 + rhs.A21, lhs.A22 + rhs.A22);
//        }

//        public static Mat2 operator -(Mat2 lhs, Mat2 rhs)
//        {
//            return new Mat2(
//                lhs.A11 - rhs.A11, lhs.A12 - rhs.A12,
//                lhs.A21 - rhs.A21, lhs.A22 - rhs.A22);
//        }

//        public static Mat2 operator *(Mat2 lhs, Mat2 rhs)
//        {
//            return new Mat2(
//                ((lhs.A11 * rhs.A11) + (lhs.A12 * rhs.A21)),
//                ((lhs.A11 * rhs.A21) + (lhs.A12 * rhs.A22)),
//                ((lhs.A21 * rhs.A11) + (lhs.A22 * rhs.A21)),
//                ((lhs.A21 * rhs.A21) + (lhs.A22 * rhs.A22)));
//        }

//        public static Mat2 operator *(Fraction scalar, Mat2 rhs)
//        {
//            return new Mat2(
//                (scalar * rhs.A11),
//                (scalar * rhs.A12),
//                (scalar * rhs.A21),
//                (scalar * rhs.A22));
//        }

//        public static Mat2 operator *(Mat2 lhs, Fraction scalar)
//        {
//            return lhs * scalar;
//        }

//        public static Mat2 operator *(double scalar, Mat2 rhs)
//        {
//            return (Fraction.Parse(scalar) * rhs);
//        }

//        public static Mat2 operator *(Mat2 lhs, double scalar)
//        {
//            return (Fraction.Parse(scalar) * lhs);
//        }

//        //public override string ToString()
//        //{
//        //    return (String.Format("({0},{1})", this.X, this.Y));
//        //}

//        //public override bool Equals(System.Object obj)
//        //{
//        //    // If parameter is null return false.
//        //    if (obj == null)
//        //    {
//        //        return false;
//        //    }

//        //    // If parameter cannot be cast to v2 return false.
//        //    Vector2 other = obj as Vector2;
//        //    if ((System.Object)other == null)
//        //    {
//        //        return false;
//        //    }

//        //    // Return true if the fields match:
//        //    return (X == other.X) && (Y == other.Y);
//        //}

//        //public bool Equals(Vector2 other)
//        //{
//        //    // If parameter is null return false:
//        //    if ((object)other == null)
//        //    {
//        //        return false;
//        //    }

//        //    // Return true if the fields match:
//        //    return (X == other.X) && (Y == other.Y);
//        //}

//        //public override int GetHashCode()
//        //{
//        //    int hash = 17;
//        //    hash *= 23 + X.GetHashCode();
//        //    hash *= 23 + Y.GetHashCode();
//        //    return hash;
//        //}

//        //public static Vector2 Parse(string vectorString)
//        //{
//        //    Fraction x;
//        //    Fraction y;
//        //    try
//        //    {
//        //        vectorString = vectorString.Replace('(', ' ');
//        //        vectorString = vectorString.Replace(')', ' ');
//        //        string[] strings = vectorString.Split(',');
//        //        if (strings.Count() > 2)
//        //        {
//        //            throw new FormatException();
//        //        }
//        //        x = Fraction.Parse(strings[0]);
//        //        y = Fraction.Parse(strings[1]);
//        //    }
//        //    catch (Exception)
//        //    {
//        //        throw new FormatException();
//        //    }
//        //    return new Vector2(x, y);

//        //}

//        public Mat2 Inverse()
//        {
//            return new Mat2();
//        }

//        public Mat2 Transpose()
//        {
//            return new Mat2();
//        }
//    }
//}
