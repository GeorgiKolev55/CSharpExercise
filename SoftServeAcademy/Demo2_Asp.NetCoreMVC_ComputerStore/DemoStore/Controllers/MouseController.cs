using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using DemoStore.Models.Enum;
using Microsoft.AspNetCore.Mvc;



namespace DemoStore.Controllers
{
  
    [Route("mouse")]
    public class MouseController : Controller
    {
        private readonly IProductRepository productRepository;
        public MouseController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            var mouseProducts= productRepository.GetAll(ProductType.mouse);

            return View(mouseProducts);
        }
    }
}