using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Book_Store
{
    public long bookStoreID { get; set; }

    public long bookID { get; set; }

    public long storeID { get; set; }

    public byte[] availability { get; set; } = null!;

    public virtual Book book { get; set; } = null!;

    public virtual Store store { get; set; } = null!;
}
