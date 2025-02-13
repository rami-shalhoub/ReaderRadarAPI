using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Publisher_Book
{
    public long publisherBookID { get; set; }

    public long? bookID { get; set; }

    public long? publisherID { get; set; }

    public long? descriptionID { get; set; }

    public long? shapeID { get; set; }

    public long? colorID { get; set; }

    public string? Disc { get; set; }

    public virtual Book? book { get; set; }

    public virtual Color? color { get; set; }

    public virtual Publisher? publisher { get; set; }

    public virtual Shape? shape { get; set; }
}
