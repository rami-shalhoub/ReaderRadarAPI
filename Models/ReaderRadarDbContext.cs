using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReaderRadarAPI.Models;

public partial class ReaderRadarDbContext : DbContext
{
    public ReaderRadarDbContext()
    {
    }

    public ReaderRadarDbContext(DbContextOptions<ReaderRadarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookList> BookLists { get; set; }

    public virtual DbSet<Book_Author> Book_Authors { get; set; }

    public virtual DbSet<Book_Genre> Book_Genres { get; set; }

    public virtual DbSet<Book_Store> Book_Stores { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Publisher_Book> Publisher_Books { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shape> Shapes { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=ReaderRadar;User=rami;Password=S@mihallak0000;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.authorID).HasName("PK_AuthorID");

            entity.ToTable("Author");

            entity.Property(e => e.firstName).HasMaxLength(255);
            entity.Property(e => e.gender).HasMaxLength(255);
            entity.Property(e => e.lastName).HasMaxLength(255);

            entity.HasOne(d => d.nationality).WithMany(p => p.Authors)
                .HasForeignKey(d => d.nationalityID)
                .HasConstraintName("FK_Author_Nationality_NationalityID");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.bookID).HasName("PK_BookID");

            entity.ToTable("Book");

            entity.Property(e => e.bookDesciption).HasMaxLength(255);
            entity.Property(e => e.bookName).HasMaxLength(255);
        });

        modelBuilder.Entity<BookList>(entity =>
        {
            entity.HasKey(e => e.listID).HasName("PK_ListID");

            entity.ToTable("BookList");

            entity.Property(e => e.listType)
                .HasMaxLength(255)
                .HasDefaultValue("favorite");

            entity.HasOne(d => d.book).WithMany(p => p.BookLists)
                .HasForeignKey(d => d.bookID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-list_Book_BookID");

            entity.HasOne(d => d.user).WithMany(p => p.BookLists)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_List_User_UserID");
        });

        modelBuilder.Entity<Book_Author>(entity =>
        {
            entity.HasKey(e => e.authorBookID).HasName("Author_Book_PK");

            entity.ToTable("Book-Author");

            entity.HasOne(d => d.author).WithMany(p => p.Book_Authors)
                .HasForeignKey(d => d.authorID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-Author_Author");

            entity.HasOne(d => d.book).WithMany(p => p.Book_Authors)
                .HasForeignKey(d => d.bookID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-Author_Book");
        });

        modelBuilder.Entity<Book_Genre>(entity =>
        {
            entity.HasKey(e => e.bookGenreID).HasName("PK_Book-genreID");

            entity.ToTable("Book-Genre");

            entity.HasOne(d => d.book).WithMany(p => p.Book_Genres)
                .HasForeignKey(d => d.bookID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-genre_Book_BookID");

            entity.HasOne(d => d.genre).WithMany(p => p.Book_Genres)
                .HasForeignKey(d => d.genreID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-genre_Genre_GenreID");
        });

        modelBuilder.Entity<Book_Store>(entity =>
        {
            entity.HasKey(e => e.bookStoreID).HasName("PK_Book-storeID");

            entity.ToTable("Book-Store");

            entity.Property(e => e.availability)
                .HasMaxLength(16)
                .IsFixedLength();

            entity.HasOne(d => d.book).WithMany(p => p.Book_Stores)
                .HasForeignKey(d => d.bookID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-store_Book_BookID");

            entity.HasOne(d => d.store).WithMany(p => p.Book_Stores)
                .HasForeignKey(d => d.storeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book-store_Store-StoreID");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.colorID).HasName("PK_ColorID");

            entity.ToTable("Color");

            entity.Property(e => e.color1)
                .HasMaxLength(255)
                .HasColumnName("color");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.genreID).HasName("PK_GenreID");

            entity.ToTable("Genre");

            entity.Property(e => e.genre1)
                .HasMaxLength(255)
                .HasColumnName("genre");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.nationalityID).HasName("PK_NationalityID");

            entity.ToTable("Nationality");

            entity.Property(e => e.nationality1)
                .HasMaxLength(255)
                .HasColumnName("nationality");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.publisherID).HasName("PK_PublisherID");

            entity.ToTable("Publisher");

            entity.Property(e => e.address).HasMaxLength(255);
            entity.Property(e => e.contactInfo).HasMaxLength(255);
            entity.Property(e => e.publisher1)
                .HasMaxLength(255)
                .HasColumnName("publisher");
            entity.Property(e => e.website).HasMaxLength(255);

            entity.HasOne(d => d.nationality).WithMany(p => p.Publishers)
                .HasForeignKey(d => d.nationalityID)
                .HasConstraintName("Publisher_Nationality_FK");
        });

        modelBuilder.Entity<Publisher_Book>(entity =>
        {
            entity.HasKey(e => e.publisherBookID).HasName("PK_Publisher-bookID");

            entity.ToTable("Publisher-Book");

            entity.Property(e => e.Disc).HasMaxLength(1000);

            entity.HasOne(d => d.book).WithMany(p => p.Publisher_Books)
                .HasForeignKey(d => d.bookID)
                .HasConstraintName("FK_Publisher-book_Book_BookID");

            entity.HasOne(d => d.color).WithMany(p => p.Publisher_Books)
                .HasForeignKey(d => d.colorID)
                .HasConstraintName("FK_Publisher-Book_Color");

            entity.HasOne(d => d.publisher).WithMany(p => p.Publisher_Books)
                .HasForeignKey(d => d.publisherID)
                .HasConstraintName("FK_Publisher-book_Publisher_PublisherID");

            entity.HasOne(d => d.shape).WithMany(p => p.Publisher_Books)
                .HasForeignKey(d => d.shapeID)
                .HasConstraintName("FK_Publisher-Book_Shape");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.reviewID).HasName("PK_ReviewID");

            entity.ToTable("Review");

            entity.Property(e => e.review1)
                .HasMaxLength(255)
                .HasColumnName("review");

            entity.HasOne(d => d.book).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.bookID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Book_BookID");

            entity.HasOne(d => d.user).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.userID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_User_UserID");
        });

        modelBuilder.Entity<Shape>(entity =>
        {
            entity.HasKey(e => e.shapeID).HasName("PK_ShapeID");

            entity.ToTable("Shape");

            entity.Property(e => e.shape1)
                .HasMaxLength(255)
                .HasColumnName("shape");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.storeID).HasName("PK_StoreID");

            entity.ToTable("Store");

            entity.Property(e => e.storeAddress).HasMaxLength(255);
            entity.Property(e => e.storeName).HasMaxLength(255);
            entity.Property(e => e.storeWebsite).HasMaxLength(255);
            entity.Property(e => e.type).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.userID).HasName("PK_UserID");

            entity.ToTable("User");

            entity.HasIndex(e => new { e.username, e.email }, "UC_User").IsUnique();

            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.firstName).HasMaxLength(255);
            entity.Property(e => e.lastName).HasMaxLength(255);
            entity.Property(e => e.profileID).HasMaxLength(255);
            entity.Property(e => e.username).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
