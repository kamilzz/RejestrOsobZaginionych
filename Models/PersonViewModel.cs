using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsobZaginionych.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Display(Name = "Is Woman?")]
        public bool IsWoman { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        [Display(Name = "Is Found?")]
        public bool IsFound { get; set; }
    }
}