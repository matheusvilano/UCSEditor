namespace UCSEditor.Extensions
{
    internal static class StringExtensions
    {
        public static string KeepOnlyLetters(this string chars)
        {
            foreach (char character in chars)
            {
                if (!char.IsLetter(character))
                {
                    chars.Replace($"{character}", "");
                }
            }
            return chars;
        }

        public static string KeepOnlyLettersAndDigits(this string chars)
        {
            foreach (char character in chars)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    chars.Replace($"{character}", "");
                }
            }
            return chars;
        }

        public static string ReplaceWhitespace(this string chars, in char replacement = '_')
        {
            foreach (char character in chars)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    chars.Replace(character, replacement);
                }
            }
            return chars;
        }
    }
}
