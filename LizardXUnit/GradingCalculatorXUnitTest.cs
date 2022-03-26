using Lizard;
using Xunit;

namespace LizardXUnitTest
{
    public class GradingCalculatorXUnitTest
    {
        private readonly GradingCalculator gcalc = null!;

        public GradingCalculatorXUnitTest()
        {
            gcalc = new GradingCalculator();
        }

        [Fact]
        public void GetGrade_InputScoreAndAttendancePercentage_ReturnsGoodGrades()
        {
            var dataList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(95, 90),
                new Tuple<int, int>(85, 90),
                new Tuple<int, int>(65, 90),
                new Tuple<int, int>(95, 65)
            };

            var resultList = new List<string>
            {
                "A",
                "B",
                "C",
                "B",
            };

            for (int i = 0; i < dataList.Count; i++)
            {
                gcalc.Score = dataList[i].Item1;
                gcalc.AttendancePercentage = dataList[i].Item2;
                string result = gcalc.GetGrade();
                Assert.Equal(resultList[i], result);
            }
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGrade_InputScoreAndAttendancePercentage_ReturnsBadGrade(int score, int attendance)
        {
            gcalc.Score = score;
            gcalc.AttendancePercentage = attendance;
            string result = gcalc.GetGrade();
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_AllGradeScenario_GradeOutput(int score, int attendance, string expectedScore)
        {
            gcalc.Score = score;
            gcalc.AttendancePercentage = attendance;
            string x = gcalc.GetGrade();
            Assert.Equal(expectedScore, x);
        }
    }
}
