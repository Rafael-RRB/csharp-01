namespace ScreenSound.RandomTimeSpan
{
    public static class RandomTimeSpan
    {
        private static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());

        public static TimeSpan Generate(TimeSpan max)
        {
            // this one took a little bit of thought. First I considered generating each component (hours, minutes, seconds) separately,
            // but that didn't seem to work, then I thought of using the ticks, but it wouldn't work with random, so finally I settled on total seconds.
            int maxTotalSeconds = (int)max.TotalSeconds;
            int randomTotalSeconds = random.Value!.Next(1, maxTotalSeconds + 1);

            return TimeSpan.FromSeconds(randomTotalSeconds);
        }

        public static TimeSpan Generate()
        {
            // this one took a little bit of thought. First I considered generating each component (hours, minutes, seconds) separately,
            // but that didn't seem to work, then I thought of using the ticks, but it wouldn't work with random, so finally I settled on total seconds.
            int maxTotalSeconds = (int)(new TimeSpan(24, 0, 0).TotalSeconds);
            int randomTotalSeconds = random.Value!.Next(1, maxTotalSeconds + 1);

            return TimeSpan.FromSeconds(randomTotalSeconds);
        }
    }
}
