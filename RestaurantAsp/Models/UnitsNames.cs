using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace RestaurantAsp.Models
{
    public enum Units
    {
        Kg,
        Gr,
        L,
        Pcs,
        Ml,
    }
    
    public static class UnitsNames
    {
        private static readonly Dictionary<Units, string> Units = new Dictionary<Units, string>()
        {
            [Models.Units.Kg] = "Кг",
            [Models.Units.Gr] = "Гр",
            [Models.Units.L] = "Л",
            [Models.Units.Pcs] = "Шт",
            [Models.Units.Ml] = "Мл",
        };
        
        public static string GetUnitName(this Units unit)
        {
            var unitName = Units[unit];
            
            if (unitName == null)
                throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            
            return unitName;
        }

        public static HashSet<string> GetAllRoles()
        {
            var units = new HashSet<string>();
            foreach (var role in Units.Values)
                units.Add(role);
            
            return units;
        }
    }
    
}