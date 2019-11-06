using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace VitekSite.Models
{
    public class CountryAssignment
    {
        [Key]
        public int ProductGuideID { get; set; }
        [StringLength(50)]
        [Display(Name = "Country Location")]
        public string Location { get; set; }

        public ProductGuide ProductGuide { get; set; }
    }
}