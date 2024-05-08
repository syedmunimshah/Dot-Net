using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace CrudOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CodeFirstDbContext _codeFirstDbContext;

        public HomeController(ILogger<HomeController> logger , CodeFirstDbContext codeFirstDbContext)
        {
            _logger = logger;
            _codeFirstDbContext = codeFirstDbContext;
        }




        public async Task<IActionResult> List()
        {
           
            if (HttpContext.Session.GetString("SessionStart") != null)
            {
                ViewBag.mySession= HttpContext.Session.GetString("SessionStart");
                var std = await _codeFirstDbContext.Employees.ToListAsync();
                return View(std);
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }


        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                await _codeFirstDbContext.Employees.AddAsync(emp);
                await _codeFirstDbContext.SaveChangesAsync();
                TempData["Message"] = "Add Employee";
                return RedirectToAction("List", "Home");
            }
            else
                ViewBag.Message = "Not Add";
                return View();

        }

        public async Task<IActionResult> Details(int id) 
        {
            var std = await _codeFirstDbContext.Employees.FindAsync(id);
            return View(std);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var emp =await _codeFirstDbContext.Employees.FindAsync(id);
            if (emp!=null) {
                return View(emp);
            }
            return View();
            
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid)
            {
                _codeFirstDbContext.Employees.Update(emp);
                _codeFirstDbContext.SaveChanges();
                TempData["Update"] = "Update Employee";
                return RedirectToAction("List", "Home");
            }
            else
            {
                ViewBag.Message = "Not Update";
                return View();
            }

           

        }




        public async Task<IActionResult> Delete(int id)
        {
           var empp= await _codeFirstDbContext.Employees.FindAsync(id);
            return View(empp);

        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> Deletecon(int id)
        {
            //var emp = await _codeFirstDbContext.Employees.FindAsync(id);
            //var emp = await _codeFirstDbContext.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            var emp = await _codeFirstDbContext.Employees.FirstOrDefaultAsync(x=> x.Id == id);
            _codeFirstDbContext.Remove(emp);
              _codeFirstDbContext.SaveChanges();
            TempData["Delete"] = "Delete Employee";
            return RedirectToAction("List", "Home");

        }



        public IActionResult Login()

        {
            if (HttpContext.Session.GetString("SessionStart") != null)
            {
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpPost]

        public IActionResult Login(Employee emp)
        {
            var std = _codeFirstDbContext.Employees.Where(x => x.Email == emp.Email && x.Password == emp.Password).FirstOrDefault();
            if (std != null)
            {
                HttpContext.Session.SetString("SessionStart", std.Name);
                return RedirectToAction("List", "Home");
            }
            else {
                ViewBag.Message = "Login Fail";
            }
            return View();
        }


        public IActionResult logout()
        {

            if (HttpContext.Session.GetString("SessionStart") != null)
            {
                HttpContext.Session.Remove("SessionStart");
                return RedirectToAction("Login");
            }
        
            return View();
        }

        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Register(Employee emp)
        {
            if (ModelState.IsValid)
            {
                await _codeFirstDbContext.Employees.AddAsync(emp);
                await _codeFirstDbContext.SaveChangesAsync();
                TempData["Message"] = "Add Employee";
                return RedirectToAction("List", "Home");
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
