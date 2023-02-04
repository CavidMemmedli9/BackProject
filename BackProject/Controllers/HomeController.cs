using BackProject.DAL;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM();
            homeVM.Slider = _context.Sliders.ToList();
            homeVM.SliderContent = _context.SliderContents.FirstOrDefault();
            homeVM.NoticeBoard=_context.NoticeBoard.ToList();
            homeVM.Course = _context.Courses.Take(3).ToList();
            homeVM.Upcomming_Events = _context.Upcomming_Events.ToList();
            homeVM.Latest_From_Blog = _context.Latest_From_Blog.Take(3).ToList();
            return View(homeVM);
        }

       

    }
}
