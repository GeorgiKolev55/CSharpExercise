using eCommerceApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Dtos
{
    public class OrderDtoImport
    {
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime Created_At { get; set; }
    }
}
