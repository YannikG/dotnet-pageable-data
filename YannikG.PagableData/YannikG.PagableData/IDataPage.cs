using System;
using System.Collections.Generic;

namespace YannikG.PagableData
{
	public interface IDataPage<T>
	{
        // Content
        int TotalItems { get; }
        int TotalItemsOnPage { get; }
        ICollection<T> Content { get; }

        // Pages
        int TotalPages { get; }
        int PageSize { get; }
        int CurrentPage { get; }

        // Sorting
        bool IsSorted { get; }
        string SortByField { get; }
        SortDirection SortDirection { get; }
    }
}

