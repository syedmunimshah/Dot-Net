using CRUD_Web_API_ASP_DotNET_Core_calling_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD_Web_API_ASP_DotNET_Core_calling_Api.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7155/api/StudentApi";
        private HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentModel> stuednt = new List<StudentModel>();

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<StudentModel>>(result);
                if (data != null)
                {
                    stuednt = data;
                }
            }
            return View(stuednt);
        }
    }
}
