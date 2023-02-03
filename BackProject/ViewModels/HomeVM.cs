using BackProject.Models;
using System.Collections.Generic;

namespace BackProject.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Slider { get; set; }

        public SliderContent SliderContent { get; set; }

        public List<Course> Course { get; set; }

        public List<NoticeBoard> NoticeBoard { get; set; }
        public List<Upcomming_Events> Upcomming_Events { get; set; }


    }
}
