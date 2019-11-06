using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VitekSite.Models
{
    public class ProductAssignment
    {
        public int ProductGuideID { get; set; }
        public int ProductID { get; set; }
        public ProductGuide ProductGuide { get; set; }
        public Product Product { get; set; }
    }
}
