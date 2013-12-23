using System.Text.RegularExpressions;

namespace Omnimedia.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Shortens a string to a specified length.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Shorten(this string input, int length)
        {
            if (input == null || input.Length < length || input.IndexOf(" ", length) == -1)
                return input;

            string output = input.Substring(0, input.IndexOf(" ", length));
            return string.Format("{0}...", output);
        }

        /// <summary>
        /// Strips the HTML tags from a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static string StripHtmlTags(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            Regex regExObj = new Regex("<(.|\\n)+?>");
            return regExObj.Replace(input, "");
        }
    }
}