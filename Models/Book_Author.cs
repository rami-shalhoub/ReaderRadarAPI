using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Book_Author
{
    public long authorBookID { get; set; }

    public long bookID { get; set; }

    public long authorID { get; set; }

    public bool? MainAuthor { get; set; }

    public virtual Author author { get; set; } = null!;

    public virtual Book book { get; set; } = null!;
}
