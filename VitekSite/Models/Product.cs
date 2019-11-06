using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitekSite.Models
{
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int ProductID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string ProductName{ get; set; }
        
        [Range(0, 99999)]
        public int Price { get; set; }

        public int MarketID { get; set; }
        public Market Market { get; set; }


        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<ProductAssignment> ProductAssignments { get; set; }

    }
}
