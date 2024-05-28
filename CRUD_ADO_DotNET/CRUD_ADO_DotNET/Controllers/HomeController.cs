using CRUD_ADO_DotNET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_ADO_DotNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployessDataAccessLayer _employessDataAccessLayer;

        public HomeController(EmployessDataAccessLayer employessDataAccessLayer)
        {
            _employessDataAccessLayer = employessDataAccessLayer;
        }

        public IActionResult Index()
        {
           List<Employess> emps = _employessDataAccessLayer.GetEmployesses();
            return View(emps);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employess emp)
        {
            try
            {
                _employessDataAccessLayer.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
           
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
