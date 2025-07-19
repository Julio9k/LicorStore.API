using LiquorStore.API.Pagination;
using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Dto;
using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;
using LiquorStore.Infrastructure.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Application.Implementations;

public class ProductApplication : IProductApplication
{
    private readonly IProductRepository _repository;

    public ProductApplication(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<int>> AddAsync(ProductRequest request)
    {
        var dto = request.Adapt<ProductDto>();
        var id = await _repository.AddAsync(dto);
        return new Response<int>(id);
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        //if (product == null)

        var success = await _repository.DeleteAsync(id);
        return new Response<bool>(success);
    }

    public async Task<Response<ProductResponse>> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        //if (product is null)
        //    throw new CustomExceptions.NotFoundException("Producto no encontrado");

        var result = product.Adapt<ProductResponse>();
        return new Response<ProductResponse>(result);
    }

    public async Task<Response<PaginatedResult<ProductResponse>>> GetPagedAsync(int page, int pageSize, string? filter = null)
    {
        var filterPagination = new PaginationFilter(page, pageSize, filter);

        var query = await _repository.GetQueryableAsync();
        if (!string.IsNullOrWhiteSpace(filterPagination.Filter))
            query = query.Where(r => r.Name.Contains(filterPagination.Filter));

        var total = await query.CountAsync();

        var products = await query
            .OrderBy(p => p.Name)
            .Skip((filterPagination.Page - 1) * filterPagination.PageSize)
            .Take(filterPagination.PageSize)
            .ProjectToType<ProductResponse>()
            .ToListAsync();

        var result = new PaginatedResult<ProductResponse>(products, total, filterPagination.Page, filterPagination.PageSize);
        return new Response<PaginatedResult<ProductResponse>>(result);
    }

    public async Task<Response<bool>> UpdateAsync(int id, ProductRequest request)
    {
        var dto = await _repository.GetByIdAsync(id);

        dto = request.Adapt<ProductDto>();
        dto.Id = id;
        var success = await _repository.UpdateAsync(dto);
        return new Response<bool>(success);
    }
}