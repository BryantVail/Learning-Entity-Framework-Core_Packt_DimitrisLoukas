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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Isbn).HasMaxLength(10);
            modelBuilder.Entity<Book>().HasIndex(b => b.Isbn).HasName("IsbnIndex").IsUnique();
            //modelBuilder.Entity<Book>().Ignore(b => b.FullTitle);
            modelBuilder.Entity<Book>().Property<DateTime>("CreatedAt").HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Author>().HasKey(a => new { a.FirstName, a.LastName });

            //Client - Personal Library one-to-one relationship
            modelBuilder.Entity<Client>().HasOne(c => c.Library).WithOne(l => l.Client).HasForeignKey<PersonalLibrary>();

            modelBuilder.Entity<PersonalLibraryBook>().HasKey(pl => new { pl.BookId, pl.LibraryId });

            //Book - PersonalLibrary many-to-many relationship
            modelBuilder.Entity<PersonalLibraryBook>().HasOne(pl => pl.Book).WithMany(b => b.PersonalLibraryBooks).HasForeignKey(pl => pl.BookId);
            modelBuilder.Entity<PersonalLibraryBook>().HasOne(pl => pl.PersonalLibrary).WithMany(l => l.PersonalLibraryBooks).HasForeignKey(pl => pl.LibraryId);
        }
    }
}

