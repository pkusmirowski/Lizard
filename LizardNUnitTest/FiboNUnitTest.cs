using Lizard;
using NUnit.Framework;

namespace LizardXUnitTest
{
    [TestFixture]
    public class FiboNUnitTest
    {
        private Fibo fibo = null!;

        [SetUp]
        public void SetUp()
        {
            fibo = new Fibo();
        }

        [Test]
        public void GetFiboSeries_Input1_ReturnFiboSerie()
        {
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();
            Assert.IsNotNull(result);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Does.Contain(0));
        }

        [Test]
        public void GetFiboSeries_Input6_ReturnFiboSerie()
        {
            var matchlist = new List<int>()
            {
                0,
                1,
                1,
                2,
                3,
                5
            };

            fibo.Range = 6;
            var result = fibo.GetFiboSeries();
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Does.Not.Contain(4));
            Assert.That(result, Is.EquivalentTo(matchlist));
        }
    }
}
