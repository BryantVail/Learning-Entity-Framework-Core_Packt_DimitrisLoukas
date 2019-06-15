using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;

namespace BookStoreApp.QueryObjects
{
    public class BooksQuery : IBooksQuery
    {
        public bool LoadAuthor { get; set; } = false;

        public int? AuthorId { get; set; } = null;

        //TODO
        public DateTime CreatedBefore { get; set; }

        //TODO
        public DateTime CreatedAfter { get; set; }

        //TODO
        public string Title { get; set; }

        public async Task<IEnumerable<Book>> Execute(DbContext context)
        {
            if(AuthorId == null)
            {
                if(LoadAuthor)
                {
                    return await context.Set<Book>().Include(b => b.Author).ToListAsync();
                }
                else
                {
                    return await context.Set<Book>().ToListAsync();
                }
            }
            else
            {
                return await context.Set<Book>().Where(b => b.AuthorId == (int)AuthorId).ToListAsync();
            }
        }
    }
}
