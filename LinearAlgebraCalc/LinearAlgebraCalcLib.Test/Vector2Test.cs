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
        public void Vector2TestSubtract1()
        {
            Vector2 v1 = new Vector2(new Fraction(1), new Fraction(1));
            Vector2 v2 = new Vector2(new Fraction(1), new Fraction(1));

            Vector2 v3 = v1 - v2;

            Assert.AreEqual(new Fraction(0), v3.X);
            Assert.AreEqual(new Fraction(0), v3.Y);
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
    }
}
