using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Color
{
    public long colorID { get; set; }

    public string color1 { get; set; } = null!;

    public virtual ICollection<Publisher_Book> Publisher_Books { get; set; } = new List<Publisher_Book>();
}
