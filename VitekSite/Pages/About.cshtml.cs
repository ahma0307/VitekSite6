using VitekSite.Models.BusinessViewModels;
using VitekSite.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitekSite.Models;
using VitekSite;

namespace VitekSite.Pages
{
    public class AboutModel : PageModel
    {
        private readonly BussinessContext _context;

        public AboutModel(BussinessContext context)
        {
            _context = context;
        }

        public IList<SubscriptionDateGroup> Customers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<SubscriptionDateGroup> data =
                from customer in _context.Customers
                group customer by customer.SubscriptionDate into dateGroup
                select new SubscriptionDateGroup()
                {
                    SubscriptionDate = dateGroup.Key,
                    CustomerCount = dateGroup.Count()
                };

            Customers = await data.AsNoTracking().ToListAsync();
        }
    }
}