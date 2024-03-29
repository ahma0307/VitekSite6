﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitekSite.Models
{
        public class Customer
        {
            public int ID { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
            [Column("FirstName")]
            [Display(Name = "First Name")]
            public string FirstMidName { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            [Display(Name = "Subscription Date")]
            public DateTime SubscriptionDate { get; set; }
            [Display(Name = "Full Name")]
            public string FullName
            {
                get
                {
                    return LastName + ", " + FirstMidName;
                }
            }
           
            public ICollection<Subscription> Subscriptions { get; set; }
    }
}
