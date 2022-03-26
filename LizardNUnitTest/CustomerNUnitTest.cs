using Lizard;
using NUnit.Framework;

namespace LizardXUnitTest
{
    [TestFixture]
    public class CustomerNUnitTest
    {
        private Customer customer = null!;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {
            //Arrange

            //Act
            string fullName = customer.CombineNames("Alan", "Becker");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.AreEqual(fullName, "Hey, Alan Becker");
                Assert.That(fullName, Is.EqualTo("Hey, Alan Becker"));
                Assert.That(fullName, Does.Contain("alan").IgnoreCase);
                Assert.That(fullName, Does.StartWith("H"));
                Assert.That(fullName, Does.EndWith("Becker"));
                Assert.That(fullName, Does.Match("Hey, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            customer.CombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Lizard"));
            if (exceptionDetails != null)
            {
                Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            }

            Assert.That(() => customer.CombineNames("", "Lizard"),
                Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));

            Assert.Throws<ArgumentException>(() => customer.CombineNames("", "Lizard"));

            Assert.That(() => customer.CombineNames("", "Lizard"), Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPremiumCustomer()
        {
            customer.OrderTotal = 101;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PremiumCustomer>());
        }
    }
}
