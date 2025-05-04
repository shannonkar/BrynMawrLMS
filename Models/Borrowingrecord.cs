using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Borrowingrecord
{
    public decimal Recordid { get; set; }

    public decimal Member { get; set; }

    public decimal Catalogue { get; set; }

    public decimal Librarian { get; set; }

    public DateTime Borrowdate { get; set; }

    public DateTime Duedate { get; set; }

    public DateTime? Returndate { get; set; }

    public string Status { get; set; } = null!;

    public virtual Catalogue? CatalogueNavigation { get; set; } = null!;

    public virtual Librarian? LibrarianNavigation { get; set; } = null!;

    public virtual Member? MemberNavigation { get; set; } = null!;
}
