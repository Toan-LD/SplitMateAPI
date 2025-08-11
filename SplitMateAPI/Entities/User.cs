using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ExpenseShare> ExpenseShares { get; set; } = new List<ExpenseShare>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();
}
