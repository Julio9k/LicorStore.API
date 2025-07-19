using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class ShoppingCart
{
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public string Status { get; private set; } = "active";
    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();
}