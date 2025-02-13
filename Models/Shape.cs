using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Shape
{
    public long shapeID { get; set; }

    public string shape1 { get; set; } = null!;

    public virtual ICollection<Publisher_Book> Publisher_Books { get; set; } = new List<Publisher_Book>();
}
