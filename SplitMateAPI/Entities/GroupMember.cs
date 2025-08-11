using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class GroupMember
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }

    public Guid UserId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
