

namespace LiquorStore.Infrastructure.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    public int ProductTypeId { get; private set; }
    public ProductType ProductType { get; private set; }
    public string? ImageUrl { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
}