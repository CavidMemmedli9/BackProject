
using BackProject.Models;
using BackProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BackProject.Helpers;
using System.Net.Mail;
using System.Net;

namespace BackProject.Controllers
{
   
    public class AccountController : Controller
    {
        private  readonly UserManager<AppUser> _userManager;
        private readonly  SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser()
            {
                UserName = register.UserName,
                Email = register.Email,
                FullName = register.FullName
            };
            IdentityResult result=await _userManager.CreateAsync(user,register.Password );

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }

            //await _userManager.AddToRoleAsync(user, RolesEnum.Member.ToString());

            return RedirectToAction("login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login,string ReturnUrl)
        {
            if (!ModelState.IsValid) return View();

            AppUser user=await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "email ve yaxud parol sehvdir");
                return View(login);
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("","hesab bloklanib");
                return View(login);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "email ve yaxud parol sehvdir");
                return View(login);
            }

            await _signInManager.SignInAsync(user, login.RememberMe);
            if(ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public  async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(forgetPasswordVM.AppUser.Email);

            if (appUser == null)
            {
                ModelState.AddModelError("Error1", "Bele bir Email Yoxdur");
                return View();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            string url = Url.Action(nameof(ResetPassword), "Account"
                , new { email = appUser.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("javidsm@code.edu.az", "Fiorella");
            mailMessage.To.Add(new MailAddress(appUser.Email));
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = $"<a href='{url}'>Please Click here for Reset Password</a>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;


            smtpClient.Credentials = new NetworkCredential("javidsm@code.edu.az", "ohcbesummefyviux");

            smtpClient.Send(mailMessage);
            return RedirectToAction("Index");
        }

        public IActionResult ResetPassword()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, ForgetPasswordVM forgetPassword, string token)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            if (!ModelState.IsValid) return View();

            await _userManager.ResetPasswordAsync(appUser, token, forgetPassword.Password);

            return RedirectToAction("login", "account");
        }
    }
}