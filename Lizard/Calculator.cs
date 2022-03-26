namespace Lizard
{
    public static class Calculator
    {
        private static readonly List<int> NumberRange = new();

        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public static double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }

        public static bool IsOddNumber(int a)
        {
            return a % 2 != 0;
        }

        public static List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for (int i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    NumberRange.Add(i);
                }
            }

            return NumberRange;
        }
    }
}