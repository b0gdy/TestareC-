using System;
using System.Collections.Generic;

namespace TestareC_.Models;

public partial class Materie
{
    public int Id { get; set; }

    public string? Nume { get; set; }

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

}
