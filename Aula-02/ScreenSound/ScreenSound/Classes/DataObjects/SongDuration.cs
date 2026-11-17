using ScreenSound.TimeSpanValidation;

namespace ScreenSound.Music
{
    public struct SongDuration
    {
        public TimeSpan Value { get; } = TimeSpan.FromSeconds(0);
        private readonly TimeSpan maxDuration = new TimeSpan(1, 0, 0); // 1 hour

        public SongDuration(TimeSpan setTime)
        {
            this.Value = TimeSpanValidator.ValidateSongTimeSpan(setTime, maxDuration);
        }
    }
}
