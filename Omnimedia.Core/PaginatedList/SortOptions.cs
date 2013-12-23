using System.Web;
using System.Web.Routing;
using Omnimedia.Core.Extensions;

namespace Omnimedia.Core.PaginatedList
{
    public class SortOptions
    {
        public SortOptions()
        {
        }

        public SortOptions(string column, string order)
        {
            this.Column = column;
            this.Order = order;
        }

        public string Column { get; set; }
        public string Order { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(this.Column) &&
                !string.IsNullOrEmpty(this.Order));
            }
        }

        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="keepCurrentValues">if set to <c>true</c> [keep current values].</param>
        /// <returns></returns>
        public RouteValueDictionary GetRouteValues(string column, bool keepCurrentValues = false)
        {
            bool isSameColumn = this.Column == column;
            string routeValueColumn = column;
            string routeValueOrder = GetOrder(isSameColumn);
            var routeValues = new RouteValueDictionary(new
            {
                column = routeValueColumn,
                order = routeValueOrder
            });

            if (keepCurrentValues)
            {
                RouteValueDictionary oldRouteValues = HttpContext.Current.Request.QueryString.ToRouteValues();

                foreach (var item in oldRouteValues)
                {
                    if (!routeValues.ContainsKey(item.Key))
                        routeValues[item.Key] = item.Value;
                }
            }

            return routeValues;
        }

        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public string GetCssClass(string column)
        {
            return this.Column == column ? this.Order : string.Empty;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="isSameColumn">if set to <c>true</c> [is same column].</param>
        /// <returns></returns>
        private string GetOrder(bool isSameColumn)
        {
            return isSameColumn ? this.Order == "asc" ? "desc" : "asc" : "asc";
        }
    }
}