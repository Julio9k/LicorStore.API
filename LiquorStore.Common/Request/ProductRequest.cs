
namespace LiquorStore.Common.Request;

public class ProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public int ProductTypeId { get; set; }
    public string? ImageUrl { get; set; }
}
