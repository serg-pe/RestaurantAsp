using System.Collections;
using System.Collections.Generic;
using RestaurantAsp.Models;

namespace RestaurantAsp.Views.Admin.Data
{
    public class DishData
    {
        public IList<Ingredient> Ingredients { get; set; }
        public Dish Dish { get; set; }
    }
}