using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class BookList
{
    public long listID { get; set; }

    public long userID { get; set; }

    public long bookID { get; set; }

    public string listType { get; set; } = null!;

    public virtual Book book { get; set; } = null!;

    public virtual User user { get; set; } = null!;
}
