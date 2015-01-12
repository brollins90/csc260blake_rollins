//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinearAlgebraCalcLib
//{
//    public class Mat3
//    {
//        public Fraction a11;
//        public Fraction a12;
//        public Fraction a13;
//        public Fraction a21;
//        public Fraction a22;
//        public Fraction a23;
//        public Fraction a31;
//        public Fraction a32;
//        public Fraction a33;

//        public Mat3(
//            Fraction a11, Fraction a12, Fraction a13,
//            Fraction a21, Fraction a22, Fraction a23,
//            Fraction a31, Fraction a32, Fraction a33)
//        {
//            this.a11 = a11;
//            this.a12 = a12;
//            this.a13 = a13;
//            this.a21 = a21;
//            this.a22 = a22;
//            this.a23 = a23;
//            this.a31 = a31;
//            this.a32 = a32;
//            this.a33 = a33;
//        }

//        public Mat3(
//            double a11 = 0, double a12 = 0, double a13 = 0,
//            double a21 = 0, double a22 = 0, double a23 = 0,
//            double a31 = 0, double a32 = 0, double a33 = 0)
//        {
//            this.a11 = new Fraction(a11);
//            this.a12 = new Fraction(a12);
//            this.a13 = new Fraction(a13);
//            this.a21 = new Fraction(a21);
//            this.a22 = new Fraction(a22);
//            this.a23 = new Fraction(a23);
//            this.a31 = new Fraction(a31);
//            this.a32 = new Fraction(a32);
//            this.a33 = new Fraction(a33);
//        }

//        public Mat3(
//            int a11 = 0, int a12 = 0, int a13 = 0,
//            int a21 = 0, int a22 = 0, int a23 = 0,
//            int a31 = 0, int a32 = 0, int a33 = 0)
//        {
//            this.a11 = new Fraction(a11);
//            this.a12 = new Fraction(a12);
//            this.a13 = new Fraction(a13);
//            this.a21 = new Fraction(a21);
//            this.a22 = new Fraction(a22);
//            this.a23 = new Fraction(a23);
//            this.a31 = new Fraction(a31);
//            this.a32 = new Fraction(a32);
//            this.a33 = new Fraction(a33);
//        }

//        public static Mat3 operator +(Mat3 m1, Mat3 m2)
//        {
//            return new Mat3(
//                m1.a11 + m2.a11, m1.a12 + m2.a12, m1.a13 + m2.a13,
//                m1.a21 + m2.a21, m1.a22 + m2.a22, m1.a23 + m2.a23,
//                m1.a31 + m2.a31, m1.a32 + m2.a32, m1.a33 + m2.a33);
//        }

//        public static Mat3 operator -(Mat3 m1, Mat3 m2)
//        {
//            return new Mat3(
//                m1.a11 - m2.a11, m1.a12 - m2.a12, m1.a13 - m2.a13,
//                m1.a21 - m2.a21, m1.a22 - m2.a22, m1.a23 - m2.a23,
//                m1.a31 - m2.a31, m1.a32 - m2.a32, m1.a33 - m2.a33);
//        }

//        public static Mat3 operator *(Mat3 m1, Mat3 m2)
//        {
//            return new Mat3(
//                ((m1.a11 * m2.a11) + (m1.a12 * m2.a21) + (m1.a13 * m2.a31)),
//                ((m1.a11 * m2.a12) + (m1.a12 * m2.a22) + (m1.a13 * m2.a32)),
//                ((m1.a11 * m2.a13) + (m1.a12 * m2.a23) + (m1.a13 * m2.a33)),
//                ((m1.a21 * m2.a11) + (m1.a22 * m2.a21) + (m1.a23 * m2.a31)),
//                ((m1.a21 * m2.a12) + (m1.a22 * m2.a22) + (m1.a23 * m2.a32)),
//                ((m1.a21 * m2.a13) + (m1.a22 * m2.a23) + (m1.a23 * m2.a33)),
//                ((m1.a31 * m2.a11) + (m1.a32 * m2.a21) + (m1.a33 * m2.a31)),
//                ((m1.a31 * m2.a12) + (m1.a32 * m2.a22) + (m1.a33 * m2.a32)),
//                ((m1.a31 * m2.a13) + (m1.a32 * m2.a23) + (m1.a33 * m2.a33)));
//        }

//        public override string ToString()
//        {
//            return (String.Format("({0},{1},{2}\n {3},{4},{5}\n {6},{7},{8})", this.a11, this.a12, this.a13, this.a21, this.a22, this.a23, this.a31, this.a32, this.a33));
//        }
//    }
//}
