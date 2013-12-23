using System;

namespace Omnimedia.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats a nullable DateTime object.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string FormatNullable(this DateTime? date, string format = "yyyy-MM-dd")
        {
            return date != null ?
                DateTime.Parse(date.ToString()).ToString(format) : String.Empty;
        }
    }
}