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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders {get; set;}

        public DbSet<GroupProject.Models.Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

          //  builder.Entity<Order>().HasData(
//new Order
//{
//   //ProductID =  ,
//   CustomerID = ,
//   FirstName = "John",
//   LastName = "Jones",
//   Address = "1111 D St",
//   Email = "a@g.com"

//});



            builder.Entity<Customer>().HasData(
    new Customer
    {
        ID = 1,
        UserName = "JJones",
        FirstName = "John",
        LastName = "Jones",
        Address = "1111 D St",
        Email = "a@g.com"

    });

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
