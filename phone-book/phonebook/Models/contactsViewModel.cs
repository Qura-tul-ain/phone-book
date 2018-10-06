using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace phonebook.Models
{
    public class contactsViewModel
    {
        public int ContactId { get; set; }
        public string ContactNumber { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
    }
}