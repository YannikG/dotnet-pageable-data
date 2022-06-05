using System;
using System.Collections.Generic;

namespace YannikG.PageableData
{
	public interface IDataPage<T>
	{
        // Content
        long TotalItems { get; }
        int TotalItemsOnPage { get; }
        ICollection<T> Content { get; }

        // Pages
        int TotalPages { get; }
        int PageSize { get; }
        int CurrentPage { get; }

        // Sorting
        bool IsSorted { get; }
        string SortByField { get; }
        SortDirectionEnum SortDirection { get; }
    }
}

