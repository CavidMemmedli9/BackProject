using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackProject.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
