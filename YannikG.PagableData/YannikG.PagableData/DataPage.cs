using System;
using System.Collections.Generic;

namespace YannikG.PagableData
{
    public class DataPage<T> : IDataPage<T>
    {
        private ICollection<T> _content;
        private int _count;

        private IPageable _pageable;

        public DataPage(ICollection<T> content, int count, IPageable pageable)
        {
            this._content = content;
            this._count = count;
            this._pageable = pageable;
        }

        public int TotalItems => this._count;
        public int TotalItemsOnPage => this._content.Count;

        public ICollection<T> Content => this._content;

        public int TotalPages => Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(this._count / this._pageable.PageSize)));

        public int PageSize => this._pageable.PageSize;

        public int CurrentPage => this._pageable.CurrentPage;

        public bool IsSorted => this._pageable.IsSorted;

        public string SortByField => this._pageable.SortByField;
        public SortDirectionEnum SortDirection => this._pageable.SortDirection;
    }
}

