using ScreenSound.TimeSpanValidation;

namespace ScreenSound.Music
{
    public struct AlbumDuration
    {
        public TimeSpan Value { get; } = TimeSpan.FromSeconds(0);

        public AlbumDuration(int setTime, int maxLength)
        {
            this.Value = TimeSpanValidator.ValidateAlbumTimeSpan(new TimeSpan(0, 0, setTime), maxLength);
        }
    }
}
