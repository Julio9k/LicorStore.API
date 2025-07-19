using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Context;
using LiquorStore.Infrastructure.Entities;
using LiquorStore.Infrastructure.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.Infrastructure.Repositories.Implementations;

public class ProductRepository : BaseRepository<Product, ProductDto>, IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public  async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)            
            .Include(p => p.ProductType)                
            .FirstOrDefaultAsync(r => r.Id == id);

        return product?.Adapt<ProductDto>();
    }

}
