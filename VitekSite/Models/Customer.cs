using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitekSite.Models
{
        public class Customer
        {
            public int ID { get; set; }
            public string LastName { get; set; }
            public string FirstMidName { get; set; }
            public DateTime SubscriptionDate { get; set; }

            public ICollection<Subscription> Subscriptions { get; set; }
            public string Secret { get; set; }
    }
}
