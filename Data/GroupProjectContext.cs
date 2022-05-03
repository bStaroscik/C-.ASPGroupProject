using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroupProject.Data
{
    public class GroupProjectContext : IdentityDbContext
    {
        public GroupProjectContext (DbContextOptions<GroupProjectContext> options)
            : base(options)
        {

        }
        public DbSet<Reply> Replies { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders {get; set;}
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ApplicationUser> User { get; set; }

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

            builder.Entity<Review>().HasData(
    new Review
    {
        Id = 1,
        User="J Johnson",
        ReviewText = "I would buy this again",
        Rating = 5,
        ProductID = 1


    },
        new Review
        {
            Id = 2,
            User = "Sam E.",
            ReviewText = "I regret my purchase",
            Rating = 3,
            ProductID = 2


        },

            new Review
            {
                Id = 3,
                User = "Unregistered User",
                ReviewText = "This was just what I needed",
                Rating = 5,
                ProductID = 1


            },


            new Review
            {
                Id = 4,
                User = "Arty",
                ReviewText = "Very poor quality",
                Rating = 1,
                ProductID = 2


            },
                      new Review
                      {
                          Id = 5,
                          User = "Arty",
                          ReviewText = "Very poor quality",
                          Rating = 1,
                          ProductID = 3


                      },
                                      new Review
                                      {
                                          Id = 6,
                                          User = "Jules",
                                          ReviewText = "Very high quality",
                                          Rating = 5,
                                          ProductID = 5


                                      }




            );
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

            builder.Entity<Product>().Property(o => o.Price).HasColumnType("decimal(8,2)");

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ProductName = "Rolling Art Cart",
                    Price = 601.99m,
                    ImageName = "RollingArtCart.jpg",
                    Category = "Furnishings"

                },
                new Product
                {
                    Id = 2,
                    ProductName = "Water Colors",
                    Price = 20.99m,
                    ImageName = "WaterColors.jpg",
                    Category = "Supplies"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Professional Oil-Based Colored Pencils",
                    Price = 40.99m,
                    ImageName = "ColoredPencils.jpg",
                    Category = "Supplies"
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Paint Brush Variety Pack",
                    Price = 35.59m,
                    ImageName = "PaintBrush.jpg",
                    Category = "Painting"
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Art Desk Easel",
                    Price = 32.99m,
                    ImageName = "Easel.jpg",
                    Category = "Painting"
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Apron",
                    Price = 10.99m,
                    ImageName = "Apron.jpg",
                    Category = "Supplies"
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Do It Yourself Art Kit",
                    Price = 49.99m,
                    ImageName = "ArtKit.jpg",
                    Category = "DIY"
                }
                );
        }
    }
}
