using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DropDown.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly CodeFirstDbContext _codeFirstDbContext;

        public HomeController( CodeFirstDbContext codeFirstDbContext)
        {
           
            _codeFirstDbContext = codeFirstDbContext;
        }




        public IActionResult Index()
        {
            StudentModel Stdmodel = new StudentModel();
            Stdmodel.StudentList =new List<SelectListItem>();

            var data=_codeFirstDbContext.Employees.ToList();

            Stdmodel.StudentList.Add(new SelectListItem {
                Text = "Select Name",
                Value = ""
            });

            foreach (var item in data)
            {
                Stdmodel.StudentList.Add(new SelectListItem
                {
                    Text=item.Name,
                    Value=item.Id.ToString()
                });
            }
            return View(Stdmodel);
        }






        //public async Task<IActionResult> List()
        //{
        //    var std = await _codeFirstDbContext.Employees.ToListAsync();
        //    return View(std);
        //}

        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}
        //[HttpPost]

        //public async Task<IActionResult> Create(Employee emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _codeFirstDbContext.Employees.AddAsync(emp);
        //        await _codeFirstDbContext.SaveChangesAsync();
        //        return RedirectToAction("List", "home");
        //    }

        //    return View(emp);
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    //var std = await _codeFirstDbContext.Employees.FindAsync(id);
        //    var std = await _codeFirstDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        //    return View(std);
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var std = await _codeFirstDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        //    return View(std);
        //}
        //[HttpPost]
        //public IActionResult Edit(int id, Employee emp)
        //{
        //          _codeFirstDbContext.Employees.Update(emp);
        //          _codeFirstDbContext.SaveChangesAsync();
        //          return RedirectToAction("List", "home");

        //}
        //public async Task< IActionResult> Delete(int id)
        //{
        //    var std = await _codeFirstDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        //    return View(std);

        //}
        //[HttpPost,ActionName("Delete")]

        //public async Task<IActionResult> Deletecon(int id)
        //{
        //    var std = await _codeFirstDbContext.Employees.FindAsync(id);
        //    _codeFirstDbContext.Employees.Remove(std);
        //    _codeFirstDbContext.SaveChangesAsync();

        //    return RedirectToAction("List", "home");

        //}




































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
