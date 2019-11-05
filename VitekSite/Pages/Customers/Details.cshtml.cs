using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public DetailsModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
        .Include(s => s.Subscriptions)
        .ThenInclude(e => e.Product)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.ID == id);

             if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
