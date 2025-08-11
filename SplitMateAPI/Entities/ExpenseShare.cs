using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class ExpenseShare
{
    public Guid Id { get; set; }

    public Guid ExpenseId { get; set; }

    public Guid UserId { get; set; }

    public decimal ShareAmount { get; set; }

    public virtual Expense Expense { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
