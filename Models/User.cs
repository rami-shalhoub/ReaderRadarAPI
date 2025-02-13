using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class User
{
    public long userID { get; set; }

    public string firstName { get; set; } = null!;

    public string? lastName { get; set; }

    public string username { get; set; } = null!;

    public string email { get; set; } = null!;

    public long password { get; set; }

    public string? profileID { get; set; }

    public virtual ICollection<BookList> BookLists { get; set; } = new List<BookList>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
