using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Author
{
    public long authorID { get; set; }

    public string firstName { get; set; } = null!;

    public string? lastName { get; set; }

    public DateOnly? DoB { get; set; }

    public int? nationalityID { get; set; }

    public string? gender { get; set; }

    public virtual ICollection<Book_Author> Book_Authors { get; set; } = new List<Book_Author>();

    public virtual Nationality? nationality { get; set; }
}
