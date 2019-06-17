using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public class AuthorBookLookup
    {
        public Book Book { get; set; }
        public int BookId { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

    }
}
