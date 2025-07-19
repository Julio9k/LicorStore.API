
namespace LiquorStore.Infrastructure.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Username { get; set; }
    public int RoleId { get; private set; }
    public Role Role { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public Customer Customer { get; set; }
}