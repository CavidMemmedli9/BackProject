using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public BlogViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Latest_From_Blog> Latest_From_Blog = _appDbContext.Latest_From_Blog.Take(3).ToList();
            return View(await Task.FromResult(Latest_From_Blog));
        }
    }
}