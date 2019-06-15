using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;

namespace BookStoreApp.Data
{
    public static class AppDbContextExtensions
    {
        public static void EnsureDatabaseSeeded(this AppDbContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (!context.Authors.Any())
                    {
                        context.AddRange(new Author[]
                        {
                            new Author()
                            {
                                FirstName = "John",
                                LastName = "Smith",
                                DoB = new DateTime(1980, 2, 5),
                                Nationality = "Italy"
                            },
                            new Author()
                            {
                                FirstName = "Jane",
                                LastName = "Smith",
                                DoB = new DateTime(1977, 5, 25)
                            }
                        });
                        context.SaveChanges();
                    }

                    if (!context.Books.Any())
                    {
                        var author1 = context.Authors.SingleOrDefault(a => a.FirstName.Equals("John") && a.LastName.Equals("Smith"));
                        var author2 = context.Authors.SingleOrDefault(a => a.FirstName.Equals("Jane") && a.LastName.Equals("Smith"));

                        context.Books.AddRange(new Book[]
                        {
                            new Book()
                            {
                                AuthorId = author1.Id,
                                Isbn = "111111",
                                Title = "Book 1"
                            },
                            new Book()
                            {
                                AuthorId = author2.Id,
                                Isbn = "222222",
                                Title = "Book 2"
                            }
                        });
                        context.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch(Exception e)
                {
                    transaction.Rollback();
                }
                
            }
                
        }
    }
}
