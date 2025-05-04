using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Librarian
{
    public decimal Librarianid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Emailaddress { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime Hiredate { get; set; }

    public virtual ICollection<Borrowingrecord> Borrowingrecords { get; set; } = new List<Borrowingrecord>();
}
