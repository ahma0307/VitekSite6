using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VitekSite.Models.BusinessViewModels
{
    public class SubscriptionDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? SubscriptionDate { get; set; }

        public int CustomerCount { get; set; }
    }
}
