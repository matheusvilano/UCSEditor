namespace UCSEditor.Extensions
{
    internal static class StringArrayExtensions
    {
        public static int GetLastIndex(this string[] str)
        {
            return str.Length - 1;
        }

        public static string GetLastObject(this string[] str)
        {
            return str[str.Length - 1];
        }
    }
}
