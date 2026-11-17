using ScreenSound.IntValidation;

namespace ScreenSound.Podcast
{
    public struct EpisodeNumber
    {
        public int Value { get; } = 1;
        const int minimumEpisodeNumber = 1;
        const int maximumEpisodeNumber = 99999;

        public EpisodeNumber(int setEpisodeNumber)
        {
            Value = IntValidator.ValidateIntRange(setEpisodeNumber, minimumEpisodeNumber, maximumEpisodeNumber);
        }
    }
}
