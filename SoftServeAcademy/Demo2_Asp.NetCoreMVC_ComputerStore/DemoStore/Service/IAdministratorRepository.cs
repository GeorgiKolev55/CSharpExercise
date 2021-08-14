using DemoStore.Models;

namespace DemoStore.Data
{
    public interface IAdministratorRepository
    {
        public void AddProduct(Product product);
        public bool RemoveUser(User user);
    }
}
