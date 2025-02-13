using System;
using System.Collections.Generic;

namespace ReaderRadarAPI.Models;

public partial class Book
{
    public long bookID { get; set; }

    public string bookName { get; set; } = null!;

    public DateOnly? publishingDate { get; set; }

    public string? bookDesciption { get; set; }

    public int? edition { get; set; }

    public int? volume { get; set; }

    public int? pages { get; set; }

    public int? ISBN { get; set; }

    public virtual ICollection<BookList> BookLists { get; set; } = new List<BookList>();

    public virtual ICollection<Book_Author> Book_Authors { get; set; } = new List<Book_Author>();

    public virtual ICollection<Book_Genre> Book_Genres { get; set; } = new List<Book_Genre>();

    public virtual ICollection<Book_Store> Book_Stores { get; set; } = new List<Book_Store>();

    public virtual ICollection<Publisher_Book> Publisher_Books { get; set; } = new List<Publisher_Book>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
