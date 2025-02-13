using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Nationality
{
    public int nationalityID { get; set; }

    public string nationality1 { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
}
