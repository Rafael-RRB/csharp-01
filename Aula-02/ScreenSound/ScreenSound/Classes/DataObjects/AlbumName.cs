using ScreenSound.StringValidation;

namespace ScreenSound.Music
{
    public class AlbumName
    {
        public string Value { get; } = "Undefined";
        public static readonly AlbumName Empty = new AlbumName("Undefined", "Undefined".Length);

        public AlbumName(string setName, int maxLength)
        {
            this.Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
