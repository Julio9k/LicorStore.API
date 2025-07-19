using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquorStore.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleApplication _application;

    public RoleController(IRoleApplication application)
    {
        _application = application;
    }

    [Authorize(Policy = nameof(RoleCode.Admin))]
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _application.GetAllAsync());
}
