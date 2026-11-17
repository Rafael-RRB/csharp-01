using ScreenSound.TimeSpanValidation;

namespace ScreenSound.Podcast
{
    public struct EpisodeDuration
    {
        public TimeSpan Value { get; } = TimeSpan.FromSeconds(0);
        private readonly TimeSpan maxDuration = new TimeSpan(24, 0, 0); // 24 hours in seconds

        public EpisodeDuration(TimeSpan setTime)
        {
            this.Value = TimeSpanValidator.ValidateEpisodeTimeSpan(setTime, maxDuration);
        }
    }
}
