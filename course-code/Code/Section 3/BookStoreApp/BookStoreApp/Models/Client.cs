using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class Client
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64)]
        public string Email { get; set; }

        
        [MaxLength(64)]
        public string PhoneNumber { get; set; }

        //Id field only needs to be included on Dependent Property, Not Principal
        public Membership Membership { get; set; }
        public PersonalLibrary Library { get; set; }



    }
}