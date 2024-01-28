using CarWorkShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarWorkShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
      

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            var model = new About()
            {
                Title = "Shop Car Support",
                Description = "If you have some problem, read this",
                Tags = new[] {"#Shop","#Support","#Car"}
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
