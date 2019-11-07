using System;
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
    public class DetailsModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public DetailsModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        public ProductGuide ProductGuide { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductGuide = await _context.ProductGuides.FirstOrDefaultAsync(m => m.ID == id);

            if (ProductGuide == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
