
using Microsoft.AspNetCore.Mvc;

namespace DemoStore.Controllers
{

    
    public class ProductController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("product_Amount")]
        [HttpGet]
        public IActionResult ProductAmount()
        {
            return View();
        }
    }
}