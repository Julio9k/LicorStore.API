using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class Offer
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public string? Description { get; private set; }
    public decimal OfferPrice { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
}