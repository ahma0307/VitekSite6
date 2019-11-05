using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VitekSite.Data;
using VitekSite.Models;

namespace VitekSite.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public EditModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var customerToUpdate = await _context.Customers.FindAsync(id);

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Customer>(
                customerToUpdate,
                "customer",
                c => c.FirstMidName, c => c.LastName, c => c.SubscriptionDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
