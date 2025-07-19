using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Context;
using LiquorStore.Infrastructure.Entities;
using LiquorStore.Infrastructure.Repositories.Interfaces;

namespace LiquorStore.Infrastructure.Repositories.Implementations;

public class CustomerRepository : BaseRepository<Customer, CustomerDto>, ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}