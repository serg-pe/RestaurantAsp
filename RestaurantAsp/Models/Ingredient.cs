using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAsp.Models
{
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }
        [MaxLength(50)]
        public string Denomination { get; set; }
        
        public ICollection<DishIngredient> Composition { get; set; }

        public Ingredient()
        {
        }
    }
}