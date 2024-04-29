using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeCodeFirstApproachCrudOperation.Models;
using System.Diagnostics;

namespace PracticeCodeFirstApproachCrudOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StudentDbContext _StudentDbContext;

        public HomeController(ILogger<HomeController> logger, StudentDbContext studentDbContext)
        {
            _logger = logger;
            _StudentDbContext = studentDbContext;
        }

        public async Task <IActionResult> Index()
        {
            var stdData = await _StudentDbContext.Students.ToListAsync();
            return View(stdData);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(StudentModel std)
        {
            var StdData = await _StudentDbContext.Students.AddAsync(std);
            await _StudentDbContext.SaveChangesAsync();
            TempData["Insert"] = "Data...";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var stdData =await _StudentDbContext.Students.FindAsync(id);
            return View(stdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudentModel std)
        {
            var stdData =  _StudentDbContext.Students.Update(std);
             _StudentDbContext.SaveChanges();
            TempData["Edited"] = "Data...";
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task <IActionResult> Details(int id)
        {
            var stdData =await _StudentDbContext.Students.FindAsync(id);
            return View(stdData);
        }
        [HttpGet]
        public async  Task<IActionResult> Delete(int id)
        {
            var stdData = await _StudentDbContext.Students.FirstOrDefaultAsync(x=>x.ID==id);

            return View(stdData);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConf(int id)
        {
            var stdData = await _StudentDbContext.Students.FirstOrDefaultAsync(x=>x.ID==id);
             _StudentDbContext.Remove(stdData);
            await _StudentDbContext.SaveChangesAsync();
            TempData["Deleted"] = "Data...";
            return RedirectToAction("Index", "Home");
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
