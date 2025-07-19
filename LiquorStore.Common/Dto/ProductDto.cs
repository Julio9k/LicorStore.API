namespace LiquorStore.Common.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
    public int ProductTypeId { get; set; }
    public ProductTypeDto ProductType { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
