using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    //Lookup table class
    public class PersonalLibraryBook
    {
        public Book Book { get; set; }
        public int BookId { get; set; }

        public PersonalLibrary PersonalLibrary { get; set; }
        public int PersonalLibraryId { get; set; }


    }
}
