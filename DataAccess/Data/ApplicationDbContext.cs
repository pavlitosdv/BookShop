using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoatingType> CoatingTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                       
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Adventure" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Fiction" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Mistery" });


            modelBuilder.Entity<CoatingType>().HasData(new CoatingType { Id = 2, Name = "Soft Cover" });
            modelBuilder.Entity<CoatingType>().HasData(new CoatingType { Id = 3, Name = "Hard Cover" });

            //seed pies

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Title = "Apple Pie",
                Description = "Our famous apple pies!",
                ISBN = "111 - 111 - 111",
                Author = "George",
                ListPrice= 2,
                Price = 12.95,
                Price50 = 10.5,
                Price100 = 9.1,
                CategoryId = 2,
                CoatingTypeId=2,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg"
            }) ;

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Title = "Book 2 ",
                Description = "Our famous books",
                ISBN = "111 - 111 - 745",
                Author = "George",
                ListPrice = 5,
                Price = 18.95,
                Price50 = 15.5,
                Price100 = 14.1,
                CategoryId = 3,
                CoatingTypeId = 3,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Title = "Test book",
                Description = "Test book",
                ISBN = "111 - 242 - 111",
                Author = "George",
                ListPrice = 7,
                Price = 22.95,
                Price50 = 20.5,
                Price100 = 17.1,
                CategoryId = 2,
                CoatingTypeId = 1,
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg"
            });
                                   
        }
    }
}

