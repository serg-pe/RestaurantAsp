using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAsp.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
//        public ICollection<OrderPosition> OrderPositions { get; set; }
//        public CustomerInfo Customer { get; set; }

        public Order()
        {
        }
    }
}