using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class Group
{
    public Guid Id { get; set; }

    public string GroupName { get; set; } = null!;

    public Guid OwnerId { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<GroupMember> GroupMembers { get; set; } = new List<GroupMember>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual User Owner { get; set; } = null!;
}
