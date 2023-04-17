using System.Globalization;

namespace PizzeriaDemoAPI.Helpers
{
    public static class MyExtensionMethods
    {
        // Join the elements in a collection with a default dilimit separator
        public static string ToDelimitedString<T>(this IEnumerable<T> source)
        {
            return source.ToDelimitedString(x => x.ToString(),
                CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }

        // Join the elements in a collection with a specific string converter function and a default dilimit separator
        public static string ToDelimitedString<T>(this IEnumerable<T> source, Func<T, string> converter)
        {
            return source.ToDelimitedString(converter,
                CultureInfo.CurrentCulture.TextInfo.ListSeparator);
        }

        // Join the elements in a collection with a specific separator
        public static string ToDelimitedString<T>(this IEnumerable<T> source, string separator)
        {
            return source.ToDelimitedString(x => x.ToString(), separator);
        }

        // Join the elements in a collection with a specific string converter and a specific separator
        public static string ToDelimitedString<T>(this IEnumerable<T> source, Func<T, string> converter, string separator)
        {
            return string.Join(separator, source.Select(converter).ToArray());
        }
    }
}