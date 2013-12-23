using System.Collections.Specialized;
using System.Web.Routing;

namespace Omnimedia.Core.Extensions
{
    public static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Converts a NameValueCollection to a RouteValueDictionary.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static RouteValueDictionary ToRouteValues(this NameValueCollection collection)
        {
            if (collection == null)
                return null;

            var dictionary = new RouteValueDictionary();
            foreach (string key in collection.Keys)
            {
                dictionary.SetValue(key, collection[key]);
            }

            return dictionary;
        }
    }
}