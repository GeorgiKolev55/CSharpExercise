using DemoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoStoreContext storeContext;
        public ProductRepository(DemoStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public int Count()
        {
            return this.storeContext.Products.Count();
        }

        public Product FindById(int id)
        {
            var product = this.storeContext.Products
                .Where(x => x.Id == id).FirstOrDefault();

            return product;
        }
        public void DecreaseQuantity(Product cartProduct, int Quantity)
        {
            this.storeContext.Products
                .Where(x => x.Id == cartProduct.Id)
                .FirstOrDefault().Quantity -= Quantity;

            storeContext.SaveChanges();
        }


        public IEnumerable<Product> GetAll(string type)
        {
            foreach (var item in storeContext.Products)
            {
                if (item.Type == type)
                {

                    yield return item;
                }
            }
        }

    }
}
