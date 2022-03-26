using Lizard;
using Xunit;

namespace LizardXUnitTest
{
    public class FiboXUnitTest
    {
        private readonly Fibo fibo = null!;

        public FiboXUnitTest()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void GetFiboSeries_Input1_ReturnFiboSerie()
        {
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();
            Assert.NotNull(result);
            Assert.Equal(result.OrderBy(u => u), result);
            Assert.Contains(0, result);
        }

        [Fact]
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
            Assert.Contains(3, result);
            Assert.Equal(6, result.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equal(matchlist, result);
        }
    }
}
