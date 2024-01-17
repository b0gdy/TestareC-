using System;
using System.Collections.Generic;

namespace TestareC_.Models;

public partial class Orase
{
    public int Id { get; set; }

    public string? Denumire { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
