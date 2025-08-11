using System;
using System.Collections.Generic;

namespace SplitMateAPI.Entities;

public partial class Message
{
    public Guid Id { get; set; }

    public Guid GroupId { get; set; }

    public Guid SenderId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
