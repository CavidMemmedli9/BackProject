using BackProject.DAL;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM();
            //aboutVM.Navbar = _context.Navbar.ToList();
            aboutVM.Teachers = _context.Teachers.Take(4).ToList();
            return View(aboutVM);
        }
    }
}
