//using System;
using System.Collections.Generic;
//using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
//using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public IndexModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products
                .Include(p => p.Market)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
