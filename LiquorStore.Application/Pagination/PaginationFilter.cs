namespace LiquorStore.API.Pagination;

public class PaginationFilter
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? Filter { get; set; }

    public PaginationFilter(int page, int pageSize, string? filter = null)
    {
        Page = page;
        PageSize = pageSize;
        Filter = filter;
    }
}