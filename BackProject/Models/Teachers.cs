using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;

namespace BackProject.Models
{
    public class Teachers
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }


        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }

        public List<About>About { get; set; }

        public List<SocialPage> SocialPages { get; set; }

    }
}
