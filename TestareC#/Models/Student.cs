using System;
using System.Collections.Generic;

namespace TestareC_.Models;

public partial class Student
{
    public int Id { get; set; }

    public int GrupaId { get; set; }

    public int OrasId { get; set; }

    public string? Nume { get; set; }

    public string? Prenume { get; set; }

    public virtual Grupa Grupa { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

    public virtual Orase Oras { get; set; } = null!;
}
