using Lizard;
using Moq;
using Xunit;

namespace LizardXUnitTest
{
    public class ProductXUnitTest
    {
        [Fact]
        public void GetProductPrice_PremiumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPremium = true });
            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PremiumCustomer_ReturnPriceWith20Discount()
        {
            var customer = new Mock<ICustomer>();
            customer.SetupGet(x => x.IsPremium).Returns(true);

            Product product = new() { Price = 50 };

            var result = product.GetPrice(customer.Object);
            Assert.Equal(40, result);
        }
    }
}
