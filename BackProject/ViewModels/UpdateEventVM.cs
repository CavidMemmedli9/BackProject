using Microsoft.AspNetCore.Http;

namespace BackProject.ViewModels
{
    public class UpdateEventVM
    {
        public string Title { get; set; }

        public string Desc { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Photo { get; set; }
    }
}
