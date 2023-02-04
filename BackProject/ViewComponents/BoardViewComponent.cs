using BackProject.DAL;
using BackProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackProject.ViewComponents
{
    public class BoardViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public BoardViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<NoticeBoard> NoticeBoard = _appDbContext.NoticeBoard.ToList();
            return View(await Task.FromResult(NoticeBoard));
        }

    }
}
