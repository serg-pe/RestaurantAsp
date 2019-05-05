using System;

namespace RestaurantAsp.Models
{
    public class PaginationViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public PaginationViewModel(int count, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.TotalPages = (int) Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPrevious()
        {
            return PageNumber > 1;
        }

        public bool HasNext()
        {
            return PageNumber < TotalPages;
        }
    }
}