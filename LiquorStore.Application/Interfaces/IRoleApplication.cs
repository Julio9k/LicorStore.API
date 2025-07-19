using LiquorStore.API.Pagination;
using LiquorStore.Common.Dto;
using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;

namespace LiquorStore.Application.Interfaces;

public interface IRoleApplication
{
    Task<Response<List<RoleDto>>> GetAllAsync();
}
