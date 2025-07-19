using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class CartItem
{
    public int Id { get; private set; }
    public int ShoppingCartId { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
}