using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

namespace GroupProject.Data
{
    public class GroupProjectContext : DbContext
    {
        public GroupProjectContext (DbContextOptions<GroupProjectContext> options)
            : base(options)
        {
        }

        public DbSet<GroupProject.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(o => o.Price).HasColumnType("decimal(8,2)");

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Product1",
                    Price = 10.99m,
                    Category = "Art"
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Product2",
                    Price = 20.99m,
                    Category = "Art"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Product3",
                    Price = 30.99m,
                    Category = "Art"
                }
                );
        }
    }
}
