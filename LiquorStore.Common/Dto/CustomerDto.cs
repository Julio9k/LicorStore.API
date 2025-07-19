
namespace LiquorStore.Common.Dto;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? DNI { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;
    public int? UserId { get; set; }
    public UserDto? User { get; set; }
}
