using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public SliderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string text)
        {
            Slider slider = _appDbContext.Sliders.FirstOrDefault();
          
            ViewBag.Text = text;
            return View();
        }
    }
}
