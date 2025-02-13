using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Store
{
    public long storeID { get; set; }

    public string storeName { get; set; } = null!;

    public string type { get; set; } = null!;

    public string? storeWebsite { get; set; }

    public string? storeAddress { get; set; }

    public int? contactInfo { get; set; }

    public virtual ICollection<Book_Store> Book_Stores { get; set; } = new List<Book_Store>();
}
