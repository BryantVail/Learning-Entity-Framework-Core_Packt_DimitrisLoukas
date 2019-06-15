using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.QueryObjects
{
    public interface IBooksQuery
    {
        Task<IEnumerable<Book>> Execute(DbContext context);
    }
}
