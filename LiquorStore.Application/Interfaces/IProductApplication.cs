using LiquorStore.API.Pagination;
using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;

namespace LiquorStore.Application.Interfaces;

public interface IProductApplication
{
    Task<Response<PaginatedResult<ProductResponse>>> GetPagedAsync(int page, int pageSize, string? filter = null);
    Task<Response<ProductResponse>> GetByIdAsync(int id);
    Task<Response<int>> AddAsync(ProductRequest request);
    Task<Response<bool>> UpdateAsync(int id, ProductRequest request);
    Task<Response<bool>> DeleteAsync(int id);
}