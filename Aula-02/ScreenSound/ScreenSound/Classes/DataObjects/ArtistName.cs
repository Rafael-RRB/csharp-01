using ScreenSound.StringValidation;

namespace ScreenSound.Music
{
    public class ArtistName
    {
        public string Value { get; } = "Undefined";
        public static readonly ArtistName Empty = new ArtistName("Undefined", "Undefined".Length);

        public ArtistName(string setName, int maxLength)
        {
            this.Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
