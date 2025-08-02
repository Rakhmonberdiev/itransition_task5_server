namespace itransition_task5_server.Helpers
{
    public static class StochasticHelper
    {
        public static int GetStochasticInt(int seed, double average)
        {
            if (average <= 0) return 0;

            var rand = new Random(seed);
            int floor = (int)Math.Floor(average);
            double fraction = average - floor;
            return floor + (rand.NextDouble() < fraction ? 1 : 0);
        }
    }
}
