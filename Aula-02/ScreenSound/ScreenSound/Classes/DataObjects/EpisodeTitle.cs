using ScreenSound.StringValidation;

namespace ScreenSound.Podcast
{
    public class EpisodeTitle
    {
        public string Value { get; } = "Undefined";
        public static readonly EpisodeTitle Empty = new EpisodeTitle("Undefined");
        /// <summary>
        /// It seems, because of platforms rules, podcast names are somewhat limited. I've decided to set the maximum length to 200 characters.
        /// </summary>
        const int maxLength = 200;

        public EpisodeTitle(string setName)
        {
            this.Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
