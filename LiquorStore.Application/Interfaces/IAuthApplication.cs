using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;

namespace LiquorStore.Application.Interfaces;

public interface IAuthApplication
{
    Task<Response<LoginResponse>> LoginAsync(LoginRequest request);
}