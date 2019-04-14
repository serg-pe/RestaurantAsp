using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAsp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public new DbSet<IdentityUser> Users { get; set; }
        public new DbSet<IdentityRole> Roles { get; set; }
        public new DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}