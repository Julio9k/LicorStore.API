using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Infrastructure.Entities;

public class ProductSuggestion
{
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int SuggestionReasonId { get; private set; }
    public SuggestionReason SuggestionReason { get; private set; }
    public DateTime SuggestedAt { get; private set; } = DateTime.UtcNow;
    public bool Viewed { get; private set; } = false;
}