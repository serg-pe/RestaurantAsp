using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAsp.Models
{
    public class OrderPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("CustomerId")]
        public Dish Dish { get; set; }
        public int Portions { get; set; }

        public OrderPosition()
        {
        }
    }
}