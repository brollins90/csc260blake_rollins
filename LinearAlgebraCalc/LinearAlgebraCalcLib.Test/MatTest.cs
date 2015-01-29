using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearAlgebraCalcLib.Test
{
    [TestClass]
    public class MatTest
    {

        [TestMethod]
        public void MatTestTestAdd1()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(0);
            m1.a[0, 1] = new Fraction(0);
            m1.a[1, 0] = new Fraction(0);
            m1.a[1, 1] = new Fraction(0);

            Mat m2 = new Mat(2, 2);
            m2.a[0, 0] = new Fraction(1);
            m2.a[0, 1] = new Fraction(1);
            m2.a[1, 0] = new Fraction(1);
            m2.a[1, 1] = new Fraction(1);

            Mat m3 = m1 + m2;

            Assert.AreEqual(new Fraction(1), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(1), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 1]);
        }

        [TestMethod]
        public void MatTestTestAdd2()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(0);
            m1.a[0, 1] = new Fraction(0);
            m1.a[1, 0] = new Fraction(0);
            m1.a[1, 1] = new Fraction(0);

            Mat m2 = new Mat(2, 3);

            try
            {
                Mat m3 = m1 + m2;
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

        [TestMethod]
        public void MatTestTestAdd3()
        {
            Mat m1 = new Mat(3, 2);
            Mat m2 = new Mat(2, 3);

            try
            {
                Mat m3 = m1 + m2;
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }


        [TestMethod]
        public void MatTestSubtract1()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(2);
            m1.a[0, 1] = new Fraction(2);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(2);

            Mat m2 = new Mat(2, 2);
            m2.a[0, 0] = new Fraction(1);
            m2.a[0, 1] = new Fraction(1);
            m2.a[1, 0] = new Fraction(1);
            m2.a[1, 1] = new Fraction(1);

            Mat m3 = m1 - m2;

            Assert.AreEqual(new Fraction(1), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(1), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 1]);
        }


        [TestMethod]
        public void MatTestSubtract2()
        {
            Mat m1 = new Mat(2, 2);
            Mat m2 = new Mat(2, 3);

            try
            {
                Mat m3 = m1 - m2;
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }


        [TestMethod]
        public void MatTestSubtract3()
        {
            Mat m1 = new Mat(3, 2);
            Mat m2 = new Mat(2, 3);

            try
            {
                Mat m3 = m1 - m2;
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }


        [TestMethod]
        public void MatTestMultiplyScalar1()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(2);
            m1.a[0, 1] = new Fraction(2);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(2);

            double d1 = 3;

            Mat m3 = m1 * d1;

            Assert.AreEqual(new Fraction(6), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(6), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(6), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(6), m3.a[1, 1]);
        }


        [TestMethod]
        public void MatTestMultiply1()
        {
            Mat m1 = new Mat(2, 3);
            m1.a[0, 0] = new Fraction(3);
            m1.a[0, 1] = new Fraction(4);
            m1.a[0, 2] = new Fraction(7);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(6);
            m1.a[1, 2] = new Fraction(9);

            Mat m2 = new Mat(3, 2);
            m2.a[0, 0] = new Fraction(2);
            m2.a[0, 1] = new Fraction(-1);
            m2.a[1, 0] = new Fraction(3);
            m2.a[1, 1] = new Fraction(-3);
            m2.a[2, 0] = new Fraction(1);
            m2.a[2, 1] = new Fraction(-4);

            Mat m3 = m1 * m2;

            Assert.AreEqual(new Fraction(25), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(-43), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(31), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(-56), m3.a[1, 1]);
        }


        [TestMethod]
        public void MatTestMultiply2()
        {
            Mat m1 = new Mat(3, 2);
            m1.a[0, 0] = new Fraction(2);
            m1.a[0, 1] = new Fraction(-1);
            m1.a[1, 0] = new Fraction(3);
            m1.a[1, 1] = new Fraction(-3);
            m1.a[2, 0] = new Fraction(1);
            m1.a[2, 1] = new Fraction(-4);

            Mat m2 = new Mat(2, 3);
            m2.a[0, 0] = new Fraction(3);
            m2.a[0, 1] = new Fraction(4);
            m2.a[0, 2] = new Fraction(7);
            m2.a[1, 0] = new Fraction(2);
            m2.a[1, 1] = new Fraction(6);
            m2.a[1, 2] = new Fraction(9);

            Mat m3 = m1 * m2;

            Assert.AreEqual(new Fraction(4), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(2), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(5), m3.a[0, 2]);
            Assert.AreEqual(new Fraction(3), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(-6), m3.a[1, 1]);
            Assert.AreEqual(new Fraction(-6), m3.a[1, 2]);
            Assert.AreEqual(new Fraction(-5), m3.a[2, 0]);
            Assert.AreEqual(new Fraction(-20), m3.a[2, 1]);
            Assert.AreEqual(new Fraction(-29), m3.a[2, 2]);
        }

        // inverse
        [TestMethod]
        public void MatTestInverse0()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(3);
            m1.a[0, 1] = new Fraction(0);
            m1.a[0, 2] = new Fraction(2);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(0);
            m1.a[1, 2] = new Fraction(-2);
            m1.a[2, 0] = new Fraction(0);
            m1.a[2, 1] = new Fraction(1);
            m1.a[2, 2] = new Fraction(1);
            Mat m3 = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(1, 5), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(1, 5), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(0), m3.a[0, 2]);
            Assert.AreEqual(new Fraction(-1, 5), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(3, 10), m3.a[1, 1]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 2]);
            Assert.AreEqual(new Fraction(1, 5), m3.a[2, 0]);
            Assert.AreEqual(new Fraction(-3, 10), m3.a[2, 1]);
            Assert.AreEqual(new Fraction(0), m3.a[2, 2]);
        }

        // inverse
        [TestMethod]
        public void MatTestInverse1()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(1);
            m1.a[0, 1] = new Fraction(-3);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(5);
            Mat m3 = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(5, 11), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(3, 11), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(-2, 11), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(1, 11), m3.a[1, 1]);
        }

        // inverse
        [TestMethod]
        public void MatTestInverse2()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(3);
            m1.a[0, 1] = new Fraction(-3);
            m1.a[0, 2] = new Fraction(4);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(-3);
            m1.a[1, 2] = new Fraction(4);
            m1.a[2, 0] = new Fraction(0);
            m1.a[2, 1] = new Fraction(-1);
            m1.a[2, 2] = new Fraction(1);
            Mat m3 = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(1), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(-1), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(0), m3.a[0, 2]);
            Assert.AreEqual(new Fraction(-2), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(3), m3.a[1, 1]);
            Assert.AreEqual(new Fraction(-4), m3.a[1, 2]);
            Assert.AreEqual(new Fraction(-2), m3.a[2, 0]);
            Assert.AreEqual(new Fraction(3), m3.a[2, 1]);
            Assert.AreEqual(new Fraction(-3), m3.a[2, 2]);
        }

        // transpose
        [TestMethod]
        public void MatTestTranspose1()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(2);
            m1.a[0, 1] = new Fraction(2);
            m1.a[1, 0] = new Fraction(-5);
            m1.a[1, 1] = new Fraction(9);
            Mat m3 = m1.Transpose();

            Assert.AreEqual(new Fraction(2), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(-5), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(2), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(9), m3.a[1, 1]);
        }

        [TestMethod]
        public void MatTestTranspose2()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(3);
            m1.a[0, 1] = new Fraction(7);
            m1.a[0, 2] = new Fraction(9);
            m1.a[1, 0] = new Fraction(6);
            m1.a[1, 1] = new Fraction(-3);
            m1.a[1, 2] = new Fraction(-8);
            m1.a[2, 0] = new Fraction(-12);
            m1.a[2, 1] = new Fraction(1);
            m1.a[2, 2] = new Fraction(0);
            Mat m3 = m1.Transpose();

            Assert.AreEqual(new Fraction(3), m3.a[0, 0]);
            Assert.AreEqual(new Fraction(6), m3.a[0, 1]);
            Assert.AreEqual(new Fraction(-12), m3.a[0, 2]);
            Assert.AreEqual(new Fraction(7), m3.a[1, 0]);
            Assert.AreEqual(new Fraction(-3), m3.a[1, 1]);
            Assert.AreEqual(new Fraction(1), m3.a[1, 2]);
            Assert.AreEqual(new Fraction(9), m3.a[2, 0]);
            Assert.AreEqual(new Fraction(-8), m3.a[2, 1]);
            Assert.AreEqual(new Fraction(0), m3.a[2, 2]);
        }


        [TestMethod]
        public void A3_1f()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(-1);
            m1.a[0, 1] = new Fraction(4);
            m1.a[1, 0] = new Fraction(-3);
            m1.a[1, 1] = new Fraction(8);

            Mat answer = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(2), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(-1), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(3, 4), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(-1, 4), answer.a[1, 1]);
        }


        [TestMethod]
        public void A3_1g()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(3);
            m1.a[0, 1] = new Fraction(-5);
            m1.a[1, 0] = new Fraction(5);
            m1.a[1, 1] = new Fraction(-9);

            Mat answer = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(9, 2), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(-5, 2), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(5, 2), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(-3, 2), answer.a[1, 1]);
        }


        [TestMethod]
        public void A3_3()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(1);
            m1.a[0, 1] = new Fraction(3);
            m1.a[0, 2] = new Fraction(5);
            m1.a[1, 0] = new Fraction(2);
            m1.a[1, 1] = new Fraction(7);
            m1.a[1, 2] = new Fraction(13);
            m1.a[2, 0] = new Fraction(3);
            m1.a[2, 1] = new Fraction(11);
            m1.a[2, 2] = new Fraction(22);

            Mat answer = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(11), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(-11), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(4), answer.a[0, 2]);
            Assert.AreEqual(new Fraction(-5), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(7), answer.a[1, 1]);
            Assert.AreEqual(new Fraction(-3), answer.a[1, 2]);
            Assert.AreEqual(new Fraction(1), answer.a[2, 0]);
            Assert.AreEqual(new Fraction(-2), answer.a[2, 1]);
            Assert.AreEqual(new Fraction(1), answer.a[2, 2]);
        }


        [TestMethod]
        public void E1_7()
        {
            Mat m1 = new Mat(2, 2);
            m1.a[0, 0] = new Fraction(-2);
            m1.a[0, 1] = new Fraction(-9);
            m1.a[1, 0] = new Fraction(-5);
            m1.a[1, 1] = new Fraction(3);

            Mat answer = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(-3, 51), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(-9, 51), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(-5, 51), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(2, 51), answer.a[1, 1]);
        }


        [TestMethod]
        public void E1_8()
        {
            Mat m1 = new Mat(4, 3);
            m1.a[0, 0] = new Fraction(1);
            m1.a[0, 1] = new Fraction(3);
            m1.a[0, 2] = new Fraction(2);
            m1.a[1, 0] = new Fraction(-2);
            m1.a[1, 1] = new Fraction(-1);
            m1.a[1, 2] = new Fraction(3);
            m1.a[2, 0] = new Fraction(4);
            m1.a[2, 1] = new Fraction(-5);
            m1.a[2, 2] = new Fraction(2);
            m1.a[3, 0] = new Fraction(3);
            m1.a[3, 1] = new Fraction(-2);
            m1.a[3, 2] = new Fraction(-1);

            Mat m2 = new Mat(3, 5);
            m2.a[0, 0] = new Fraction(2);
            m2.a[0, 1] = new Fraction(3);
            m2.a[0, 2] = new Fraction(-1);
            m2.a[0, 3] = new Fraction(5);
            m2.a[0, 4] = new Fraction(-2);
            m2.a[1, 0] = new Fraction(-2);
            m2.a[1, 1] = new Fraction(4);
            m2.a[1, 2] = new Fraction(6);
            m2.a[1, 3] = new Fraction(-1);
            m2.a[1, 4] = new Fraction(7);
            m2.a[2, 0] = new Fraction(-1);
            m2.a[2, 1] = new Fraction(-3);
            m2.a[2, 2] = new Fraction(-2);
            m2.a[2, 3] = new Fraction(4);
            m2.a[2, 4] = new Fraction(-1);

            Mat answer = m1 * m2;

            Assert.AreEqual(new Fraction(-6), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(9), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(13), answer.a[0, 2]);
            Assert.AreEqual(new Fraction(10), answer.a[0, 3]);
            Assert.AreEqual(new Fraction(17), answer.a[0, 4]);
            Assert.AreEqual(new Fraction(-5), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(-19), answer.a[1, 1]);
            Assert.AreEqual(new Fraction(-10), answer.a[1, 2]);
            Assert.AreEqual(new Fraction(3), answer.a[1, 3]);
            Assert.AreEqual(new Fraction(-6), answer.a[1, 4]);
            Assert.AreEqual(new Fraction(16), answer.a[2, 0]);
            Assert.AreEqual(new Fraction(-14), answer.a[2, 1]);
            Assert.AreEqual(new Fraction(-38), answer.a[2, 2]);
            Assert.AreEqual(new Fraction(33), answer.a[2, 3]);
            Assert.AreEqual(new Fraction(-45), answer.a[2, 4]);
            Assert.AreEqual(new Fraction(11), answer.a[3, 0]);
            Assert.AreEqual(new Fraction(4), answer.a[3, 1]);
            Assert.AreEqual(new Fraction(-13), answer.a[3, 2]);
            Assert.AreEqual(new Fraction(13), answer.a[3, 3]);
            Assert.AreEqual(new Fraction(-19), answer.a[3, 4]);
        }


        [TestMethod]
        public void E1_9()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(1);
            m1.a[0, 1] = new Fraction(-3);
            m1.a[0, 2] = new Fraction(6);
            m1.a[1, 0] = new Fraction(10);
            m1.a[1, 1] = new Fraction(12);
            m1.a[1, 2] = new Fraction(-5);
            m1.a[2, 0] = new Fraction(-8);
            m1.a[2, 1] = new Fraction(11);
            m1.a[2, 2] = new Fraction(2);

            Mat m2 = new Mat(3, 3);
            m2.a[0, 0] = new Fraction(-5);
            m2.a[0, 1] = new Fraction(3);
            m2.a[0, 2] = new Fraction(6);
            m2.a[1, 0] = new Fraction(2);
            m2.a[1, 1] = new Fraction(-4);
            m2.a[1, 2] = new Fraction(-1);
            m2.a[2, 0] = new Fraction(2);
            m2.a[2, 1] = new Fraction(-3);
            m2.a[2, 2] = new Fraction(4);

            Mat answer = m1 + (m2 * 3);

            Assert.AreEqual(new Fraction(-14), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(6), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(24), answer.a[0, 2]);
            Assert.AreEqual(new Fraction(16), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(0), answer.a[1, 1]);
            Assert.AreEqual(new Fraction(-8), answer.a[1, 2]);
            Assert.AreEqual(new Fraction(-2), answer.a[2, 0]);
            Assert.AreEqual(new Fraction(2), answer.a[2, 1]);
            Assert.AreEqual(new Fraction(14), answer.a[2, 2]);
        }


        [TestMethod]
        public void E1_10()
        {
            Mat m1 = new Mat(3, 3);
            m1.a[0, 0] = new Fraction(1);
            m1.a[0, 1] = new Fraction(-2);
            m1.a[0, 2] = new Fraction(1);
            m1.a[1, 0] = new Fraction(-5);
            m1.a[1, 1] = new Fraction(7);
            m1.a[1, 2] = new Fraction(-3);
            m1.a[2, 0] = new Fraction(11);
            m1.a[2, 1] = new Fraction(-11);
            m1.a[2, 2] = new Fraction(4);

            Mat answer = Mat.Inverse(m1);

            Assert.AreEqual(new Fraction(5), answer.a[0, 0]);
            Assert.AreEqual(new Fraction(3), answer.a[0, 1]);
            Assert.AreEqual(new Fraction(1), answer.a[0, 2]);
            Assert.AreEqual(new Fraction(13), answer.a[1, 0]);
            Assert.AreEqual(new Fraction(7), answer.a[1, 1]);
            Assert.AreEqual(new Fraction(2), answer.a[1, 2]);
            Assert.AreEqual(new Fraction(22), answer.a[2, 0]);
            Assert.AreEqual(new Fraction(11), answer.a[2, 1]);
            Assert.AreEqual(new Fraction(3), answer.a[2, 2]);
        }


    }
}
