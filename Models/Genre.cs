using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Genre
{
    public decimal Genreid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
