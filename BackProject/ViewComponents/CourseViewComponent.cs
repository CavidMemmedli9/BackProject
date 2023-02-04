using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewComponents
{
    public class CourseViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public CourseViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Course> Courses = _appDbContext.Courses.Take(3).ToList();
            return View(await Task.FromResult(Courses));
        }
    }
}
