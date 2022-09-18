using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResourceManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.Infrastructure.Data
{
    // Defining an ApplicationDbContext class to interact the program with the database which extends with the DbContext class
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Defining individual database tables based on the Models created
        public DbSet<Category> Categories { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Applying configurations for the class derived from identity user
            builder.ApplyConfiguration(new UserEntityConfiguration());

            // Manual definition for creation of bridge entity
            // Definition of required composite keys and the required relationships
            builder.Entity<OrderLine>().HasKey(x => new { x.OrderID, x.ProductID });
            builder.Entity<OrderLine>().HasOne(x => x.Product).WithMany(x => x.OrderLines).HasForeignKey(p => p.ProductID);
            builder.Entity<OrderLine>().HasOne(x => x.Order).WithMany(x => x.OrderLines).HasForeignKey(o => o.OrderID);

            // Ignoring the unnecessary table creations from identity server
            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Entity<IdentityUser>().ToTable("Staffs");
            builder.Entity<IdentityUserClaim<string>>().ToTable("Claims");

            //Manual creation of Category for testing purposes

            builder.Entity<Category>().HasData(new Category[] {
                new Category
                {
                    ID = "C001",
                    Title = "Food Items",
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    ID = "C002",
                    Title = "Clothing",
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    ID = "C003",
                    Title = "Electronic Appliances",
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    ID = "C004",
                    Title = "Art & Music",
                    CreatedAt = DateTime.Now
                },
                new Category
                {
                    ID = "C005",
                    Title = "Sport Accessories",
                    CreatedAt = DateTime.Now
                }
            });

            // Manual creation of Product for testing purposes
            builder.Entity<Product>().HasData(new Product[] {
                new Product
                {
                    ID = "P001",
                    Name = "Bread",
                    Quantity = 1000,
                    Price = 1.45M,
                    CategoryID = "C001",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P002",
                    Name = "Eggs",
                    Quantity = 500,
                    Price = 4.5M,
                    CategoryID = "C001",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P003",
                    Name = "Polo T-Shirt",
                    Quantity = 25,
                    Price = 7.00M,
                    CategoryID = "C002",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P004",
                    Name = "Regular Jeans",
                    Quantity = 25,
                    Price = 7.45M,
                    CategoryID = "C002",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P005",
                    Name = "Travel Joggers",
                    Quantity = 20,
                    Price = 12M,
                    CategoryID = "C002",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P006",
                    Name = "Samsung Galaxy S22 Ultra",
                    Quantity = 15,
                    Price = 250M,
                    CategoryID = "C003",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P007",
                    Name = "ASUS Zenbook",
                    Quantity = 15,
                    Price = 1250M,
                    CategoryID = "C003",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P008",
                    Name = "Lord of the Ring",
                    Quantity = 15,
                    Price = 18.25M,
                    CategoryID = "C004",
                    CreatedAt = DateTime.Now,
                },
                new Product
                {
                    ID = "P009",
                    Name = "Fender Guitar",
                    Quantity = 12,
                    Price = 100M,
                    CategoryID = "C004",
                    CreatedAt = DateTime.Now,
                    LastModifiedAt = DateTime.Now,
                },
                new Product
                {
                    ID = "P010",
                    Name = "Hockey Stick",
                    Quantity = 15,
                    Price = 125M,
                    CategoryID = "C005",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P011",
                    Name = "Sports Wear",
                    Quantity = 15,
                    Price = 50M,
                    CategoryID = "C005",
                    CreatedAt = DateTime.Now
                },
                new Product
                {
                    ID = "P012",
                    Name = "Gym Hero",
                    Quantity = 20,
                    Price = 75M,
                    CategoryID = "C005",
                    CreatedAt = DateTime.Now
                }
            });
        }
    }

    public class UserEntityConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(255);
        }
    }
}
