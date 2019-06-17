using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Author
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        [NotMapped]
        public string FullName {
            get
            {
                return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }

        public List<Book> Books { get; set; }

    }
}













