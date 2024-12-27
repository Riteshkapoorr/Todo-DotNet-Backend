using System;
using System.Collections.Generic;

namespace Todo_DotNet_Backend.Models;

public partial class Task
{
    public int Id { get; set; }

    public int? LabelId { get; set; }

    public string? TaskName { get; set; }

    public string? TaskDesc { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Label? Label { get; set; }
}
