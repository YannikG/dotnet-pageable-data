using System;
namespace YannikG.PagableData
{
    public class Pageable : IPageable
    {
        private int _pageSize = 20;
        private int _currentPage = 0;
        private string _searchByField = null;

        public int PageSize
        {
            get => this._pageSize;
            set => _pageSize = value;
        }
        public int CurrentPage
        {
            get => this._currentPage;
            set => this._currentPage = value;
        }

        public int Skip { get => this._currentPage * this._pageSize; }
        public int Take { get => this._pageSize; }

        public bool IsSorted { get; set; }
        public string SortByField
        {
            get
            {
                return this._searchByField;
            }
            set
            {
                if (value != null)
                {
                    this._searchByField = value;
                    this.IsSorted = true;
                }
            }
        }

        public SortDirectionEnum SortDirection { get; set; } = SortDirectionEnum.Ascending;
    }
}

