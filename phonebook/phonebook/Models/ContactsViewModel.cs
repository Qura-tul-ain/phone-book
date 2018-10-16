using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace phonebook.Models
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Type { get; set; }
        public int PersonId { get; set; }

    }
}