using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VitekSite.Models
{
    public enum CustomerLoyalty
    {
        A, B, C, D, F
    }
    public class Subscription
    {
            public int SubscriptionID { get; set; }
            public int ProductID { get; set; }
            public int CustomerID { get; set; }
            [DisplayFormat(NullDisplayText = "Loyalty not set")]
            public CustomerLoyalty? CustomerLoyalty { get; set; }

            public Product Product { get; set; }
            public Customer Customer { get; set; }
    }
}
