using eCommerceApi.Models;
using eCommerceApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly ECommerceContext context;
        public SqlOrderRepository(ECommerceContext context)
        {
            this.context = context;
        }
        public void ChangeOrderStatus(OrderStatus orderStarus,int id)
        {
            this.context.Order.FirstOrDefault(x => x.Id == id).Status=orderStarus;
            this.context.SaveChanges();
        }

        public void CreateOrder(Order order)
        {
            context.Order.Add(order);
            this.context.SaveChanges();
        }

        public ICollection<Order> GetUserOrders(int userId)
        {
            
          List<Order> orders =  context.Order.Where(x=>x.UserId==userId).ToList();
            return orders;
        }

    }
}
