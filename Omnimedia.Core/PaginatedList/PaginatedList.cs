using System;
using System.Collections.Generic;
using System.Linq;

namespace Omnimedia.Core.PaginatedList
{
    public class PaginatedList<T> : List<T>
    {
        private IQueryable<T> _dataSource;
        private PaginatedListSettings _listSettings;

        public PaginatedList(IQueryable<T> data)
        {
            _dataSource = data;
            _listSettings = new PaginatedListSettings();
            this.Initialize();
        }

        public PaginatedList(IQueryable<T> data, PaginatedListSettings settings)
        {
            _dataSource = data;
            _listSettings = settings;
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
                int totalPages = (int)Math.Ceiling(totalCount / (double)_listSettings.PageSize);
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

                this.AddRange(_dataSource.Skip((_listSettings.PageIndex - 1) * _listSettings.PageSize).Take(_listSettings.PageSize));
            }
        }

        public PaginatedListMetrics Metrics { get; private set; }
    }
}