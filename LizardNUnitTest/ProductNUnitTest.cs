using Lizard;
using Moq;
using NUnit.Framework;

namespace LizardXUnitTest
{
    [TestFixture]
    public class ProductNUnitTest
    {
        [Test]
        public void GetProductPrice_PremiumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPremium = true });
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetProductPriceMOQAbuse_PremiumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.SetupGet(x => x.IsPremium).Returns(true);

            Product product = new() { Price = 50 };

            var result = product.GetPrice(customer.Object);
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
