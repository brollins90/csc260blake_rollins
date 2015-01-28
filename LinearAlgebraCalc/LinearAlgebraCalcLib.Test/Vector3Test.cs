using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearAlgebraCalcLib.Test
{
    [TestClass]
    public class Vector3Test
    {

        [TestMethod]
        public void Vector3TestAdd1()
        {
            Vector3 v1 = new Vector3(new Fraction(0), new Fraction(0), new Fraction(0));
            Vector3 v2 = new Vector3(new Fraction(1), new Fraction(1), new Fraction(1));

            Vector3 v3 = v1 + v2;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(1), v3.Y);
            Assert.AreEqual(new Fraction(1), v3.Z);
        }


        [TestMethod]
        public void Vector3TestSubtract1()
        {
            Vector3 v1 = new Vector3(new Fraction(1), new Fraction(1), new Fraction(1));
            Vector3 v2 = new Vector3(new Fraction(1), new Fraction(1), new Fraction(1));

            Vector3 v3 = v1 - v2;

            Assert.AreEqual(new Fraction(0), v3.X);
            Assert.AreEqual(new Fraction(0), v3.Y);
            Assert.AreEqual(new Fraction(0), v3.Z);
        }


        [TestMethod]
        public void Vector3TestMultiplyScalar1()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(3), new Fraction(3));
            double d1 = 3;

            Vector3 v3 = v1 * d1;

            Assert.AreEqual(new Fraction(6), v3.X);
            Assert.AreEqual(new Fraction(9), v3.Y);
            Assert.AreEqual(new Fraction(9), v3.Z);
        }


        [TestMethod]
        public void Vector3TestMultiplyScalar2()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(3), new Fraction(3));
            double d1 = 3;

            Vector3 v3 = d1 * v1;

            Assert.AreEqual(new Fraction(6), v3.X);
            Assert.AreEqual(new Fraction(9), v3.Y);
            Assert.AreEqual(new Fraction(9), v3.Z);
        }


        [TestMethod]
        public void Vector3TestDivideVector1()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(4), new Fraction(6));
            Vector3 v2 = new Vector3(new Fraction(2), new Fraction(2), new Fraction(2));

            Vector3 v3 = v1 / v2;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(2), v3.Y);
            Assert.AreEqual(new Fraction(3), v3.Z);
        }


        [TestMethod]
        public void Vector3TestDivideScalar1()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(4), new Fraction(6));
            double d1 = 2;

            Vector3 v3 = v1 / d1;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(2), v3.Y);
            Assert.AreEqual(new Fraction(3), v3.Z);
        }


        [TestMethod]
        public void Vector3TestDot1()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(4), new Fraction(6));
            Vector3 v2 = new Vector3(new Fraction(2), new Fraction(2), new Fraction(2));

            Fraction d1 = v1.Dot(v2);

            Assert.AreEqual(new Fraction(24), d1);
        }


        [TestMethod]
        public void Vector3TestCross1()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(4), new Fraction(6));
            Vector3 v2 = new Vector3(new Fraction(2), new Fraction(2), new Fraction(2));

            Vector3 v3 = v1.Cross(v2);

            Assert.AreEqual(new Fraction(-4), v3.X);
            Assert.AreEqual(new Fraction(8), v3.Y);
            Assert.AreEqual(new Fraction(-4), v3.Z);
        }


        [TestMethod]
        public void Vector3TestCross2()
        {
            Vector3 v1 = new Vector3(new Fraction(6), new Fraction(-7), new Fraction(5));
            Vector3 v2 = new Vector3(new Fraction(-5), new Fraction(4), new Fraction(6));

            Vector3 v3 = v1.Cross(v2);

            Assert.AreEqual(new Fraction(-62), v3.X);
            Assert.AreEqual(new Fraction(-61), v3.Y);
            Assert.AreEqual(new Fraction(-11), v3.Z);
        }


        [TestMethod]
        public void Vector3TestCross3()
        {
            Vector3 v1 = new Vector3(new Fraction(2), new Fraction(5), new Fraction(12));
            Vector3 v2 = new Vector3(new Fraction(3), new Fraction(-1), new Fraction(2));

            Vector3 v3 = v1.Cross(v2);

            Assert.AreEqual(new Fraction(22), v3.X);
            Assert.AreEqual(new Fraction(32), v3.Y);
            Assert.AreEqual(new Fraction(-17), v3.Z);
        }


        [TestMethod]
        public void Vector3TestLength1()
        {
            Vector3 v1 = new Vector3(new Fraction(3), new Fraction(4), new Fraction(5));

            Fraction f1 = v1.Length();
            double d1 = f1.ToDouble(5);

            //Assert.AreEqual(new Fraction(22), f1);
            Assert.AreEqual(7.07107, d1, .0001d);
        }


        [TestMethod]
        public void Vector3TestLengthSquared1()
        {
            Vector3 v1 = new Vector3(new Fraction(3), new Fraction(4), new Fraction(5));

            Fraction d1 = v1.LengthSquared();

            Assert.AreEqual(new Fraction(50), d1);
        }


        //[TestMethod]
        //public void Vector3TestNormalize1()
        //{
        //    Vector3 v1 = new Vector3(3, 4, 5);

        //    Vector3 v2 = v1.Normalize();

        //    Assert.AreEqual(.424264, v2.x, .0001d);
        //    Assert.AreEqual(.565685, v2.y, .0001d);
        //    Assert.AreEqual(.707107, v2.z, .0001d);
        //}


        [TestMethod]
        public void A2_12()
        {
            Vector3 a = new Vector3(new Fraction(1), new Fraction(-3), new Fraction(4));
            Vector3 b = new Vector3(new Fraction(2), new Fraction(5), new Fraction(-6));
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Vector3 answer = a + b;

            Assert.AreEqual(new Fraction(3), answer.X);
            Assert.AreEqual(new Fraction(2), answer.Y);
            Assert.AreEqual(new Fraction(-2), answer.Z);
        }


        [TestMethod]
        public void A2_13()
        {
            Vector3 a = new Vector3(new Fraction(1), new Fraction(-3), new Fraction(4));
            Vector3 b = new Vector3(new Fraction(2), new Fraction(5), new Fraction(-6));
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Vector3 a2 = 2 * a;
            Vector3 b3 = 3 * b;

            Vector3 answer = a2 - b3;

            Assert.AreEqual(new Fraction(-4), answer.X);
            Assert.AreEqual(new Fraction(-21), answer.Y);
            Assert.AreEqual(new Fraction(26), answer.Z);
        }


        [TestMethod]
        public void A2_14()
        {
            Vector3 a = new Vector3(new Fraction(1), new Fraction(-3), new Fraction(4));
            Vector3 b = new Vector3(new Fraction(2), new Fraction(5), new Fraction(-6));
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Vector3 v = b + c;

            Fraction answer = v.Length();

            Assert.AreEqual(Fraction.Parse(Math.Sqrt(5)), answer);
        }


        [TestMethod]
        public void A2_15()
        {
            Vector3 a = new Vector3(new Fraction(1), new Fraction(-3), new Fraction(4));
            Vector3 b = new Vector3(new Fraction(2), new Fraction(5), new Fraction(-6));
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Fraction answer = b.Dot(c);

            Assert.AreEqual(new Fraction(-75), answer);
        }


        [TestMethod]
        public void A2_16()
        {
            Vector3 a = new Vector3(new Fraction(1), new Fraction(-3), new Fraction(4));
            Vector3 b = new Vector3(new Fraction(2), new Fraction(5), new Fraction(-6));
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Vector3 answer = a.Cross(b);

            Assert.AreEqual(new Fraction(-2), answer.X);
            Assert.AreEqual(new Fraction(14), answer.Y);
            Assert.AreEqual(new Fraction(11), answer.Z);
        }


        [TestMethod]
        public void A2_17()
        {
            Vector3 c = new Vector3(new Fraction(-4), new Fraction(-5), new Fraction(7));

            Vector3 answer = c.Normalize();

            Fraction l = Fraction.Parse(Math.Sqrt(90));

            Assert.AreEqual(new Fraction(-4) / l, answer.X);
            Assert.AreEqual(new Fraction(-5) / l, answer.Y);
            Assert.AreEqual(new Fraction(7) / l, answer.Z);
        }


        [TestMethod]
        public void E1_1a()
        {
            Vector3 u = new Vector3(new Fraction(2), new Fraction(-18), new Fraction(12));
            Vector3 v = new Vector3(new Fraction(5), new Fraction(9), new Fraction(6));

            Vector3 answer = u + (3 * v);

            Assert.AreEqual(new Fraction(17), answer.X);
            Assert.AreEqual(new Fraction(9), answer.Y);
            Assert.AreEqual(new Fraction(30), answer.Z);
        }


        [TestMethod]
        public void E1_2a()
        {
            Vector3 v = new Vector3(new Fraction(5), new Fraction(9), new Fraction(6));

            Fraction answer = v.Length();

            Assert.AreEqual(Fraction.Parse(Math.Sqrt(142)), answer);
        }


        [TestMethod]
        public void E1_4()
        {
            Vector3 w = new Vector3(new Fraction(-3), new Fraction(9), new Fraction(-11));
            Vector3 v = new Vector3(new Fraction(5), new Fraction(9), new Fraction(6));

            Vector3 answer = w.Cross(v);

            Assert.AreEqual(new Fraction(153), answer.X);
            Assert.AreEqual(new Fraction(-37), answer.Y);
            Assert.AreEqual(new Fraction(-72), answer.Z);
        }
    }
}
