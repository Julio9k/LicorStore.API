using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquorStore.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthApplication _authService;
    private readonly IUserApplication _applicationUser;

    public AuthController(IAuthApplication authService, IUserApplication applicationUser)
    {
        _authService = authService;
        _applicationUser = applicationUser;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
        => Ok(await _authService.LoginAsync(request));

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
       => Ok(await _applicationUser.AddClientAsync(request));
}
