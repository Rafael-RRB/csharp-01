namespace ScreenSound.StringValidation
{
    public static class StringValidator
    {
        // Validates a string without modifying it
        public static string ValidateString(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"string \"{value}\" cannot be null, empty, or white space.", value);
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"string \"{value}\" is too long.", value);
            }

            return value;
        }

        // Validates a string after trimming it, better for UX?
        public static string ValidateTrimmedString(string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"string \"{value}\" cannot be null, empty, or white space.", value);
            }

            string trimmedValue = value.Trim();

            if (trimmedValue.Length > maxLength)
            {
                throw new ArgumentException($"string \"{value}\" is too long.", value);
            }

            return trimmedValue;
        }
    }
}
