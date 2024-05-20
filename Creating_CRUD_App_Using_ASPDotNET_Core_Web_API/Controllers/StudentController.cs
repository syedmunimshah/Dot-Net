using Creating_CRUD_App_Using_ASPDotNET_Core_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Creating_CRUD_App_Using_ASPDotNET_Core_Web_API.Controllers
{
    public class StudentController : Controller
    {
        private HttpClient client = new HttpClient();
        private readonly string url = "https://localhost:7087/api/StudentApi";



   
        [HttpGet]
   
        public  IActionResult Index()
        {
            List<Stuednt> students = new List<Stuednt>();
            HttpResponseMessage response =  client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Stuednt>>(result);
                if (data !=null) {
                    students = data;
                        }

            }
            return View(students);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stuednt std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added.";
                return RedirectToAction("Index");
            }
            return View(std);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Stuednt std = new Stuednt();
            HttpResponseMessage response = await client.GetAsync(url +id);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Stuednt>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Stuednt std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //HttpResponseMessage response =  client.PutAsync(url + std.id, content).Result;
            HttpResponseMessage response = client.PutAsync(url + "/" + std.id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student Updated.";
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Stuednt std = new Stuednt();
            HttpResponseMessage response = await client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Stuednt>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Stuednt std = new Stuednt();
            HttpResponseMessage response = await client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Stuednt>(result);
                if (data != null)
                {
                    std = data;
                }
            }
            return View(std);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["delete_message"] = "Student Deleted.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
