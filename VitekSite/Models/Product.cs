using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitekSite.Models
{
    public class Product
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public string ProductName{ get; set; }
        public int Price { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
