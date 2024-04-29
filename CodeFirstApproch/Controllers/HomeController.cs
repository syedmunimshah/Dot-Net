using CodeFirstApproch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstApproch.Controllers
{
    public class HomeController : Controller
    {


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly StudentDBContext _studentDB;
        public HomeController(StudentDBContext studentDB)
        {
            _studentDB = studentDB;
        }


        public async Task <IActionResult> Index()
        {
            var stdData= await _studentDB.Employees.ToListAsync();
            return View(stdData);
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid) 
            {
                await _studentDB.Employees.AddAsync(emp);
                await _studentDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");

            }

            return View(emp);
        }

        public async Task <IActionResult> Details(int id)
        {
            var stdData = await _studentDB.Employees.FirstOrDefaultAsync(x=> x.Id == id);
            return View(stdData);
        }

      public  async Task<IActionResult> Edit(int id)

        {
            var stdData =await _studentDB.Employees.FindAsync(id);
            return View(stdData);
        }
        [HttpPost]
        public async Task <IActionResult> Edit(int id,Employee emp)

        {
            var stdData =  _studentDB.Employees.Update(emp);
           await _studentDB.SaveChangesAsync(); 
            return RedirectToAction("Index","Home");
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
