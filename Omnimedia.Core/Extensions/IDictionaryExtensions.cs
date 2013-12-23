using System.Collections.Generic;

namespace Omnimedia.Core.Extensions
{
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T GetValue<T>(this IDictionary<string, object> dictionary, string key)
        {
            return dictionary.ContainsKey(key) ?
                (T)dictionary[key] : default(T);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void SetValue(this IDictionary<string, object> dictionary, string key, object value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }
    }
}