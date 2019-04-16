using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using RestaurantAsp.Models;

namespace RestaurantAsp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            foreach (var roleName in RolesNames.GetAllRoles())
            {
                var roleResult = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
                if (roleResult == null)
                {
                    roleManager.CreateAsync(new IdentityRole() {Name = roleName}).Wait();
                }

                context.SaveChanges();
            }

            const string adminName = "admin@admin.admin";
            const string adminEmail = adminName;
            const string adminPassword = "admin_ADMIN_97";
            var adminResult = userManager.FindByNameAsync(adminName).GetAwaiter().GetResult();
            if (adminResult == null)
            {
                var admin = new IdentityUser() {UserName = adminName, Email = adminEmail, SecurityStamp = new Guid().ToString()};
                var h = userManager.CreateAsync(admin, adminPassword).GetAwaiter().GetResult().Errors;

                context.SaveChanges();
                
                admin = userManager.FindByNameAsync(adminName).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(admin, Roles.Admin.GetRoleName()).Wait();
            }

        }

    }

}