using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class PersonalLibrary
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedTimeStamp { get; set; }

        //Foreign Key
        public int ClientId { get; set; }
        //Navigation Property
        public Client Client { get; set; }

        public List<PersonalLibraryBook> PersonalLibraryBooks { get; set; }


    }
}
