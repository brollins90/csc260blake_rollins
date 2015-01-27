//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace LinearAlgebraCalcLib.Test
//{
//    [TestClass]
//    public class Mat2Test
//    {

//        [TestMethod]
//        public void Mat2TestTestAdd1()
//        {
//            Mat2 m1 = new Mat2(new Fraction(0), new Fraction(0), new Fraction(0), new Fraction(0));
//            Mat2 m2 = new Mat2(new Fraction(1), new Fraction(1), new Fraction(1), new Fraction(1));

//            Mat2 m3 = m1 + m2;

//            Assert.AreEqual(new Fraction(1), m3.A11);
//            Assert.AreEqual(new Fraction(1), m3.A12);
//            Assert.AreEqual(new Fraction(1), m3.A21);
//            Assert.AreEqual(new Fraction(1), m3.A22);
//        }


//        [TestMethod]
//        public void Mat2TestSubtract1()
//        {
//            Mat2 m1 = new Mat2(new Fraction(1), new Fraction(1), new Fraction(1), new Fraction(1));
//            Mat2 m2 = new Mat2(new Fraction(1), new Fraction(1), new Fraction(1), new Fraction(1));

//            Mat2 m3 = m1 - m2;

//            Assert.AreEqual(new Fraction(0), m3.A11);
//            Assert.AreEqual(new Fraction(0), m3.A12);
//            Assert.AreEqual(new Fraction(0), m3.A21);
//            Assert.AreEqual(new Fraction(0), m3.A22);
//        }


//        [TestMethod]
//        public void Mat2TestMultiplyScalar1()
//        {
//            Mat2 m1 = new Mat2(new Fraction(1), new Fraction(1), new Fraction(1), new Fraction(1));
//            double d1 = 3;

//            Mat2 m3 = m1 * d1;

//            Assert.AreEqual(new Fraction(3), m3.A11);
//            Assert.AreEqual(new Fraction(3), m3.A12);
//            Assert.AreEqual(new Fraction(3), m3.A21);
//            Assert.AreEqual(new Fraction(3), m3.A22);
//        }


//        [TestMethod]
//        public void Mat2TestMultiplyScalar2()
//        {
//            Mat2 m1 = new Mat2(new Fraction(4), new Fraction(4), new Fraction(4), new Fraction(4));
//            double d1 = .5;

//            Mat2 m3 = d1 * m1;

//            Assert.AreEqual(new Fraction(2), m3.A11);
//            Assert.AreEqual(new Fraction(2), m3.A12);
//            Assert.AreEqual(new Fraction(2), m3.A21);
//            Assert.AreEqual(new Fraction(2), m3.A22);
//        }

//        // inverse
//        [TestMethod]
//        public void Mat2TestInverse1()
//        {
//            Mat2 m1 = new Mat2(
//                new Fraction(1), new Fraction(-3),
//                new Fraction(2), new Fraction(5));
//            Mat2 m3 = m1.Inverse();

//            Assert.AreEqual(new Fraction(5,11), m3.A11);
//            Assert.AreEqual(new Fraction(3,11), m3.A12);
//            Assert.AreEqual(new Fraction(-2,11), m3.A21);
//            Assert.AreEqual(new Fraction(1,11), m3.A22);
//        }

//        // transpose
//        [TestMethod]
//        public void Mat2TestTranspose1()
//        {
//            Mat2 m1 = new Mat2(
//                new Fraction(2), new Fraction(2),
//                new Fraction(-5), new Fraction(9));
//            Mat2 m3 = m1.Inverse();

//            Assert.AreEqual(new Fraction(2), m3.A11);
//            Assert.AreEqual(new Fraction(-5), m3.A12);
//            Assert.AreEqual(new Fraction(2), m3.A21);
//            Assert.AreEqual(new Fraction(9), m3.A22);
//        }


//    }
//}
