using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Common.Dto;

public class SaleDto
{
    public int Id { get; private set; }
    public int CustomerId { get; set; }
    public CustomerDto Customer { get; set; }
    public int? UserId { get; set; }
    public UserDto? User { get; set; }
    public DateTime SaleDate { get; private set; } = DateTime.UtcNow;
    public decimal Total { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethodDto PaymentMethod { get; set; }
    public int SaleStatusId { get; set; }
    public SaleStatusDto SaleStatus { get; set; }
    public ICollection<SaleDetailDto> Details { get; set; } = new List<SaleDetailDto>();
}
