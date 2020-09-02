using AutoMapper;
using AutoMapper.Configuration;
using eCommerceApi.Data;
using eCommerceApi.Dtos;
using eCommerceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        
        private readonly IOptions<JwtSettings> options;
        public UserController(IUserRepository repository, IMapper mapper, IOptions<JwtSettings> options)
        {
            this.options = options;
            this.mapper = mapper;
            this.repository = repository;
        }
        [HttpPost("login")]
        public IActionResult Login(UserDtoImport user)
        {

            IActionResult response = Unauthorized();
            var user2 = AuthenticateUser(user);
            if (user2 != null)
            {
                var value = options.Value.Secret;
                var key = Encoding.UTF8.GetBytes(value);
                var tokenHandler = new JwtSecurityTokenHandler();



                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim(ClaimTypes.Name, user2.Id.ToString())
                    }),

                    Expires = DateTime.UtcNow.AddDays(7),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var jwt = tokenHandler.WriteToken(token);
                // var tokenStr = GenerateJSONWebToken(user2);
                response = Ok(new { token=jwt});
            }
            this.repository.Login(user2);
            return response;
        }

     

        private User AuthenticateUser(UserDtoImport user1)
        {
            User u = mapper.Map<User>(user1);
            User toReturn = null;
            if (repository.Login(u) == "ok")
            {
                toReturn = u;
            }
            return toReturn;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDtoImport user)
        {
            User user1 = mapper.Map<User>(user);
            this.repository.Register(user1);
            return Ok();
        }
    }
}
