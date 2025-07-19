using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Context;
using LiquorStore.Infrastructure.Entities;

namespace LiquorStore.Infrastructure.Repositories.Implementations;

public class RoleRepository : BaseRepository<Role, RoleDto>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}
