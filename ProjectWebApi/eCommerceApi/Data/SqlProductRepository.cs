using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly ECommerceContext context;
        public SqlProductRepository(ECommerceContext context)
        {
            this.context = context;
            
        }
        public void CreateProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
             Product toDelete= context.Products.FirstOrDefault(x => x.Id == id);
            this.context.Products.Remove(toDelete);
            this.context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProdcts()
        {
            return this.context.Products;
        }

        public Product GetProduct(int id)
        {
            return this.context.Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
