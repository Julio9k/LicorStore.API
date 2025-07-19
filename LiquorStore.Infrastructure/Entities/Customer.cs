
namespace LiquorStore.Infrastructure.Entities;

public class Customer
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? DNI { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;
    public int? UserId { get; set; }
    public User? User { get; set; }
}