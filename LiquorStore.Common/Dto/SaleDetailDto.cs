
namespace LiquorStore.Common.Dto;

public class SaleDetailDto
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public SaleDto Sale { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}