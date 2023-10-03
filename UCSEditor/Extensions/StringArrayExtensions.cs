namespace UCSEditor.Extensions
{
    /// <summary>
    /// Extensions for the string[] type.
    /// </summary>
    internal static class StringArrayExtensions
    {
        /// <summary>
        /// Gets the last valid index in the string array.
        /// </summary>
        /// <param name="str">The caller object, which is an instance of the `string` class.</param>
        /// <returns>The last valid index.</returns>
        public static int GetLastIndex(this string[] str)
        {
            return str.Length - 1;
        }

        /// <summary>
        /// Gets the last valid object in the string array.
        /// </summary>
        /// <param name="str">The caller object, which is an instance of the `string` class.</param>
        /// <returns>The last valid object.</returns>
        public static string GetLastObject(this string[] str)
        {
            return str[str.Length - 1];
        }
    }
}
