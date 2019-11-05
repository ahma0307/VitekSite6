using VitekSite.Data;
using VitekSite.Models;
using System;
using System.Linq;

namespace VitekSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BussinessContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer{FirstMidName="Carson",LastName="Alexander",SubscriptionDate=DateTime.Parse("2019-09-01")},
                new Customer{FirstMidName="Meredith",LastName="Alonso",SubscriptionDate=DateTime.Parse("2017-09-01")},
                new Customer{FirstMidName="Arturo",LastName="Anand",SubscriptionDate=DateTime.Parse("2018-09-01")},
                new Customer{FirstMidName="Gytis",LastName="Barzdukas",SubscriptionDate=DateTime.Parse("2017-09-01")},
                new Customer{FirstMidName="Yan",LastName="Li",SubscriptionDate=DateTime.Parse("2017-09-01")},
                new Customer{FirstMidName="Peggy",LastName="Justice",SubscriptionDate=DateTime.Parse("2016-09-01")},
                new Customer{FirstMidName="Laura",LastName="Norman",SubscriptionDate=DateTime.Parse("2018-09-01")},
                new Customer{FirstMidName="Nino",LastName="Olivetto",SubscriptionDate=DateTime.Parse("2019-09-01")}
            };
            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product{ProductID=1050,ProductName="CD-ORD",Price=100},
                new Product{ProductID=4022,ProductName="Intowords",Price=100},
                new Product{ProductID=4041,ProductName="Reading Pen",Price=100},
                new Product{ProductID=1045,ProductName="CD-ORD and Intowords",Price=150},
                new Product{ProductID=3141,ProductName="CD-ORD and Reading Pen",Price=150},
                new Product{ProductID=2021,ProductName="Intowords and Reading Pen",Price=150},
                new Product{ProductID=2042,ProductName="Intowords",Price=100},
                new Product{ProductID=2042,ProductName="CD-ORD and Intowords and Reading Pen",Price=175}
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var subscriptions = new Subscription[]
            {
                new Subscription{CustomerID=1,ProductID=1050,CustomerLoyalty=CustomerLoyalty.A},
                new Subscription{CustomerID=1,ProductID=4022,CustomerLoyalty=CustomerLoyalty.C},
                new Subscription{CustomerID=1,ProductID=4041,CustomerLoyalty=CustomerLoyalty.B},
                new Subscription{CustomerID=2,ProductID=1045,CustomerLoyalty=CustomerLoyalty.B},
                new Subscription{CustomerID=2,ProductID=3141,CustomerLoyalty=CustomerLoyalty.F},
                new Subscription{CustomerID=2,ProductID=2021,CustomerLoyalty=CustomerLoyalty.F},
                new Subscription{CustomerID=3,ProductID=1050},
                new Subscription{CustomerID=4,ProductID=1050},
                new Subscription{CustomerID=4,ProductID=4022,CustomerLoyalty=CustomerLoyalty.F},
                new Subscription{CustomerID=5,ProductID=4041,CustomerLoyalty=CustomerLoyalty.C},
                new Subscription{CustomerID=6,ProductID=1045},
                new Subscription{CustomerID=7,ProductID=3141,CustomerLoyalty=CustomerLoyalty.A},
            };
            foreach (Subscription s in subscriptions)
            {
                context.Subscriptions.Add(s);
            }
            context.SaveChanges();
        }
    }
}
