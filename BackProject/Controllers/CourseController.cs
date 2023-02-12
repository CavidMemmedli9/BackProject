using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var courses = _context.Courses;

            if (search == null)
            {
                return View(courses.ToList());
            }

            var listCourse=courses.Where(c=>c.Title.ToLower().Contains(search.ToLower()));

            return View(listCourse.ToList());
        }

        
        public IActionResult Search(string item)
        {
            List<Course> courses = new List<Course>();
            if( item!=null&& item.Length>1)
            {
                courses= _context.Courses.Where(c=>c.Title.ToLower().Contains(item.ToLower())).ToList();
            }
           
            

            return PartialView("_SearchPartial", courses);


        }
    }
}