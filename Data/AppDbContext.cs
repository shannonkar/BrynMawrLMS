using System;
using System.Collections.Generic;
using BrynMawrLMS.Models;
using Microsoft.EntityFrameworkCore;

namespace BrynMawrLMS.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrowingrecord> Borrowingrecords { get; set; }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=skariu01;Password=01680114;Data Source=vu2025.cypibltd7eim.us-east-2.rds.amazonaws.com:1521/ORCL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("SKARIU01")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Authorid).HasName("AUTHOR_PK");

            entity.ToTable("AUTHOR");

            entity.Property(e => e.Authorid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("AUTHORID");
            entity.Property(e => e.Biography)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("BIOGRAPHY");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Nationality)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NATIONALITY");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("BOOK_PK");

            entity.ToTable("BOOK");

            entity.Property(e => e.Bookid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("BOOKID");
            entity.Property(e => e.Author)
                .HasColumnType("NUMBER")
                .HasColumnName("AUTHOR");
            entity.Property(e => e.Edition)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EDITION");
            entity.Property(e => e.Genre)
                .HasColumnType("NUMBER")
                .HasColumnName("GENRE");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LANGUAGE");
            entity.Property(e => e.Numberofpages)
                .HasColumnType("NUMBER")
                .HasColumnName("NUMBEROFPAGES");
            entity.Property(e => e.Publisheddate)
                .HasColumnType("DATE")
                .HasColumnName("PUBLISHEDDATE");
            entity.Property(e => e.Publisher)
                .HasColumnType("NUMBER")
                .HasColumnName("PUBLISHER");
            entity.Property(e => e.Summary)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("SUMMARY");
            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BOOK_AUTHOR_FK");

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Genre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BOOK_GENRE_FK");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Publisher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BOOK_PUBLISHER_FK");
        });

        modelBuilder.Entity<Borrowingrecord>(entity =>
        {
            entity.HasKey(e => e.Recordid).HasName("B_RECORD_PK");

            entity.ToTable("BORROWINGRECORD");

            entity.HasIndex(e => new { e.Member, e.Catalogue, e.Borrowdate }, "B_RECORD_UQ_MEMBER_CATALOGUE_BORROWDATE").IsUnique();

            entity.Property(e => e.Recordid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("RECORDID");
            entity.Property(e => e.Borrowdate)
                .HasColumnType("DATE")
                .HasColumnName("BORROWDATE");
            entity.Property(e => e.Catalogue)
                .HasColumnType("NUMBER")
                .HasColumnName("CATALOGUE");
            entity.Property(e => e.Duedate)
                .HasColumnType("DATE")
                .HasColumnName("DUEDATE");
            entity.Property(e => e.Librarian)
                .HasColumnType("NUMBER")
                .HasColumnName("LIBRARIAN");
            entity.Property(e => e.Member)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBER");
            entity.Property(e => e.Returndate)
                .HasColumnType("DATE")
                .HasColumnName("RETURNDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.CatalogueNavigation).WithMany(p => p.Borrowingrecords)
                .HasForeignKey(d => d.Catalogue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("B_RECORD_CATALOGUE_FK");

            entity.HasOne(d => d.LibrarianNavigation).WithMany(p => p.Borrowingrecords)
                .HasForeignKey(d => d.Librarian)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("B_RECORD_LIBRARIAN_FK");

            entity.HasOne(d => d.MemberNavigation).WithMany(p => p.Borrowingrecords)
                .HasForeignKey(d => d.Member)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("B_RECORD_MEMBER_FK");
        });

        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.HasKey(e => e.Catalogueid).HasName("CATALOGUE_PK");

            entity.ToTable("CATALOGUE");

            entity.Property(e => e.Catalogueid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CATALOGUEID");
            entity.Property(e => e.Aquisitiondate)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("AQUISITIONDATE");
            entity.Property(e => e.Book)
                .HasColumnType("NUMBER")
                .HasColumnName("BOOK");
            entity.Property(e => e.Copynumber)
                .HasColumnType("NUMBER")
                .HasColumnName("COPYNUMBER");
            entity.Property(e => e.Dewysystem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEWYSYSTEM");
            entity.Property(e => e.Shelflocation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHELFLOCATION");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.BookNavigation).WithMany(p => p.Catalogues)
                .HasForeignKey(d => d.Book)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CATALOGUE_BOOK_FK");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Genreid).HasName("GENRE_PK");

            entity.ToTable("GENRE");

            entity.Property(e => e.Genreid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("GENREID");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.HasKey(e => e.Librarianid).HasName("LIBRARIAN_PK");

            entity.ToTable("LIBRARIAN");

            entity.Property(e => e.Librarianid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("LIBRARIANID");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAILADDRESS");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Hiredate)
                .HasDefaultValueSql("sysdate ")
                .HasColumnType("DATE")
                .HasColumnName("HIREDATE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLE");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Memberid).HasName("MEMBER_PK");

            entity.ToTable("MEMBER");

            entity.Property(e => e.Memberid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS2");
            entity.Property(e => e.Birthdate)
                .HasColumnType("DATE")
                .HasColumnName("BIRTHDATE");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COUNTRYCODE");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAILADDRESS");
            entity.Property(e => e.Expirydate)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRYDATE");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.Joindate)
                .HasDefaultValueSql("SYSDATE ")
                .HasColumnType("DATE")
                .HasColumnName("JOINDATE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Membershipstatus)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MEMBERSHIPSTATUS");
            entity.Property(e => e.Membershiptype)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MEMBERSHIPTYPE");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Publisherid).HasName("PUBLISHER_PK");

            entity.ToTable("PUBLISHER");

            entity.Property(e => e.Publisherid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PUBLISHERID");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS2");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.Countrycode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COUNTRYCODE");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAILADDRESS");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Publishername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PUBLISHERNAME");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WEBSITE");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
