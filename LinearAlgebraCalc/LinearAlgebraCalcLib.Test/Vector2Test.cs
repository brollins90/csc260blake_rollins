using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearAlgebraCalcLib.Test
{
    [TestClass]
    public class Vector2Test
    {

        [TestMethod]
        public void Vector2TestAdd1()
        {
            Vector2 v1 = new Vector2(new Fraction(0), new Fraction(0));
            Vector2 v2 = new Vector2(new Fraction(1), new Fraction(1));

            Vector2 v3 = v1 + v2;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(1), v3.Y);
        }

        [TestMethod]
        public void Vector2TestAdd2A2()
        {
            Vector2 v1 = new Vector2(new Fraction(-3), new Fraction(9));
            Vector2 v2 = new Vector2(new Fraction(2), new Fraction(-8));

            Vector2 v3 = v1 + v2;

            Assert.AreEqual(new Fraction(-1), v3.X);
            Assert.AreEqual(new Fraction(1), v3.Y);
        }


        [TestMethod]
        public void Vector2TestSubtract1()
        {
            Vector2 v1 = new Vector2(new Fraction(1), new Fraction(1));
            Vector2 v2 = new Vector2(new Fraction(1), new Fraction(1));

            Vector2 v3 = v1 - v2;

            Assert.AreEqual(new Fraction(0), v3.X);
            Assert.AreEqual(new Fraction(0), v3.Y);
        }


        [TestMethod]
        public void Vector2TestSubtract2A2()
        {
            Vector2 v1 = new Vector2(new Fraction(-9), new Fraction(27));
            Vector2 v2 = new Vector2(new Fraction(10), new Fraction(-40));

            Vector2 v3 = v1 - v2;

            Assert.AreEqual(new Fraction(-19), v3.X);
            Assert.AreEqual(new Fraction(67), v3.Y);
        }


        [TestMethod]
        public void Vector2TestMultiplyScalar1()
        {
            Vector2 v1 = new Vector2(new Fraction(2), new Fraction(3));
            double d1 = 3;

            Vector2 v3 = v1 * d1;

            Assert.AreEqual(new Fraction(6), v3.X);
            Assert.AreEqual(new Fraction(9), v3.Y);
        }


        [TestMethod]
        public void Vector2TestMultiplyScalar2A2()
        {
            Vector2 v1 = new Vector2(new Fraction(-3), new Fraction(9));
            double d1 = 3;

            Vector2 v3 = v1 * d1;

            Assert.AreEqual(new Fraction(-9), v3.X);
            Assert.AreEqual(new Fraction(27), v3.Y);
        }


        [TestMethod]
        public void Vector2TestMultiplyScalar2()
        {
            Vector2 v1 = new Vector2(new Fraction(2), new Fraction(3));
            double d1 = 3;

            Vector2 v3 = d1 * v1;

            Assert.AreEqual(new Fraction(6), v3.X);
            Assert.AreEqual(new Fraction(9), v3.Y);
        }


        [TestMethod]
        public void Vector2TestDivideVector1()
        {
            Vector2 v1 = new Vector2(new Fraction(2), new Fraction(4));
            Vector2 v2 = new Vector2(new Fraction(2), new Fraction(2));

            Vector2 v3 = v1 / v2;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(2), v3.Y);
        }


        [TestMethod]
        public void Vector2TestDivideScalar1()
        {
            Vector2 v1 = new Vector2(new Fraction(2), new Fraction(4));
            double d1 = 2;

            Vector2 v3 = v1 / d1;

            Assert.AreEqual(new Fraction(1), v3.X);
            Assert.AreEqual(new Fraction(2), v3.Y);
        }


        [TestMethod]
        public void Vector2TestDot1()
        {
            Vector2 v1 = new Vector2(new Fraction(2), new Fraction(4));
            Vector2 v2 = new Vector2(new Fraction(2), new Fraction(2));

            Fraction d1 = v1.Dot(v2);

            Assert.AreEqual(new Fraction(12), d1);
        }


        [TestMethod]
        public void Vector2TestLength1()
        {
            Vector2 v1 = new Vector2(new Fraction(3), new Fraction(4));

            Fraction d1 = v1.Length();

            Assert.AreEqual(new Fraction(5), d1);
        }


        [TestMethod]
        public void Vector2TestLengthSquared1()
        {
            Vector2 v1 = new Vector2(new Fraction(3), new Fraction(4));

            Fraction d1 = v1.LengthSquared();

            Assert.AreEqual(new Fraction(25), d1);
        }


        [TestMethod]
        public void Vector2TestNormalize1()
        {
            Vector2 v1 = new Vector2(new Fraction(3), new Fraction(4));

            Vector2 v2 = v1.Normalize();

            Assert.AreEqual(new Fraction(3,5), v2.X);
            Assert.AreEqual(new Fraction(4,5), v2.Y);
        }


        [TestMethod]
        public void A2_1()
        {
            Vector2 u = new Vector2(new Fraction(-3), new Fraction(9));
            Vector2 v = new Vector2(new Fraction(2), new Fraction(-8));

            Vector2 answer = u + v;

            Assert.AreEqual(new Fraction(-1), answer.X);
            Assert.AreEqual(new Fraction(1), answer.Y);
        }


        [TestMethod]
        public void A2_2()
        {
            Vector2 u = new Vector2(new Fraction(-3), new Fraction(9));
            Vector2 v = new Vector2(new Fraction(2), new Fraction(-8));

            Vector2 answer = (3 * u) - ( 5 * v);

            Assert.AreEqual(new Fraction(-19), answer.X);
            Assert.AreEqual(new Fraction(67), answer.Y);
        }


        [TestMethod]
        public void A2_3()
        {
            Vector2 u = new Vector2(new Fraction(-3), new Fraction(9));
            Vector2 v = new Vector2(new Fraction(2), new Fraction(-8));

            Vector2 answer = (2 * u) + ( 6 * v);

            Assert.AreEqual(new Fraction(6), answer.X);
            Assert.AreEqual(new Fraction(-30), answer.Y);
        }


        [TestMethod]
        public void A2_4()
        {
            Vector2 u = new Vector2(new Fraction(-3), new Fraction(9));

            Fraction answer = u.Length();

            Assert.AreEqual(Fraction.Parse(Math.Sqrt(90d)), answer);
        }


        [TestMethod]
        public void A2_5()
        {
            Vector2 u = new Vector2(new Fraction(-3), new Fraction(9));
            Vector2 v = new Vector2(new Fraction(2), new Fraction(-8));

            Fraction answer = u.Dot(v);

            Assert.AreEqual(new Fraction(-78), answer);
        }


        [TestMethod]
        public void E1_1b()
        {
            Vector2 a = new Vector2(new Fraction(3), new Fraction(4));
            Vector2 b = new Vector2(new Fraction(8), new Fraction(-13));

            Vector2 answer = ( 3 * a) - b;

            Assert.AreEqual(new Fraction(1), answer.X);
            Assert.AreEqual(new Fraction(25), answer.Y);
        }


        [TestMethod]
        public void E1_2b()
        {
            Vector2 b = new Vector2(new Fraction(8), new Fraction(-13));

            Fraction answer = b.Length();

            Assert.AreEqual(Fraction.Parse(Math.Sqrt(233)), answer);
        }
    }
}
