namespace Lizard
{
    public class Fibo
    {
        public int Range { get; set; }

        public Fibo()
        {
            Range = 5;
        }

        public List<int> GetFiboSeries()
        {
            List<int> series = new();
            int a = 0; int b = 1;
            if (Range == 1)
            {
                series.Add(a);
                return series;
            }
            series.Add(0);
            series.Add(1);
            for (int i = 2; i < Range; i++)
            {
                int c = a + b;
                series.Add(c);
                a = b;
                b = c;
            }
            return series;
        }
    }
}
