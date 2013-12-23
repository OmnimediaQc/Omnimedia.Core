namespace Omnimedia.Core.Breadcrumb
{
    public class BreadcrumbItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BreadcrumbItem"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="url">The URL.</param>
        public BreadcrumbItem(string label, string url)
        {
            this.Label = label;
            this.Url = url;
        }

        public string Label { get; set; }
        public string Url { get; set; }
    }
}