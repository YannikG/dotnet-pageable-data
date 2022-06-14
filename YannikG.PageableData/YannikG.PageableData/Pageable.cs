namespace YannikG.PageableData
{
    public class Pageable : IPageable
    {
        private int _pageSize = 20;
        private int _currentPage = 0;
        private string _searchByField = null;

        public virtual int PageSize
        {
            get => this._pageSize;
            set => _pageSize = value;
        }
        public virtual int CurrentPage
        {
            get => this._currentPage;
            set => this._currentPage = value;
        }

        public virtual int Skip { get => this._currentPage * this._pageSize; }
        public virtual int Take { get => this._pageSize; }

        public virtual bool IsSorted { get; set; }
        public virtual string SortByField
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

        public virtual SortDirectionEnum SortDirection { get; set; } = SortDirectionEnum.Ascending;
    }
}

