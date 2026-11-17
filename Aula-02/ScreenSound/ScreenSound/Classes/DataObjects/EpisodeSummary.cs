using ScreenSound.StringValidation;

namespace ScreenSound.Podcast
{
    public class EpisodeSummary
    {
        public string Value { get; } = "Undefined.";
        public static readonly EpisodeSummary Empty = new EpisodeSummary("Undefined.");
        /// <summary>
        /// Half of the max biography length of a Podcast Host.
        /// </summary>
        const int maxLength = 2500;

        public EpisodeSummary(string setBiography)
        {
            Value = StringValidator.ValidateTrimmedString(setBiography, maxLength);
        }
    }
}
