using ScreenSound.StringValidation;

namespace ScreenSound.DataObjects.Name
{
    public class PersonName
    {
        public string Value { get; } = "Undefined";
        public static readonly PersonName Empty = new PersonName("Undefined", "Undefined".Length); 

        public PersonName(string setName, int maxLength)
        {
            Value = StringValidator.ValidateTrimmedString(setName, maxLength);
        }
    }
}
