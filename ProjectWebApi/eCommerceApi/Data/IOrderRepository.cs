using eCommerceApi.Models;
using eCommerceApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void ChangeOrderStatus(OrderStatus orderStarus,int id);
        public ICollection<Order> GetUserOrders(int useId);
    }
}
