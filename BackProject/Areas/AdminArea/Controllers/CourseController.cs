using BackProject.DAL;
using BackProject.Helpers.Extension;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace BackProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CourseController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public CourseController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var course = _appDbContext.Courses.Include(x=>x.Category).ToList();
            _appDbContext.SaveChanges();
            return View(course);
        }

        public IActionResult Create()
        {
            ViewBag.Categories=new SelectList(_appDbContext.Category.ToList(),"Id","Name");
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Course course)
        {

            ViewBag.Categories = new SelectList(_appDbContext.Category.ToList(), "Id", "Name");


            if (!ModelState.IsValid) return View();


            if (ModelState["Photo"].ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }
            //if (!item.Photo.CheckImage())
            //{
            //    ModelState.AddModelError("Photo", "sekil sec");
            //}
            //if (Course.Photo.CheckImageSize(1000))
            //{
            //    ModelState.AddModelError("Photo", "olcu boyukdur");
            //}


            Course newCourse = new Course();
            newCourse.ImageUrl = course.ImageUrl;
            newCourse.Title = course.Title;
            newCourse.Desc = course.Desc;
            newCourse.CategoryId = course.CategoryId;

            //newCourse.Name = Course.Name;
            //newCourse.SocialPages = teacher.SocialPages;
            _appDbContext.Courses.Add(newCourse);
            _appDbContext.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            Course courses = _appDbContext.Courses.Find(id);
            if (courses == null) return NotFound();

            string path = Path.Combine(_env.WebRootPath + "img" + courses.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            _appDbContext.Courses.Remove(courses);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id == null) return NotFound();
            Course course = _appDbContext.Courses.Find(id);
            if (course == null) return NotFound();
            return View(new UpdateTeacherVM { ImageUrl = course.ImageUrl, Desc = course.Desc });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Update(int? id, UpdateTeacherVM teacher)
        {
            if (id == null) return NotFound();
            Course existCourse = _appDbContext.Courses.Find(id);
            if (existCourse == null) return NotFound();
            string filename = null;

            if (teacher.Photo != null)
            {
                string path = Path.Combine(_env.WebRootPath, "img/course", existCourse.ImageUrl);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                //if (!teacher.Photo.CheckImage())
                //{
                //    ModelState.AddModelError("Photo", "sekil sec");
                //}
                //if (teacher.Photo.CheckImageSize(1000))
                //{
                //    ModelState.AddModelError("Photo", "olcu boyukdur");

                //}
                //filename = teacher.Photo.SaveImage(_env, "img/teacher");

            }
            existCourse.ImageUrl = filename ?? existCourse.ImageUrl;
            existCourse.Desc = teacher.Desc;
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
