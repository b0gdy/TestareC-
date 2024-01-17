using System;
using System.Collections.Generic;

namespace TestareC_.Models;

public partial class Note
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int MaterieId { get; set; }

    public int? NotaObtinuta { get; set; }

    public virtual Materie Materie { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
