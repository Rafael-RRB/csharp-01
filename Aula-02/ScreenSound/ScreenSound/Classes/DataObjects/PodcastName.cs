using ScreenSound.StringValidation;

namespace ScreenSound.DataObjects.Name
{
    public class PodcastName
    {
        public string Value { get; } = "Undefined";
        public static readonly PodcastName Empty = new PodcastName("Undefined");
        /// <summary>
        /// It seems, because of platforms rules, podcast names are somewhat limited. I've decided to set the maximum length to 200 characters.
        /// </summary>
        private const int maxLength = 200;

        public PodcastName(string setName)
        {
            Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
