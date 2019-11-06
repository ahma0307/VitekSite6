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
    public class IndexModel : PageModel
    {
        private readonly VitekSite.Data.BussinessContext _context;

        public IndexModel(VitekSite.Data.BussinessContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Customer> Customers { get; set; }
        //public IList<Customer> Customers { get; set; }

        public async Task OnGetAsync(string sortOrder,
           string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Customer> customersIQ = from c in _context.Customers
                                               select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customersIQ = customersIQ.Where(c => c.LastName.Contains(searchString)
                                       || c.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customersIQ = customersIQ.OrderByDescending(c => c.LastName);
                    break;
                case "Date":
                    customersIQ = customersIQ.OrderBy(c => c.SubscriptionDate);
                    break;
                case "date_desc":
                    customersIQ = customersIQ.OrderByDescending(c => c.SubscriptionDate);
                    break;
                default:
                    customersIQ = customersIQ.OrderBy(c => c.LastName);
                    break;
            }
            int pageSize = 3;
         Customers = await PaginatedList<Customer>.CreateAsync(
            customersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            //Customers = await customersIQ.AsNoTracking().ToListAsync();
        }

    

       
    }
}
