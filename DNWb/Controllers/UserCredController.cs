using Bulky.DataAccess.Repo.IRepo;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNWb.Controllers
{
    public class UserCredController : Controller
    {
        public readonly IUnitOfWork _db;
        public UserCredController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult LogIn()
        {
            
            return View();
        }

        public IActionResult LogIn(UserModel usr)
        {
            bool isValid = _db.userModel.GetAll().Any(x => x.UserName == usr.UserName && x.Password == usr.Password);

            if (isValid)
            {
                
            }
            return View();
        }
    }
}
