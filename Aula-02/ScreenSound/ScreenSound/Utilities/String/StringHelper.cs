namespace ScreenSound.Utilities.String
{
    public static class StringUtility
    {
        public static string ShortenString(string input, int maxLength)
        {
            string suffix = "...";
            if (input.Length <= maxLength || input.Length <= suffix.Length)
            {
                return input;
            }
            else if (input.Length > maxLength && input.Length > suffix.Length)
            {
                return input.Substring(0, maxLength - suffix.Length) + suffix;
            }
            else
            {
                throw new ArgumentException($"Invalid logic. Current parameters: string input \"{input}\" length \"{input.Length}\", int maxLength \"{maxLength}\", string suffix \"{suffix}\" length \"{suffix.Length}\".");
            }
        }
    }
}
