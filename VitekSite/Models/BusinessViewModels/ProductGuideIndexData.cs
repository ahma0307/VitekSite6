using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitekSite.Models.BusinessViewModels
{
    public class ProductGuideIndexData
    {
        public IEnumerable<ProductGuide> ProductGuides { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}