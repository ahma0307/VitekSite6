using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VitekSite.Models;

namespace VitekSite.Data
{
    public class BussinessContext : DbContext
    {
        public BussinessContext (DbContextOptions<BussinessContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Course");
            modelBuilder.Entity<Subscription>().ToTable("Enrollment");
            modelBuilder.Entity<Customer>().ToTable("Student");
        }

        public DbSet<VitekSite.Models.Customer> Customer { get; set; }
    }
}
