using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Common.Responses;

public class LoginResponse
{
    public string Token { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string PhotoUrl { get; set; }
}
