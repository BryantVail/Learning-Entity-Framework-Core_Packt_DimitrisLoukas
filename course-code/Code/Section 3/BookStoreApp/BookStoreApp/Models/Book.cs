using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class Book
    {
        //[Key]
        //public int BookIdentifier { get; set; }
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Title { get; set; }



        //public List<AuthorBookLookup> Authors { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Isbn { get; set; }

        //Initialized Values
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//DatabaseGenerationOption must be selected explicitly
        //public DateTime CreatedTimeStamp { get; set; }


        //Composite Values
        public string FullTitle
        {
            get
            {///*{Author.FullName}*/
                return $" Author's Name's {Title}";
            }
        }

        //public protected string AppendAuthors()
        //{
        //    string author = "";
        //    foreach (Author author in Authors)
        //    {

        //    }
        //}

        public List<PersonalLibraryBook> PersonalLibraries { get; set; }

    }
}
