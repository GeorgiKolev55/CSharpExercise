using DemoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DemoStoreContext storeContext;
        public UserRepository(DemoStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void Register(User user)
        {                       
                user.Role = "user";
                this.storeContext.Users.Add(user);
                this.storeContext.SaveChanges();                                  
        }
        public User FindUser(User user) {

            return this.storeContext.Users
                .FirstOrDefault(u => u.Username == user.Username);
        }
        
    }
}
