using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoStore.Data;
using DemoStore.Dtos;
using DemoStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{

    [Authorize(Roles = "admin")]
    [Route("admin")]
    public class AdministratorController : Controller
    {
        private readonly IAdministratorRepository adminRepository;
        private readonly IMapper mapper;
        public AdministratorController(IMapper mapper, IAdministratorRepository adminRepository)
        {
            this.adminRepository = adminRepository;
            this.mapper = mapper;

        }

        [Route("admin_profile")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("add_prodict")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [Route("add_prodict")]
        [HttpPost]
        public IActionResult AddProduct(ProductDtoImport product)
        {
            Product mapProduct = mapper.Map<Product>(product);

            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                this.adminRepository.AddProduct(mapProduct);

            }

            return View(product);
        }


        [Route("remove_user")]
        [HttpGet]
        public IActionResult RemoveUser()
        {

            return View();
        }


        [Route("remove_user")]
        [HttpPost]
        public IActionResult RemoveUser(UserDtoImport user)
        {
            User mapUser = mapper.Map<User>(user);

            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {

                this.adminRepository.RemoveUser(mapUser);

            }

            return View(user);
        }
    }
}