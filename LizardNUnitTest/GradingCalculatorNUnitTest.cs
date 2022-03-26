using Lizard;
using NUnit.Framework;

namespace LizardXUnitTest
{
    [TestFixture]
    public class GradingCalculatorNUnitTest
    {
        private GradingCalculator gcalc = null!;

        [SetUp]
        public void Setup()
        {
            gcalc = new GradingCalculator();
        }

        [Test]
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
                Assert.That(result, Is.EqualTo(resultList[i]));
            }
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GetGrade_InputScoreAndAttendancePercentage_ReturnsBadGrade(int score, int attendance)
        {
            gcalc.Score = score;
            gcalc.AttendancePercentage = attendance;
            string result = gcalc.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_AllGradeScenario_GradeOutput(int score, int attendance)
        {
            gcalc.Score = score;
            gcalc.AttendancePercentage = attendance;
            return gcalc.GetGrade();
        }
    }
}
