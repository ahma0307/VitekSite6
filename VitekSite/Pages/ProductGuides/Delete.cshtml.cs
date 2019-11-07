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
    public class DeleteModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public DeleteModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductGuide = await _context.ProductGuides.FindAsync(id);

            if (ProductGuide != null)
            {
                _context.ProductGuides.Remove(ProductGuide);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
