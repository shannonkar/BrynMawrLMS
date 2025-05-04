using System;
using System.Collections.Generic;

namespace BrynMawrLMS.Models;

public partial class Book
{
    public decimal Bookid { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public decimal? Numberofpages { get; set; }

    public string? Language { get; set; }

    public string? Edition { get; set; }

    public string? Summary { get; set; }

    public DateTime? Publisheddate { get; set; }

    public decimal Author { get; set; }

    public decimal Publisher { get; set; }

    public decimal Genre { get; set; }

    public virtual Author? AuthorNavigation { get; set; } = null!;

    public virtual ICollection<Catalogue> Catalogues { get; set; } = new List<Catalogue>();

    public virtual Genre? GenreNavigation { get; set; } = null!;

    public virtual Publisher? PublisherNavigation { get; set; } = null!;
}
