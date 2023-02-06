using BackProject.Models;
using System.Collections.Generic;

namespace BackProject.ViewModels
{
    public class CourseVM
    {
        public Slider Slider { get; set; }

        public List<Course> Course { get; set; }
    }
}
