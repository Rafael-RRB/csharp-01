using ScreenSound.StringValidation;

namespace ScreenSound.Music
{
    public class SongTitle
    {
        public string Value { get; } = "Undefined";
        public static readonly SongTitle Empty = new SongTitle("Undefined", "Undefined".Length);

        public SongTitle(string setName, int maxLength)
        {
            this.Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
