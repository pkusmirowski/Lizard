using Lizard;
using Xunit;

namespace LizardXUnitTest
{
    public class CustomerXUnitTest
    {
        private readonly Customer customer = null!;
        public CustomerXUnitTest()
        {
            customer = new Customer();
        }

        [Fact]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Act
            string fullName = customer.CombineNames("Alan", "Becker");

            //Assert
            Assert.Equal("Hey, Alan Becker", fullName);
            Assert.Contains("alan".ToLower(), fullName.ToLower());
            Assert.StartsWith("H", fullName);
            Assert.EndsWith("Becker", fullName);
            Assert.Matches("Hey, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", fullName);
        }

        [Fact]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Assert
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.CombineNames("ben", "");

            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Lizard"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);

            Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Lizard"));
        }

        [Fact]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPremiumCustomer()
        {
            customer.OrderTotal = 101;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PremiumCustomer>(result);
        }
    }
}
