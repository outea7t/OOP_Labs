using Lab_1.Task_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1_Tests
{
    [TestClass]
    public class RationalTests 
    {
        // Негативные тесты
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rational_ThrowsArgumentException()
        {
            var rational = new Rational(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Rational_ThrowsDivideByZeroException()
        { 
            var a = new Rational(2, 1);
            var b = new Rational(0, 1);

            var result = a / b;
        }

        // Позитивные тесты
        [TestMethod]
        public void TestToString_1()
        {
            var rational = new Rational(10, 5);
            Assert.AreEqual("2", rational.ToString());
        }

        [TestMethod]
        public void TestToString_2()
        {
            var rational = new Rational(-20, 4);
            Assert.AreEqual("-5", rational.ToString());
        }

        [TestMethod]
        public void TestToString_3()
        {
            var rational = new Rational(3, 4);
            Assert.AreEqual("3/4", rational.ToString());
        }

        [TestMethod]
        public void TestToString_4()
        {
            var rational = new Rational(7, -4);
            Assert.AreEqual("-7/4", rational.ToString());
        }

        [TestMethod]
        public void TestToString_5()
        {
            var rational = new Rational(-7, -4);
            Assert.AreEqual("7/4", rational.ToString());
        }

        [TestMethod]
        public void TestToString_6()
        {
            var rational = new Rational(-7, 4);
            Assert.AreEqual("-7/4", rational.ToString());
        }

        [TestMethod]
        public void TestToString_7()
        {
            var rational = new Rational(0, -4);
            Assert.AreEqual("0", rational.ToString());
        }

        [TestMethod]
        public void TestAddition_1()
        {
            var result = new Rational(1, 2) + new Rational(1, 3);
            Assert.AreEqual("5/6", result.ToString());
        }

        [TestMethod]
        public void TestAddition_2()
        {
            var result = new Rational(1, 4) + new Rational(3, 4);
            Assert.AreEqual("1", result.ToString());
        }

        [TestMethod]
        public void TestAddition_3()
        {
            var result = new Rational(1, 2) + new Rational(-1, 2);
            Assert.AreEqual("0", result.ToString());
        }

        [TestMethod]
        public void TestSubtraction_1()
        {
            var result = new Rational(1, 2) - new Rational(1, 3);
            Assert.AreEqual("1/6", result.ToString());
        }

        [TestMethod]
        public void TestSubtraction_2()
        {
            var result = new Rational(3, 4) - new Rational(1, 4);
            Assert.AreEqual("1/2", result.ToString());
        }

        [TestMethod]
        public void TestSubtraction_3()
        {
            var result = new Rational(1, 4) - new Rational(3, 4);
            Assert.AreEqual("-1/2", result.ToString());
        }

        [TestMethod]
        public void TestMultiplication_1()
        {
            var result = new Rational(3, 4) * new Rational(1, 2);
            Assert.AreEqual("3/8", result.ToString());
        }

        [TestMethod]
        public void TestMultiplication_2()
        {
            var result = new Rational(0, 1) * new Rational(5, 7);
            Assert.AreEqual("0", result.ToString());
        }

        [TestMethod]
        public void TestMultiplication_3()
        {
            var result = new Rational(-1, 2) * new Rational(1, 1);
            Assert.AreEqual("-1/2", result.ToString());
        }

        [TestMethod]
        public void TestMultiplication_4()
        {
            var result = new Rational(3, 6) * new Rational(2, 1);
            Assert.AreEqual("1", result.ToString());
        }

        [TestMethod]
        public void TestDivision_1()
        {
            var result = new Rational(3, 4) / new Rational(1, 2);
            Assert.AreEqual("3/2", result.ToString());
        }

        [TestMethod]
        public void TestDivision_2()
        {
            var result = new Rational(2, 3) / new Rational(2, 3);
            Assert.AreEqual("1", result.ToString());
        }

        [TestMethod]
        public void TestDivision_3()
        {
            var result = new Rational(2, 3) / new Rational(-2, 3);
            Assert.AreEqual("-1", result.ToString());
        }

        [TestMethod]
        public void TestUnaryMinus_1()
        {
            var result = new Rational(1, 2);
            result = -result;
            Assert.AreEqual("-1/2", result.ToString());
        }

        [TestMethod]
        public void TestUnaryMinus_2()
        {
            var result = -new Rational(-1, 2);
            Assert.AreEqual("1/2", result.ToString());
        }

        [TestMethod]
        public void TestEquality_1()
        {
            var result = new Rational(2, 4) == new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEquality_2()
        {
            var result = new Rational(2, 3) == new Rational(1, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestInequality_1()
        {
            var result = new Rational(4, 4) != new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInequality_2()
        {
            var result = new Rational(2, 4) != new Rational(1, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLessThan_1()
        {
            var result = new Rational(1, 3) < new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLessThan_2()
        {
            var result = new Rational(3, 4) < new Rational(1, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLessThan_3()
        {
            var result = new Rational(3, 4) < new Rational(3, 4);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestLessThanOrEqual_1()
        {
            var result = new Rational(1, 3) <= new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLessThanOrEqual_2()
        {
            var result = new Rational(4, 3) <= new Rational(4, 3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestLessThanOrEqual_3()
        {
            var result = new Rational(4, 1) <= new Rational(4, 3);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestGreaterThan_1()
        {
            var result = new Rational(3, 4) > new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGreaterThan_2()
        {
            var result = new Rational(1, 4) > new Rational(1, 2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGreaterThan_3()
        {
            var result = new Rational(1, 4) > new Rational(1, 4);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGreaterThanOrEqual_1()
        {
            var result = new Rational(3, 4) >= new Rational(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGreaterThanOrEqual_2()
        {
            var result = new Rational(3, 4) >= new Rational(3, 4);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGreaterThanOrEqual_3()
        {
            var result = new Rational(3, 4) >= new Rational(7, 8);
            Assert.IsFalse(result);
        }

    }
}