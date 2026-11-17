namespace ScreenSound.IntValidation
{
    public static class IntValidator
    {
        public static int ValidateIntRange(int value, int minValue, int maxValue)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException($"Value \"{value}\" is out of range ({minValue} to {maxValue}).");
            }
            return value;
        }
    }
}
