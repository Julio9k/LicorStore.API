using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Entities;
using LiquorStore.Infrastructure.Repositories.Implementations;

namespace LiquorStore.Infrastructure.Repositories.Interfaces;

public interface IProductRepository : IBaseRepository<Product, ProductDto>
{
}