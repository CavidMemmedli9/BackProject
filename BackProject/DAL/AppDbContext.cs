using BackProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }


        public DbSet<Course> Courses { get; set; }

        public DbSet<NoticeBoard> NoticeBoard { get; set; }

        public DbSet<Upcomming_Events> Upcomming_Events { get; set; }

        public DbSet<Latest_From_Blog> Latest_From_Blog { get; set; }

        public DbSet<Navbar> Navbar { get; set; }

        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
