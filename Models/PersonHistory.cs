using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RejestrOsobZaginionych.Models
{
    public class PersonHistory
    {
        public int PersonHistoryId { get; set; }

        [Required]
        [Display(Name="Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [Display(Name ="Is Found?")]
        public bool IsFound { get; set; }

        [Display(Name = "Lost Date")]
        public DateTime LostDate { get; set; }

        [Display(Name = "Found Date")]
        public DateTime? FoundDate { get; set; }
    }
}