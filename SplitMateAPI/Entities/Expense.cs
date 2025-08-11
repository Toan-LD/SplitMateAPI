using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class Expense
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }

    public Guid PayerId { get; set; }

    public decimal Amount { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ExpenseShare> ExpenseShares { get; set; } = new List<ExpenseShare>();

    public virtual Group Group { get; set; } = null!;

    public virtual User Payer { get; set; } = null!;
}
