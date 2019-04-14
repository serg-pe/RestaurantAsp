using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RestaurantAsp.Models
{
    public enum Roles
    {
        Admin,
        User,
    }
    
    public static class RolesNames
    {
        private static readonly Dictionary<Roles, string> Roles = new Dictionary<Roles, string>()
        {
            [Models.Roles.Admin] = "ADMIN",
            [Models.Roles.User] = "USER",
        };
        
        public static string GetRoleName(this Roles role)
        {
            var roleName = Roles[role];
            
            if (roleName == null)
                throw new ArgumentOutOfRangeException(nameof(role), role, null);
            
            return roleName;
        }

        public static HashSet<string> GetAllRoles()
        {
            var roles = new HashSet<string>();
            foreach (var role in Roles.Values)
                roles.Add(role);
            
            return roles;
        }
    }
    
}