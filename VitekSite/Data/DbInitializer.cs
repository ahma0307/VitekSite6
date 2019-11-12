using VitekSite.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VitekSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BussinessContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any customers.
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
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();

            var productGuides = new ProductGuide[]
            {
                new ProductGuide { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new ProductGuide { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new ProductGuide { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new ProductGuide { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new ProductGuide { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (ProductGuide pg in productGuides)
            {
                context.ProductGuides.Add(pg);
            }
            context.SaveChanges();


            var markets = new Market[]
           {
                new Market { Name = "England",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ProductGuideID  = productGuides.Single( pg => pg.LastName == "Abercrombie").ID },
                new Market { Name = "Danmark", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                   ProductGuideID  = productGuides.Single( pg => pg.LastName == "Fakhouri").ID },
                new Market { Name = "Rusland", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ProductGuideID  = productGuides.Single( pg => pg.LastName == "Harui").ID },
                new Market { Name = "Sverige",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ProductGuideID  = productGuides.Single( pg => pg.LastName == "Kapoor").ID }
           };
            foreach (Market m in markets)
            {
                context.Markets.Add(m);

            }
            context.SaveChanges();

            var products = new Product[]
           {
                new Product{ProductID=1050,ProductName="CD-ORD",Price=100,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=4022,ProductName="Intowords",Price=100,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=4041,ProductName="Reading Pen",Price=100,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=1045,ProductName="CD-ORD and Intowords",Price=150,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=3141,ProductName="CD-ORD and Reading Pen",Price=150,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=2021,ProductName="Intowords and Reading Pen",Price=150,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
                new Product{ProductID=2042,ProductName="Intowords",Price=100,
                 MarketID = markets.Single( s => s.Name == "England").MarketID
                },
           };


            //foreach (Product p in products)
            //{
            //    context.Products.Add(p);
            //}
            // Istedet for det udkommenterede foreach loop brug følgende linje:
            context.AddRange(products);

            context.SaveChanges();

            var countryAssignments = new CountryAssignment[]
         {
                new CountryAssignment {
                    ProductGuideID = productGuides.Single( pg => pg.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new CountryAssignment {
                   ProductGuideID = productGuides.Single( pg => pg.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new CountryAssignment {
                    ProductGuideID = productGuides.Single( pg => pg.LastName == "Kapoor").ID,
                    Location = "Odense vej 23 DK" },
         };

            foreach (CountryAssignment ca in countryAssignments)
            {
                context.CountryAssignments.Add(ca);
            }
            context.SaveChanges();

            var productProductGuides = new ProductAssignment[]
            {
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "CD-ORD" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Kapoor").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "CD-ORD" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Harui").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "CD-ORD" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Zheng").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "CD-ORD" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Zheng").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "Intoword" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Fakhouri").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "Intoword" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Harui").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "Intoword" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Abercrombie").ID
                    },
                new ProductAssignment {
                    ProductID = products.Single(p => p.ProductName == "Intoword" ).ProductID,
                    ProductGuideID = productGuides.Single(pg => pg.LastName == "Abercrombie").ID
                    },
            };
            foreach (ProductAssignment pa in productProductGuides)
            {
                context.ProductAssignments.Add(pa);
            }
            context.SaveChanges();
            var subscriptions = new Subscription[]
            {
                new Subscription{
                   CustomerID = customers.Single(c => c.LastName == "Alexander").ID,
                    ProductID = products.Single(p => p.ProductName == "Intowords" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.C
                },

                     new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Alexander").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.C
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Alexander").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                        CustomerID = customers.Single(s => s.LastName == "Alonso").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                        CustomerID = customers.Single(s => s.LastName == "Alonso").ID,
                    ProductID = products.Single(c => c.ProductName == "Intowords" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Alonso").ID,
                    ProductID = products.Single(c => c.ProductName == "Intowords" ).ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Anand").ID,
                    ProductID = products.Single(c => c.ProductName == "Intowords" ).ProductID
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Anand").ID,
                    ProductID = products.Single(c => c.ProductName == "Intowords").ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Barzdukas").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD").ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Li").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD").ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    },
                    new Subscription {
                    CustomerID = customers.Single(s => s.LastName == "Justice").ID,
                    ProductID = products.Single(c => c.ProductName == "CD-ORD").ProductID,
                    CustomerLoyalty = CustomerLoyalty.B
                    }
            };

            foreach (Subscription s in subscriptions)
            {
                var enrollmentInDataBase = context.Subscriptions.Where(
                    c =>
                            c.Customer.ID == s.CustomerID &&
                            c.Product.ProductID == s.ProductID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Subscriptions.Add(s);
                }
            }
            context.SaveChanges();
        }
    }
}