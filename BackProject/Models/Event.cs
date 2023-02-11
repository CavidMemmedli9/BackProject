using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackProject.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Title { get; set; }

        public string Desc  { get; set; }


        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
