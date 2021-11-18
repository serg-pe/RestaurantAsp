using System.Collections.Generic;

namespace RestaurantAsp.Models
{
    public class MenuViewModel
    {
        public PaginationViewModel Pagination { get; set; }
        public IList<Dish> Dishes { get; set; }
        
    }
}