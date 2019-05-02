using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAsp.Models
{
    public class DishIngredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public DishIngredient()
        {
        }
    }
}