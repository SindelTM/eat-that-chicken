namespace EatThatChicken.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfStringIsNullOrEmpty(string text, string message = "String can not be null or empty!")
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(message);
            }
        }

        public static void CheckIfStringLengthIsValid(string text, int max, int min = 0, string message = "Invalid string length!")
        {
            if (text.Length < min || max < text.Length)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void CheckIsNull<T>(T value, string message = "Argument can not be null!")
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
