namespace LiquorStore.Infrastructure.Entities;

public class Sale
{
    public int Id { get; private set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public DateTime SaleDate { get; private set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public int SaleStatusId { get; set; }
    public SaleStatus SaleStatus { get; set; }
    public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();
}