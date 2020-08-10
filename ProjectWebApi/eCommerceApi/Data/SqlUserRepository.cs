using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly ECommerceContext context;
        public SqlUserRepository(ECommerceContext context)
        {
            this.context = context;
        }
        public string Login(User user)
        {
           var user2 = context.Users.FirstOrDefault(x=>x.Username==user.Username);
            if (user2==null)
            {
                throw new ArgumentException("Cannot find User");
            }
            return "ok";
        }

        public void Register(User user)
        {
            context.Users.Add(user);
            this.context.SaveChanges();
        }
    }
}
