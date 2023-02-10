using BackProject.DAL;
using BackProject.Helpers.Extension;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Linq;

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
            var category = _appDbContext.Category.ToList();
            _appDbContext.SaveChanges();
            return View(category);
        }

        public IActionResult Create()
        {
            ViewBag.Course = new SelectList(_appDbContext.Courses.ToList(), "Id");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            //if (!category.Photo.CheckImage())
            //{
            //    ModelState.AddModelError("Photo", "sekil sec");
            //}
            //if (teacher.Photo.CheckImageSize(1000))
            //{
            //    ModelState.AddModelError("Photo", "olcu boyukdur");
            //}



            Category newCategory = new Category();
           
            newCategory.Name = category.Name;
            _appDbContext.Category.Add(newCategory);
            _appDbContext.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Category category = _appDbContext.Category.Find(id);
            if (category == null) return NotFound();

            //if (System.IO.File.Exists(path))
            //{
            //    System.IO.File.Delete(path);
            //}

            _appDbContext.Category.Remove(category);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Category Category = _appDbContext.Category.Find(id);
            if (Category == null) return NotFound();
            return View(new UpdateCategoryVM {  Name = Category.Name });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateCategoryVM category)
        {
            if (id == null) return NotFound();
            Category existCategory = _appDbContext.Category.Find(id);
            if (existCategory == null) return NotFound();
            //string filename = null;

            //if (teacher.Photo != null)
            //{
            //    string path = Path.Combine(_env.WebRootPath, "img/teacher", existTeacher.ImageUrl);
            //    if (System.IO.File.Exists(path))
            //    {
            //        System.IO.File.Delete(path);
            //    }

            //    if (!teacher.Photo.CheckImage())
            //    {
            //        ModelState.AddModelError("Photo", "sekil sec");
            //    }
            //    if (teacher.Photo.CheckImageSize(1000))
            //    {
            //        ModelState.AddModelError("Photo", "olcu boyukdur");

            //    }
            //    filename = teacher.Photo.SaveImage(_env, "img/teacher");

            //}
        
            existCategory.Name = category.Name;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
