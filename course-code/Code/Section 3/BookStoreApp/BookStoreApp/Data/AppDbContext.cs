using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using BookStoreApp.Models;

namespace BookStoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<PersonalLibrary> PersonalLibraries { get; set; }
        public DbSet<PersonalLibraryBook> PersonalLibraryBooks { get; set; }

        //from dbContext Definition
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Isbn).HasMaxLength(10);
            //If a unique value is not a foreign key, enforce perhaps w/an index
            modelBuilder.Entity<Book>().HasIndex(b => b.Isbn).HasName("IsbnIndex").IsUnique();
            modelBuilder.Entity<Book>().Ignore(b => b.FullTitle);
            //modelBuilder.Entity<Book>().Property(b => b.CreatedTimeStamp).HasDefaultValueSql("getDate()");
            modelBuilder.Entity<Book>().Property<DateTime>("CreatedTimeStamp").HasDefaultValueSql("getDate()");
            //modelBuilder.Entity<Book>().Property<Int32>("AuthorId");
            //modelBuilder.Entity<Author>().HasKey(a => new { a.FirstName, a.LastName, a.DateOfBirth });

            //these exist in the class explicitly now
            //modelBuilder.Entity<PersonalLibraryBook>().Property<Int32>("BookId");
            //modelBuilder.Entity<PersonalLibraryBook>().Property<Int32>("PersonalLibraryId");

            //One-to-One
            modelBuilder.Entity<Client>().HasOne(c => c.Library).WithOne(l => l.Client).HasForeignKey<PersonalLibrary>();

            //One-to-Many

            //Setting Key for Many-to-Many
            modelBuilder.Entity<PersonalLibraryBook>()
                .HasKey(pl => new { pl.BookId, pl.PersonalLibraryId});

            //PersonalLibraryBook Connection statements to foreign keys
            //Book - PersonalLibrary many-to-many rel.
            modelBuilder.Entity<PersonalLibraryBook>()
                //One to Many Function
                .HasOne(plb => plb.Book)
                //Every Book has Many Libraries
                .WithMany(b => b.PersonalLibraries)
                //Foreign Key
                .HasForeignKey(pl => pl.BookId);
            //Book - 
            modelBuilder.Entity<PersonalLibraryBook>()
                //PersonalLibraryBook HasOne PersonalLibrary
                .HasOne(plb => plb.PersonalLibrary)
                //PersonalLibraryBook HasMany PersonalLibraryBooks
                .WithMany(pl => pl.PersonalLibraryBooks)
                .HasForeignKey(plbs => plbs.PersonalLibraryId);

        }
    }
}

