using AutoMapper;
using eCommerceApi.Data;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserController(IUserRepository repository,IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpPost("login")]
        public void Login(UserDtoImport user)
        {
            User user1 = mapper.Map<User>(user);
            
            this.repository.Login(user1);
        }
        [HttpPost("register")]
        public void Register(UserDtoImport user)
        {
            User user1 = mapper.Map<User>(user);
            this.repository.Register(user1);
        }
    }
}
