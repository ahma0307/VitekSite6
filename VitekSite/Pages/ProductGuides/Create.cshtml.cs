using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.ProductGuides
{
    public class CreateModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public CreateModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductGuide ProductGuide { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProductGuides.Add(ProductGuide);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
