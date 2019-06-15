using BookStoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.QueryObjects;

namespace BookStoreApp.Services
{
    public class BooksService : IBooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> All()
        {
            return await _context.Books.ToListAsync();
        }

        public Task Create(Book book)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooks(IBooksQuery query)
        {
            return query.Execute(_context);
        }

        public Task Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
