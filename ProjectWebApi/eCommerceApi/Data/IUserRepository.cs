using eCommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public interface IUserRepository
    {
        public string Login(User user);
        public void Register(User user);
    }
}
