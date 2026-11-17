namespace ScreenSound.TimeSpanValidation
{
    public static class TimeSpanValidator
    {
        public static TimeSpan ValidateSongTimeSpan(TimeSpan timeSpan, TimeSpan maxDuration)
        {
            if (timeSpan <= TimeSpan.Zero)
            {
                throw new ArgumentException($"Parameter \"{timeSpan}\" cannot be lower or equal to 0.", timeSpan.ToString());
            }
            if (timeSpan > maxDuration)
            {
                throw new ArgumentException($"Parameter \"{timeSpan}\" cannot be longer than the passed maximum duration of \"{maxDuration}\"", timeSpan.ToString());
            }

            return timeSpan;
        }

        public static TimeSpan ValidateAlbumTimeSpan(TimeSpan timeSpan, int maxLength)
        {
            if (timeSpan.TotalSeconds < 0)
            {
                throw new ArgumentException($"Parameter \"{timeSpan}\" cannot be lower than 0.", timeSpan.ToString());
            }
            if (timeSpan.TotalSeconds > maxLength)
            {
                throw new ArgumentException($"Parameter \"{timeSpan}\" cannot be longer than the passed maximum duration of \"{maxLength}\"", timeSpan.ToString());
            }

            return timeSpan;
        }

        public static TimeSpan ValidateEpisodeTimeSpan(TimeSpan timeSpan, TimeSpan maxDuration)
        {
            if (timeSpan <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException($"TimeSpan of ({timeSpan}) cannot be less than or equal to zero.");
            }
            else if (timeSpan > maxDuration)
            {
                throw new ArgumentOutOfRangeException($"TimeSpan of ({timeSpan}) cannot be longer than the specified max duration of ({maxDuration}).");
            }

            return timeSpan;
        }
    }
}
