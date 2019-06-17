using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models
{
    public enum Genre
    {
        Basic, 
        Silver,
        Gold
    }

    public class Membership
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime DateInitiated { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
