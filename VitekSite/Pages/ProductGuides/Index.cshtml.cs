using System;
using VitekSite.Models.BusinessViewModels;  // Add VM

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.ProductGuides
{
    public class IndexModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public IndexModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        public ProductGuideIndexData ProductGuideData { get; set; }
        public int ProductGuideID { get; set; }
        public int ProductID { get; set; }

        public async Task OnGetAsync(int? id, int? productID)
        {
            ProductGuideData = new ProductGuideIndexData();
            ProductGuideData.ProductGuides = await _context.ProductGuides
                .Include(pg => pg.CountryAssignment)
                .Include(pg => pg.ProductAssignments)
                    .ThenInclude(pg => pg.Product)
                        .ThenInclude(pg => pg.Market)
                .Include(pg => pg.ProductAssignments)
                    .ThenInclude(pg => pg.Product)
                        .ThenInclude(pg => pg.Subscriptions)
                            .ThenInclude(pg => pg.Customer)
                .AsNoTracking()
                .OrderBy(pg => pg.LastName)
                .ToListAsync();

            if (id != null)
            {
                ProductGuideID = id.Value;
                ProductGuide productGuide = ProductGuideData.ProductGuides
                    .Where(i => i.ID == id.Value).Single();
                ProductGuideData.Products = productGuide.ProductAssignments.Select(s => s.Product);
            }

            if (productID != null)
            {
                ProductID = productID.Value;
                var selectedCourse = ProductGuideData.Products
                    .Where(x => x.ProductID == productID).Single();
                ProductGuideData.Subscriptions = selectedCourse.Subscriptions;
            }

        public IList<ProductGuide> ProductGuide { get;set; }

        public async Task OnGetAsync()
        {
            ProductGuide = await _context.ProductGuides.ToListAsync();
        }
    }
}
