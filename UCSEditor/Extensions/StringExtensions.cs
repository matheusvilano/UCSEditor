namespace UCSEditor.Extensions
{
    /// <summary>
    /// Extensions for the `String` class.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Returns a version of the string that contains only letters.
        /// </summary>
        /// <param name="str">The caller object, which is an instance of the `string` class.</param>
        /// <returns>The string, but containing letters only.</returns>
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

        /// <summary>
        /// Returns a version of the string that contains only letters and digits.
        /// </summary>
        /// <param name="str">The caller object, which is an instance of the `string` class.</param>
        /// <returns>The string, but containing letters and digits only.</returns>
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

        /// <summary>
        /// Returns a version of the string that does not contain any whitespace. A replacement for whitespace can be specified.
        /// </summary>
        /// <param name="str">The caller object, which is an instance of the `string` class.</param>
        /// <param name="replacement">The character to replace any whitespace. By default, whitespace characters are replaced by underscores.</param>
        /// <returns>The string, but with any whitespaced replaced by an underscore (or the specified replacement).</returns>
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
