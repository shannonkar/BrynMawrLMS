using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Catalogue
{
    public decimal Catalogueid { get; set; }

    public decimal Book { get; set; }

    public string Shelflocation { get; set; } = null!;

    public decimal Copynumber { get; set; }

    public DateTime Aquisitiondate { get; set; }

    public string? Dewysystem { get; set; }

    public string Status { get; set; } = null!;

    public virtual Book? BookNavigation { get; set; } = null!;

    public virtual ICollection<Borrowingrecord> Borrowingrecords { get; set; } = new List<Borrowingrecord>();
}
