using System;
using System.Collections.Generic;

namespace Todo_DotNet_Backend.Models;

public partial class Label
{
    public int LabelId { get; set; }

    public string? LabelName { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
