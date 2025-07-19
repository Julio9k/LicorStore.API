using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LiquorStore.Application.Interfaces;
using LiquorStore.Common.Enums;
using LiquorStore.Common.Request;

namespace LiquorStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductApplication _application;

    public ProductsController(IProductApplication application)
    {
        _application = application;
    }

    [AllowAnonymous]
    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? filter = null)
        => Ok(await _application.GetPagedAsync(page, pageSize, filter));

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _application.GetByIdAsync(id));

    [Authorize(Policy = nameof(RoleCode.Admin))]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
        => Ok(await _application.AddAsync(request));

    [Authorize(Policy = nameof(RoleCode.Admin))]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductRequest request)
        => Ok(await _application.UpdateAsync(id, request));


    [Authorize(Policy = nameof(RoleCode.Admin))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _application.DeleteAsync(id));

}
