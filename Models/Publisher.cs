using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Publisher
{
    public long publisherID { get; set; }

    public string publisher1 { get; set; } = null!;

    public string? website { get; set; }

    public string? contactInfo { get; set; }

    public string? address { get; set; }

    public int? nationalityID { get; set; }

    public virtual ICollection<Publisher_Book> Publisher_Books { get; set; } = new List<Publisher_Book>();

    public virtual Nationality? nationality { get; set; }
}
