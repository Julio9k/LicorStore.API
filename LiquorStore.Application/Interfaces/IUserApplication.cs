using System.Threading.Tasks;
using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;

namespace LiquorStore.Application.Interfaces;

public interface IUserApplication
{
    Task<Response<int>> AddClientAsync(RegisterRequest request);
}