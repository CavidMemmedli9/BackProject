using BackProject.DAL;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();

            return View(courses);
        }
    }
}
