namespace Omnimedia.Core.PaginatedList
{
    public class PaginatedListMetrics
    {
        public PaginatedListMetrics() { }

        public PaginatedListMetrics(
            int pageIndex,
            int pageSize,
            int totalCount,
            int totalPages,
            int pagesToShow,
            int firstPageIndex,
            int lastPageIndex)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPages = totalPages;
            this.PagesToShow = pagesToShow;
            this.FirstPageIndex = firstPageIndex;
            this.LastPageIndex = lastPageIndex;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PagesToShow { get; set; }
        public int FirstPageIndex { get; set; }
        public int LastPageIndex { get; set; }

        /// <summary>
        /// Indicates whether the previous button is enabled.
        /// </summary>
        public bool IsPreviousEnabled
        {
            get { return this.PageIndex > 1; }
        }

        /// <summary>
        /// Indicates whether the next button is enabled.
        /// </summary>
        public bool IsNextEnabled
        {
            get { return this.PageIndex < this.TotalPages; }
        }

        /// <summary>
        /// Gets the index of the previous page.
        /// </summary>
        public int PreviousPageIndex
        {
            get { return this.PageIndex - (this.IsPreviousEnabled ? 1 : 0); }
        }

        /// <summary>
        /// Gets the index of the next page.
        /// </summary>
        public int NextPageIndex
        {
            get { return this.PageIndex + (this.IsNextEnabled ? 1 : 0); }
        }

        /// <summary>
        /// Gets the record count (Ex: showing results 1-20).
        /// </summary>
        public int RecordCountFrom
        {
            get { return (this.PageSize * (this.PageIndex - 1)) + 1; }
        }

        /// <summary>
        /// Gets the record count (Ex: showing results 1-20).
        /// </summary>
        public int RecordCountTo
        {
            get { return (this.PageSize * this.PageIndex) > this.TotalCount ? this.TotalCount : (this.PageSize * this.PageIndex); }
        }
    }
}