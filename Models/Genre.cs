using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Genre
{
    public long genreID { get; set; }

    public string genre1 { get; set; } = null!;

    public virtual ICollection<Book_Genre> Book_Genres { get; set; } = new List<Book_Genre>();
}
