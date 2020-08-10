using eCommerceApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public ICollection<Product> Products { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime Created_At { get; set; }
    }
}
