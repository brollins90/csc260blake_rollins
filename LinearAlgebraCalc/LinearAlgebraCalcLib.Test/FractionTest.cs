using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinearAlgebraCalcLib.Test
{
    [TestClass]
    public class FractionTest
    {

        [TestMethod]
        public void FractionTestAdd1()
        {
            Fraction f1 = new Fraction(1, 1);
            Fraction f2 = new Fraction(1, 2);

            Fraction f3 = f1 + f2;

            Assert.AreEqual(3, f3.Top);
            Assert.AreEqual(2, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestAdd2()
        {
            Fraction f1 = new Fraction(2, 2);
            Fraction f2 = new Fraction(2, 4);

            Fraction f3 = f1 + f2;

            Assert.AreEqual(3, f3.Top);
            Assert.AreEqual(2, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestAdd3()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(1, 3);

            Fraction f3 = f1 + f2;

            Assert.AreEqual(2, f3.Top);
            Assert.AreEqual(3, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestSubtract1()
        {
            Fraction f1 = new Fraction(1);
            Fraction f2 = new Fraction(1, 2);

            Fraction f3 = f1 - f2;

            Assert.AreEqual(1, f3.Top);
            Assert.AreEqual(2, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestSubtract2()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1);

            Fraction f3 = f1 - f2;

            Assert.AreEqual(-1, f3.Top);
            Assert.AreEqual(2, f3.Bottom);
        }
    }
}
