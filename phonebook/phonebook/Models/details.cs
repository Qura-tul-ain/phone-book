using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace phonebook.Models
{

    public class details
    {
        public int PersonAdded { get; set; }
        public List<listsofpersons> totalpersons { get; set; } // list having persons , update in last 7 days
        public List<lists> totalname { get; set; }   // list having persons , dateofbirth in next 10 days



    }

    public class lists
    {
        public string name1 { get; set; }
       
    }

    public class listsofpersons
    {
        public string name3 { get; set; }
  
    }
}