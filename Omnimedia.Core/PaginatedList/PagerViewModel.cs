using System.Web.Routing;

namespace Omnimedia.Core.PaginatedList
{
    public class PagerViewModel
    {
        public PagerViewModel(string action, string controller, PaginatedListMetrics metrics, RouteValueDictionary routeValues)
        {
            this.Action = action;
            this.Controller = controller;
            this.Metrics = metrics;
            this.RouteValues = routeValues;
        }

        public string Action { get; set; }
        public string Controller { get; set; }
        public PaginatedListMetrics Metrics { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}