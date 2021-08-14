using DemoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoStore.Data
{
    public interface IUserRepository
    {
        public void Register(User user);
        public User FindUser(User user);
    }
}
