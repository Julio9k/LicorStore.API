using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Entities;

namespace LiquorStore.Infrastructure.Repositories.Interfaces;

public interface ICustomerRepository : IBaseRepository<Customer, CustomerDto>
{
}
