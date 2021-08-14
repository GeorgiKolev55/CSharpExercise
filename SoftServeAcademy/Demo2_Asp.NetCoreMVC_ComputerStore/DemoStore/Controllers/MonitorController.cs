using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{
    [Route("monitor")]
    public class MonitorController : Controller
    {

        private readonly IProductRepository productRepository;
        public MonitorController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        [Route("")]
        public IActionResult Index()
        {
            var productType = "monitor";

            var monitorProducts = productRepository.GetAll(productType); 

            return View(monitorProducts);
        }
    }
}