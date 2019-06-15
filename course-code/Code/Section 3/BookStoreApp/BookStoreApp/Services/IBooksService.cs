using BookStoreApp.Models;
using BookStoreApp.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<Book>> All();

        Task<IEnumerable<Book>> GetBooks(IBooksQuery query);

        Task Create(Book book);

        Task Update(Book book);

        Task Delete(int id);
    }
}
