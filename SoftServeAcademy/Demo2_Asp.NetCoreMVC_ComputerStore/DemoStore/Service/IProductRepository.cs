using DemoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public interface IProductRepository
    {
      public  IEnumerable<Product> GetAll(string type);
        public Product FindById(int id);    

        public void DecreaseQuantity(Product p, int Quantity);
        public int Count();
    }
}
