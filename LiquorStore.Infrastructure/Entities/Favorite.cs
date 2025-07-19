using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class Favorite
{
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public DateTime AddedAt { get; private set; } = DateTime.UtcNow;
}