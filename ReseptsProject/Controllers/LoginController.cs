using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ReseptsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using XAct.Messages;

namespace ReseptsProject.Controllers
{
    public class LoginController : Controller
    {
        MyReseptsDBContext db = new MyReseptsDBContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User currentUser, string ReturnUrl)
        {
            

            var user = db.Users.Where(u => u.UserEmail == currentUser.UserEmail && u.Userpassword == currentUser.Userpassword && u.Deleted == false && u.Active == true).FirstOrDefault();

            if (user != null)
            {
                string authority = (bool)user.Authority ? "Admin" : "Member";

                var request = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.UserEmail.ToString()),
                    new Claim(ClaimTypes.Role, authority)
                };

                ClaimsIdentity identity = new ClaimsIdentity(request, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);
                if (!String.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    if ((bool)user.Authority)
                    {
                        return Redirect("/Admin/Index");
                    }
                    else
                    {
                        return Redirect("/Home/Index");
                    }
                }

            }
            
            return View();
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
