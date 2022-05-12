using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    public class Login : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(EntityLayer.Concrete.User user)
        {
            Context c = new Context();
            var datavalue = c.Users.FirstOrDefault(x => x.UserName == user.UserName &&
            x.Password == user.Password);

            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name ,user.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Work");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
//Context c = new Context();
//var datavalue = c.Users.FirstOrDefault(x => x.UserName == user.UserName &&
//x.Password == user.Password);
//if (datavalue != null)
//{
//    HttpContext.Session.SetString("username", user.UserName);
//    return RedirectToAction("Index", "Work");

//}
//else
//{
//    return View();
//}