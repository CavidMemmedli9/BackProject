using BackProject.DAL;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        //public IActionResult Search(string item)
        //{
        //    List<About> about = new List<About>();
        //    if (item != null && item.Length > 1)
        //    {
        //        about = _context.About.Where(c => c.Title.ToLower().Contains(item.ToLower())).ToList();
        //    }



        //    return PartialView("_SearchPartial", about);


        //}
    }
}
