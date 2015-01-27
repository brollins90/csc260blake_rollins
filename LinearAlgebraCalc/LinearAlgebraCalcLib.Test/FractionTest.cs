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

        [TestMethod]
        public void FractionTestMultiply1()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1);

            Fraction f3 = f1 * f2;

            Assert.AreEqual(1, f3.Top);
            Assert.AreEqual(2, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestMultiply2()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2);

            Fraction f3 = f1 * f2;

            Assert.AreEqual(1, f3.Top);
            Assert.AreEqual(1, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestMultiply3()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction f3 = f1 * f2;

            Assert.AreEqual(1, f3.Top);
            Assert.AreEqual(4, f3.Bottom);
        }

        [TestMethod]
        public void FractionTestParse1()
        {
            string s = "10";

            Fraction f1 = Fraction.Parse(s);

            Assert.AreEqual(10, f1.Top);
            Assert.AreEqual(1, f1.Bottom);
        }

        [TestMethod]
        public void FractionTestParse2()
        {
            string s = "10/2";

            Fraction f1 = Fraction.Parse(s);

            Assert.AreEqual(5, f1.Top);
            Assert.AreEqual(1, f1.Bottom);
        }

        [TestMethod]
        public void FractionTestParse3()
        {
            string s = "5.5";

            Fraction f1 = Fraction.Parse(s);

            Assert.AreEqual(11, f1.Top);
            Assert.AreEqual(2, f1.Bottom);
        }

    //    [TestMethod]
    //    public void FractionTestParse4()
    //    {
    //        string s = ".3333";

    //        Fraction f1 = Fraction.Parse(s);

    //        Assert.AreEqual(1, f1.Top);
    //        Assert.AreEqual(3, f1.Bottom);
    //        //Assert.AreEqual(3236, f1.Top);
    //        //Assert.AreEqual(9709, f1.Bottom);
    //    }
    }
}
