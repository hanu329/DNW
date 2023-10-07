using Bulky.DataAccess.Repo.IRepo;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace DNWb.Controllers
{
    public class AccessController : Controller
    {
        public readonly IUnitOfWork _db;
        public AccessController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult LogIn()
        {

               
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserModel usr)
        {
            bool isValid = _db.userModel.GetAll().Any(x => x.UserName == usr.UserName && x.Password == usr.Password);

            if (isValid)
            {
                List<Claim> cl = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, usr.UserName),
                    new Claim("demo", "demo1"),
                };
                ClaimsIdentity clI = new ClaimsIdentity(cl, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties prop = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                   IsPersistent = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(clI));
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public IActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel usr)
        {
                  _db.userModel.Add(usr);
                  _db.Save();
           
                return RedirectToAction("LogIn");
            

        }

        public async Task<IActionResult> SignOut(UserModel usr)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("LogIn");


        }
    }
}
