using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.Products
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
        ViewData["MarketID"] = new SelectList(_context.Markets, "MarketID", "MarketID");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
