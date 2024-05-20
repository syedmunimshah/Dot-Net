using Microsoft.AspNetCore.Mvc;
using Partial_view.Models;
using System.Diagnostics;

namespace Partial_view.Controllers
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

        public IActionResult Product()
        {
            List<ProductModel> product = new List<ProductModel> {

                new ProductModel{Id=1,Name="NIke1",describtion="Describtion1",Price=100000,Image="~/Image/1.jpg"},
                new ProductModel{Id=2,Name="Nike2",describtion="Describtion2",Price=200000,Image="~/Image/2.jpg"},
                new ProductModel{Id=3,Name="NIke3",describtion="Describtion3",Price=300000,Image="~/Image/3.jpg"},
                new ProductModel{Id=1,Name="NIke4",describtion="Describtion4",Price=400000,Image="~/Image/4.jpg"},
            };
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
