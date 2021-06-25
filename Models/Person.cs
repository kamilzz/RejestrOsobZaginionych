using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsobZaginionych.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string Lastname { get; set; }

        [Required]
        [Display(Name ="Is Woman?")]
        public bool IsWoman { get; set; }

        public string City { get; set; }

        public int Age { get; set; }

        public ICollection<PersonHistory> PersonHistories { get; set; }
    }
}