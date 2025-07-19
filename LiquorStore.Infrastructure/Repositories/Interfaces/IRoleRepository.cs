using LiquorStore.Common.Dto;
using LiquorStore.Infrastructure.Entities;
using LiquorStore.Infrastructure.Repositories.Interfaces;

namespace LiquorStore.Application.Interfaces;

public interface IRoleRepository : IBaseRepository<Role,RoleDto>
{
}
