using BackProject.DAL;
using BackProject.Helpers.Extension;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var categories = _appDbContext.Category.ToList();
            _appDbContext.SaveChanges();

            return View(categories);
        }

     
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return View();

            var isExist = _appDbContext.Category
                .Any(c => c.Name.ToLower() == category.Name.ToLower());

            if (isExist)
            {
                ModelState.AddModelError("Name", "this name already exist");
                return View();
            }


            _appDbContext.Category.Add(category);

            _appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Category.Find(id);
            if (category == null) return NotFound();

            //string path = Path.Combine(_env.WebRootPath + "/img" + category.ImageUrl);
            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            _appDbContext.Category.Remove(category);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
