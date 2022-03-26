using Lizard;
using NUnit.Framework;

namespace LizardXUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTest
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Act
            int result = Calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnTrue()
        {
            //Calculator calc = new ();

            bool isOdd = Calculator.IsOddNumber(2);

            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(15)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Calculator calc = new();

            bool isOdd = Calculator.IsOddNumber(a);

            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputOddNumber_ReturnTrueIfOdd(int a)
        {
            return Calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)]   //15.9
        [TestCase(5.44, 10.5)]  //15.94
        [TestCase(10.4, 5.1)]   //15.5
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Act
            double result = Calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result, .5);
            //15.4 - 16.4
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //Act
            List<int> result = Calculator.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}
