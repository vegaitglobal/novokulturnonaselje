using Newtonsoft.Json;
using System;

namespace NKN.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes (at most one instance of) the <paramref name="removeString"/> string from the end of the <paramref name="source"/> string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="removeString">String to remove from the <paramref name="source"/>.</param>
        /// <param name="comparisonType">Determines how <paramref name="source"/> and <paramref name="removeString"/> strings are compared to each other.</param>
        /// <returns><paramref name="source"/> string without <paramref name="removeString"/> at the end.</returns>
        public static string RemoveSuffix(this string source, string removeString,
            StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            if (string.IsNullOrWhiteSpace(removeString)) return source;

            if (source.EndsWith(removeString, comparisonType))
                source = source.Remove(source.Length - removeString.Length);

            return source;
        }

        public static T TryToDeserializeJson<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                //ignore
            }

            return default(T);
        }
    }
}