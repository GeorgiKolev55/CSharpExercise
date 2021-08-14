using DemoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly DemoStoreContext storeContext;
        public AdministratorRepository(DemoStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void AddProduct(Product product)
        {
            Product dbProduct = storeContext.Products.FirstOrDefault(p => p.Name == product.Name);

            if (dbProduct == null)
            {
                storeContext.Products.Add(product);

                storeContext.SaveChanges();
            }
            else
            {
                //increasing the quantity of the product if exist
                storeContext.Products.FirstOrDefault(p => p.Name == product.Name).Quantity += product.Quantity;

                storeContext.SaveChanges();
            }
        }

        public bool RemoveUser(User user)
        {
            var dbUser = storeContext.Users.Single(x => x.Username == user.Username);

            if (dbUser != null)
            {
                storeContext.Users.Remove(dbUser);
                storeContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
