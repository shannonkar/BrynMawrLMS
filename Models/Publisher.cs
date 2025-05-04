using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Publisher
{
    public decimal Publisherid { get; set; }

    public string Publishername { get; set; } = null!;

    public string? Website { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zipcode { get; set; }

    public string? Countrycode { get; set; }

    public string? Phonenumber { get; set; }

    public string? Emailaddress { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
