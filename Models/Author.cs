using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Author
{
    public decimal Authorid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Biography { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
