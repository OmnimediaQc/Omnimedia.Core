namespace Omnimedia.Core.PaginatedList
{
    public class PaginatedListSettings
    {
        private const int DefaultPageIndex = 1;
        private const int DefaultPageSize = 25;
        private const int DefaultDisplayPages = 10;

        public PaginatedListSettings() : this(DefaultPageIndex, DefaultPageSize, DefaultDisplayPages) { }

        public PaginatedListSettings(int pageIndex) : this(pageIndex, DefaultPageSize, DefaultDisplayPages) { }

        public PaginatedListSettings(int pageIndex, int pageSize, int displayPages)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.DisplayPages = displayPages;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int DisplayPages { get; set; }
    }
}