using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Common.Enums;

namespace LiquorStore.Infrastructure.Entities;

public class Role
{
    public int Id { get; private set; }
    public RoleCode Code { get; set; }
    public string Description { get; set; }
    public ICollection<User> Users { get; private set; } = new List<User>();
}