using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class SaleDetail
{
    public int Id { get; private set; }
    public int SaleId { get; private set; }
    public Sale Sale { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Subtotal { get; private set; }
}