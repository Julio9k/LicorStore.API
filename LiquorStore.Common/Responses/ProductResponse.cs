using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Common.Responses;

public class ProductResponse
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal UnitPrice { get; private set; }
    public string Category { get; private set; }
    public string ProductType { get; private set; }
}