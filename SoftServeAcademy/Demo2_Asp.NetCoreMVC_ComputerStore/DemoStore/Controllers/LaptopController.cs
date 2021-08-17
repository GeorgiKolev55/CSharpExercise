using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{

    [Route("laptop")]
    public class LaptopController : Controller
    {
        private readonly IProductRepository productRepository;
        public LaptopController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var laptopProducts = this.productRepository.GetAll(ProductType.laptop);

            return View(laptopProducts);
        }
    }
}