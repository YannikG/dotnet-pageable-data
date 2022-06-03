using System;
namespace YannikG.PagableData
{
	public interface IPageable
	{
        // Pages
        int PageSize { get; set; }
        int CurrentPage { get; set; }

        // Skip / Take
        int Skip { get; }
        int Take { get; }

        // Sorting
        bool IsSorted { get; set; }
        string? SortByField { get; set; }
        SortDirectionEnum SortDirection { get; set; }
    }
}

