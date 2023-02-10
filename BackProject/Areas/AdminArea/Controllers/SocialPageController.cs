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
    public class SocialPageController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public SocialPageController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var pages = _appDbContext.SocialPage.ToList();
            _appDbContext.SaveChanges();
            return View(pages);
        }

        public IActionResult Create()
        {
            ViewBag.Teachers = new SelectList(_appDbContext.Teachers.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Teachers teacher)
        {
            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            if (!teacher.Photo.CheckImage())
            {
                ModelState.AddModelError("Photo", "sekil sec");
            }
            if (teacher.Photo.CheckImageSize(1000))
            {
                ModelState.AddModelError("Photo", "olcu boyukdur");
            }



            Teachers newTeacher = new Teachers();
            newTeacher.ImageUrl = teacher.Photo.SaveImage(_env, "img/teacher");
            newTeacher.Desc = teacher.Desc;
            newTeacher.Name = teacher.Name;
            newTeacher.SocialPages = teacher.SocialPages;
            _appDbContext.Teachers.Add(newTeacher);
            _appDbContext.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Teachers teacher = _appDbContext.Teachers.Find(id);
            if (teacher == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath + "img" + teacher.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _appDbContext.Teachers.Remove(teacher);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Teachers teacher = _appDbContext.Teachers.Find(id);
            if (teacher == null) return NotFound();
            return View(new UpdateTeacherVM { ImageUrl = teacher.ImageUrl, Name = teacher.Name, Desc = teacher.Desc });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateTeacherVM teacher)
        {
            if (id == null) return NotFound();
            Teachers existTeacher = _appDbContext.Teachers.Find(id);
            if (existTeacher == null) return NotFound();
            string filename = null;

            if (teacher.Photo != null)
            {
                string path = Path.Combine(_env.WebRootPath, "img/teacher", existTeacher.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                if (!teacher.Photo.CheckImage())
                {
                    ModelState.AddModelError("Photo", "sekil sec");
                }
                if (teacher.Photo.CheckImageSize(1000))
                {
                    ModelState.AddModelError("Photo", "olcu boyukdur");

                }
                filename = teacher.Photo.SaveImage(_env, "img/teacher");

            }
            existTeacher.ImageUrl = filename ?? existTeacher.ImageUrl;
            existTeacher.Desc = teacher.Desc;
            existTeacher.Name = teacher.Name;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}