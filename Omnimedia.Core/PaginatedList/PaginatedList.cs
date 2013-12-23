using System;
using System.Collections.Generic;
using System.Linq;

namespace Omnimedia.Core.PaginatedList
{
    public class PaginatedList<T> : List<T>
    {
        private IQueryable<T> _dataSource;
        private PaginatedListSettings _listSettings;

        public PaginatedList(IQueryable<T> data) : this(data, null) { }
        public PaginatedList(IQueryable<T> data, PaginatedListSettings settings)
        {
            _dataSource = data;
            _listSettings = settings ?? new PaginatedListSettings();
            this.Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            if (_dataSource != null)
            {
                int totalCount = _dataSource.Count();
                int totalPages = Convert.ToInt32(Math.Ceiling(totalCount / Convert.ToDouble(_listSettings.PageSize)));
                int pagesToShow = totalPages >= _listSettings.DisplayPages ? _listSettings.DisplayPages : totalPages;
                int firstPageIndex = _listSettings.PageIndex - (pagesToShow / 2) > 0 ? _listSettings.PageIndex - (pagesToShow / 2) : 1;
                int lastPageIndex = firstPageIndex + (pagesToShow - 1) > totalPages ? totalPages : firstPageIndex + (pagesToShow - 1);

                if (lastPageIndex == totalPages)
                    firstPageIndex = totalPages + 1 - pagesToShow;

                this.Metrics = new PaginatedListMetrics(
                    _listSettings.PageIndex,
                    _listSettings.PageSize,
                    totalCount,
                    totalPages,
                    pagesToShow,
                    firstPageIndex,
                    lastPageIndex
                );

                int skip = _listSettings.PageSize * (_listSettings.PageIndex - 1);
                this.AddRange(_dataSource.Skip(skip).Take(_listSettings.PageSize));
            }
        }

        public PaginatedListMetrics Metrics { get; private set; }
    }
}