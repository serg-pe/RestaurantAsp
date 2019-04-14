using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using RestaurantAsp.Models;

namespace RestaurantAsp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(
            ApplicationDbContext context, 
            IPasswordHasher<IdentityUser> passwordHasher)
        {
            context.Database.EnsureCreated();
            
            foreach (var roleName in RolesNames.GetAllRoles())
            {
                if (!context.Roles.Any(role => role.Name == roleName))
                    context.Roles.Add(new IdentityRole() {Name = roleName});

                context.SaveChanges();
            }

            if (!context.Users.Any(user => user.UserName == "admin"))
            {
                var admin = new IdentityUser()
                {
                    UserName = "admin@admin.admin",
                    NormalizedUserName = "admin@admin.admin",
                    Email = "admin@admin.admin",
                    PasswordHash = "admin",
                    NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                };
                admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");
                context.Users.Add(admin);

                context.SaveChanges();

                var adminRoleId = context.Roles.First(role => role.Name == Roles.Admin.GetRoleName()).Id;
                var adminId = context.Users.First(user => user.UserName == "admin").Id;
                context.UserRoles.Add(new IdentityUserRole<string>()
                {
                    RoleId = adminRoleId, 
                    UserId = adminId
                });
                context.SaveChanges();

            }

        }

    }
}