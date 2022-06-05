using System;
using System.Collections.Generic;

namespace YannikG.PageableData
{
    public class DataPage<T> : IDataPage<T>
    {
        private ICollection<T> _content;
        private long _count;

        private IPageable _pageable;

        public DataPage(ICollection<T> content, long count, IPageable pageable)
        {
            this._content = content;
            this._count = count;
            this._pageable = pageable;
        }

        public long TotalItems => this._count;
        public int TotalItemsOnPage => this._content.Count;

        public ICollection<T> Content => this._content;

        public int TotalPages => Convert.ToInt32(Math.Ceiling((decimal)this._count / (decimal)this._pageable.PageSize));

        public int PageSize => this._pageable.PageSize;

        public int CurrentPage => this._pageable.CurrentPage;

        public bool IsSorted => this._pageable.IsSorted;

        public string SortByField => this._pageable.SortByField;
        public SortDirectionEnum SortDirection => this._pageable.SortDirection;
    }
}

