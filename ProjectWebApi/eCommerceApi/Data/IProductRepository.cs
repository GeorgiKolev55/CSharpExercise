using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProdcts();
        public Product GetProduct(int id);
        public void CreateProduct(Product product);
        public void DeleteProduct(int id);
    }
}
