using System.Globalization;
using System.Text;
using LiquorStore.Application.Interfaces;
using LiquorStore.Common;
using LiquorStore.Common.Dto;
using LiquorStore.Common.Enums;
using LiquorStore.Common.Request;
using LiquorStore.Common.Responses;
using LiquorStore.Infrastructure.Repositories.Interfaces;
using Mapster;

namespace LiquorStore.Application.Implementations;

public class UserApplication : IUserApplication
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;

    public UserApplication(IRoleRepository roleRepository, IUserRepository userRepository,
        ICustomerRepository customerRepository)
    {
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }
    public async Task<Response<int>> AddClientAsync(RegisterRequest request)
    {
        var role = await _roleRepository.GetByFilterAsync(x => x.Code == RoleCode.Customer);
        var user = request.Adapt<UserDto>();
        user.RoleId = role.Id;
        user.RoleCode = role.Code;
        return await AddUserAsync(user, request.Password);
    }

    public async Task<Response<int>> AddUserAsync(UserDto user, string password)
    {
        var userExists = await _userRepository.GetByFilterAsync(x => x.Email == user.Email);
        if (userExists != null)
            throw new CustomExceptions.BusinessException(new() { { nameof(UserDto.Email), "El usuario ya está registrado" } });

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        user.CreatedAt = DateTime.UtcNow;
        user.Username = await GenerateUniqueUsernameAsync(user.Name, user.LastName);
        var id = await _userRepository.AddAsync(user);

        switch (user.RoleCode)
        {
            case RoleCode.Admin:
                break;

            case RoleCode.Customer:
                await _customerRepository.AddAsync(new CustomerDto { Id = id, });
                break;
        }

        return new Response<int>(id);
    }

    private async Task<string> GenerateUniqueUsernameAsync(string name, string lastname)
    {
        var username = $"{CleanName(name)}{CleanName(lastname)}";
        var exists = await _userRepository.ExistsAsync(u => u.Username == username);
        if (!exists)
            return username;

        var counter = await _userRepository.CountByFilterAsync(u => u.Username.StartsWith(username));
        username = $"{username}{counter + 1}";
        return username;
    }

    private string CleanName(string name)
    {
        return string.Concat(name.Normalize(NormalizationForm.FormD)
            .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark && char.IsLetter(c)))
            .ToLowerInvariant();
    }
}
