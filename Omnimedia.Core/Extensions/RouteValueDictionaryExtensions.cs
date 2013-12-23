using System.Web.Routing;

namespace Omnimedia.Core.Extensions
{
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Sets the value and returns the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static RouteValueDictionary SetValueAndReturn(this RouteValueDictionary dictionary, string key, object value)
        {
            dictionary.SetValue(key, value);
            return dictionary;
        }
    }
}