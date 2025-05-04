using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Member
{
    public decimal Memberid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string Emailaddress { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string Countrycode { get; set; } = null!;

    public string Membershiptype { get; set; } = null!;

    public DateTime Joindate { get; set; }

    public DateTime? Expirydate { get; set; }

    public string Membershipstatus { get; set; } = null!;

    public virtual ICollection<Borrowingrecord> Borrowingrecords { get; set; } = new List<Borrowingrecord>();
}
