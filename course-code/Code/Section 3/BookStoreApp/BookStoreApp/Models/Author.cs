using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Author
    {
        //[Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        
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

        public List<AuthorBookLookup> Books { get; set; }

    }
}













