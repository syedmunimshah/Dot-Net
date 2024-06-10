using ImageUploadingAndRetrievingDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploadingAndRetrievingDatabase.Controllers
{
    public class ProductController : Controller
    {
        private readonly ImageDbContext _ImageDbContext;
        IWebHostEnvironment _env ;
        public ProductController(ImageDbContext imageDbContext, IWebHostEnvironment env)
        {
            _ImageDbContext = imageDbContext;
            _env = env;

        }
        public IActionResult Index()
        {
            return View(_ImageDbContext.Products.ToList());
        }
        public IActionResult AddProduct() {
        return View();
                }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel prod)
        {
            string filename = "";
            if(prod.Photo!= null)
            {
                var ext = Path.GetExtension(prod.Photo.FileName);
                var size = prod.Photo.Length;
                if(ext.Equals(".png") ||ext.Equals(".jpg") || ext.Equals("jpeg"))
                {
                    //1MB=1000000bytes
                    if (size <= 1000000)
                    {


                        string folder = Path.Combine(_env.WebRootPath, "images");
                        filename = Guid.NewGuid().ToString() + "_" + prod.Photo.FileName;
                        string filepath = Path.Combine(folder, filename);
                        prod.Photo.CopyTo(new FileStream(filepath, FileMode.Create));

                        Product p = new Product()
                        {
                            Name = prod.Name,
                            Price = prod.Price,
                            Image = filename
                        };
                        _ImageDbContext.Products.Add(p);
                        _ImageDbContext.SaveChanges();
                        TempData["Success"] = "Product Added..";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Size Error"] = "Size must be less than 1 MB";
                    }
                }
                else
                {
                    TempData["Ext_Error"] = "Only PNG,JPG,JPEG Images Allows";
                }
            }

            return View();
        }

    }
}
