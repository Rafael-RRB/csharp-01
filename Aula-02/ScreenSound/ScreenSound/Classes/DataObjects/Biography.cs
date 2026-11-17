using ScreenSound.StringValidation;

namespace ScreenSound.DataObjects.Biography
{
    public class Biography
    {
        public string Value { get; } = "Undefined.";
        public static readonly Biography Empty = new Biography("Undefined.", "Undefined.".Length); 

        public Biography(string setBiography, int maxLength)
        {
            Value = StringValidator.ValidateTrimmedString(setBiography, maxLength);
        }
    }
}
