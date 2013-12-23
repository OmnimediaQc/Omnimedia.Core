using System.Collections.Generic;

namespace Omnimedia.Core.Breadcrumb
{
    public class Breadcrumb
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Breadcrumb"/> class.
        /// </summary>
        public Breadcrumb()
        {
            this.Items = new List<BreadcrumbItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Breadcrumb"/> class.
        /// </summary>
        /// <param name="items">The items.</param>
        public Breadcrumb(List<BreadcrumbItem> items)
        {
            this.Items = items;
        }

        /// <summary>
        /// Adds the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="url">The URL.</param>
        public void Add(string label, string url)
        {
            BreadcrumbItem item = new BreadcrumbItem(label, url);
            this.Add(item);
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(BreadcrumbItem item)
        {
            this.Items.Add(item);
        }

        public List<BreadcrumbItem> Items { get; set; }
    }
}