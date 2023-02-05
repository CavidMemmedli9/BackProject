using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BackProject.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
       
            private readonly AppDbContext _context;

            public NavbarViewComponent(AppDbContext context)
            {
            _context = context;
            }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Navbar> Navbar = _context.Navbar.ToList();
            return View(await Task.FromResult(Navbar));
        }

    }
    
}
