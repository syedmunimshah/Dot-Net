using jQuery_In_ASPDotNET_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jQuery_In_ASPDotNET_Core.Controllers
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

        [HttpPost]
        public int Add(int num1, int num2)
        {
            return num1 + num2;

        }
        public int Sub(int num1, int num2)
        {
            return num1 - num2;

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
