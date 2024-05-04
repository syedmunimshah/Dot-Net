using LoginFormASPCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace LoginFormASPCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CodeFirstDbContext _codeFirstDbContext;

        public HomeController(ILogger<HomeController> logger, CodeFirstDbContext codeFirstDbContext)
        {
            _logger = logger;
            _codeFirstDbContext = codeFirstDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {

            if (HttpContext.Session.GetString("UserSession") != null)
            {
               return  RedirectToAction("Dashboard");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(Employee emp)
        {
            var empData = _codeFirstDbContext.Employees.Where(x => x.Email == emp.Email && x.Password == emp.Password).FirstOrDefault();
            if (empData != null) {
                HttpContext.Session.SetString("UserSession",empData.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Fail";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") !=null) 
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null) 
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]

        public async Task <IActionResult> Register(Employee emp)
        {
            if (ModelState.IsValid)
            {
                 await _codeFirstDbContext.Employees.AddAsync(emp);
                await _codeFirstDbContext.SaveChangesAsync();
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login", "Home");
            }
            return View();
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
