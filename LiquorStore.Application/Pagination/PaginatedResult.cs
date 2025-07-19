namespace LiquorStore.API.Pagination;

public class PaginatedResult<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PaginatedResult(List<T> items, int total, int page, int pageSize)
    {
        Items = items;
        TotalCount = total;
        Page = page;
        PageSize = pageSize;
    }
}