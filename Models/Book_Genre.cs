using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Book_Genre
{
    public long bookGenreID { get; set; }

    public long bookID { get; set; }

    public long genreID { get; set; }

    public virtual Book book { get; set; } = null!;

    public virtual Genre genre { get; set; } = null!;
}
