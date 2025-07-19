using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Common.Enums;

namespace LiquorStore.Common.Dto;

public class UserDto
{
    public int Id { get;  set; }
    public string Name { get;  set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get;  set; }
    public string PasswordHash { get;  set; }
    public int RoleId { get;  set; }
    public RoleCode RoleCode { get;  set; }
    public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;
}