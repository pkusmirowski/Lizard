using Lizard;
using Xunit;

namespace LizardXUnitTest
{
    public class CalculatorXUnitTest
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Act
            int result = Calculator.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnTrue()
        {
            bool isOdd = Calculator.IsOddNumber(2);

            Assert.False(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(15)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            bool isOdd = Calculator.IsOddNumber(a);

            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputOddNumber_ReturnTrueIfOdd(int a, bool expected)
        {
            var result = Calculator.IsOddNumber(a);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)]   //15.9
        [InlineData(5.44, 10.5)]  //15.94
        [InlineData(10.4, 5.1)]   //15.5
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Act
            double result = Calculator.AddNumbersDouble(a, b);

            //Assert
            Assert.Equal(15.9, result, 0);
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //Act
            List<int> result = Calculator.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u => u), result);
        }
    }
}
