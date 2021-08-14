
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DemoStore.Data;
using DemoStore.Dtos;
using DemoStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [Route("user_profile")]
        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserDtoImport user)
        {
            var userModel = mapper.Map<User>(user);

            if (ModelState.IsValid)
            {
                User userCheck = userRepository.FindUser(userModel);

                if (userCheck != null)
                {
                    Authenticate(userCheck); // authentication

                    return RedirectPermanent("~/");
                }

            }
            return View(user);

        }
        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
              new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
              new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
          
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
           
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }


        [Route("registration")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("registration")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserDtoImport model)
        {
            var userModel = mapper.Map<User>(model);
            if (ModelState.IsValid)
            {
                User user = userRepository.FindUser(userModel);
                if (user == null)
                {
                    userRepository.Register(userModel);


                    Authenticate(userModel); 

                    return RedirectToAction("Index", "Product");
                }

            }
            return View(model);
        }


        [Authorize]
        [Route("logout")]
        [HttpGet]
        public  IActionResult Logout()
        {
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectPermanent("~/");
        }

    }


}