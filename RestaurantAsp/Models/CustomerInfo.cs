using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace RestaurantAsp.Models
{
    public class CustomerInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(11), Column(TypeName = "DECIMAL(11)")]
        public decimal PhoneNumber { get; set; }
        public string Address { get; set; }

        public CustomerInfo()
        {
        }
    }
}