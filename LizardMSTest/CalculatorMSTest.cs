using Lizard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LizardMSTest
{
    [TestClass]
    public class CalculatorMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Act
            int result = Calculator.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
