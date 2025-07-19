using LiquorStore.Common.Enums;

namespace LiquorStore.Common.Dto;

public class RoleDto
{
    public int Id { get; set; }
    public RoleCode Code { get; set; }
    public string Description { get; set; }
}
