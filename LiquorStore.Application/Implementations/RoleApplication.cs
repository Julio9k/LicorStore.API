using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Dto;
using LiquorStore.Common.Responses;
using Mapster;

namespace LiquorStore.Application.Implementations;

public class RoleApplication : IRoleApplication
{
    private readonly IRoleRepository _repository;

    public RoleApplication(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Response<List<RoleDto>>> GetAllAsync()
    {
        var roles = await _repository.GetAllByFilterAsync();
        var result = roles.Adapt<List<RoleDto>>();
        return new Response<List<RoleDto>>(result);
    }
}
