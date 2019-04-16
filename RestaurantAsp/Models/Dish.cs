using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantAsp.Models
{
    public class Dish
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Denomination { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "DECIMAL(10, 2)")]
        public decimal Price { get; set; }
        [MaxLength(5)]
        public string Unit { get; set; }
        [Column(TypeName = "DECIMAL(10, 3)")]
        public decimal Quantity { get; set; }
        
        public ICollection<DishIngredient> Composition { get; set; } 

        public Dish()
        {
        }
    }
}