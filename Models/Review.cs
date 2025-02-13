using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Review
{
    public long reviewID { get; set; }

    public byte starts { get; set; }

    public string? review1 { get; set; }

    public long userID { get; set; }

    public long bookID { get; set; }

    public virtual Book book { get; set; } = null!;

    public virtual User user { get; set; } = null!;
}
