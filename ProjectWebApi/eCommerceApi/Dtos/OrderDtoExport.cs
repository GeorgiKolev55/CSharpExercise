using eCommerceApi.Models;
using eCommerceApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Dtos
{
    public class OrderDtoExport
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<Product> Products { get; set; }
      
        public decimal TotalPrice { get; set; }
        
        public OrderStatus Status { get; set; }

    }
}
