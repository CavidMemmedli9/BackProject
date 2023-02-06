using BackProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = _context.Latest_From_Blog.ToList();
            return View(blogs);
        }
    }
}
