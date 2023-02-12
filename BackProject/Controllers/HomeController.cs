using BackProject.DAL;
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace BackProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            HomeVM homeVM = new HomeVM();
            homeVM.Slider = _context.Sliders.ToList();
            homeVM.NoticeBoard=_context.NoticeBoard.ToList();
            homeVM.Course = _context.Courses.Take(3).ToList();
            homeVM.Upcomming_Events = _context.Upcomming_Events.ToList();
            homeVM.Latest_From_Blog = _context.Latest_From_Blog.Take(3).ToList();
            return View(homeVM);
        }

        public async Task<IActionResult> SendEmail(string email)
        {
            try
            {
                var fromAddress = new MailAddress("javidsm@code.edu.az", "Edu Home");
                var toAddress = new MailAddress(email);
                const string fromPassword = "ukyjpnuqurolhjvb";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Hello",
                    Body = $"Thanks Subscribe"
                })
                {
                    await smtp.SendMailAsync(message);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

    }
}
