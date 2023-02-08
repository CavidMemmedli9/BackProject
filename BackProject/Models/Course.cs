using System.Collections.Generic;

namespace BackProject.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Desc { get; set; }

        public List<Feature> Feature { get; set; }
    }
}
