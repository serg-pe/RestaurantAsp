using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantAsp.Models;

namespace RestaurantAsp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public new DbSet<IdentityUser> Users { get; set; }
        public new DbSet<IdentityRole> Roles { get; set; }
        public new DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> Compositions { get; set; }
        public DbSet<CustomerInfo> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrdersPositions { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}