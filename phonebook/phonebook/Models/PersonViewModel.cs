using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace phonebook.Models
{
    public class PersonViewModel
    {
        
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" , ApplyFormatInEditMode = false)]
        [Display(Name = "BirthDate")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public System.DateTime AddedOn { get; set; }
        public string AddedBy { get; set; }
        public string HomeAddress { get; set; }
        [Required]
        public string HomeCity { get; set; }
        public string FaceBookAccountId { get; set; }
        public string LinkedInId { get; set; }
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public string ImagePath { get; set; }
        public string TwitterId { get; set; }
        [Required]
        public string EmailId { get; set; }
    }
}