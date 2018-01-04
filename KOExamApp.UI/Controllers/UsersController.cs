using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;

namespace KOExamApp.UI.Controllers
{
    public class UsersController : Controller
    {
        private UserManager _um;

        public UsersController()
        {
            _um=new UserManager();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDto user)
        {
            if (!ModelState.IsValid)
            {

                var userInDb = _um.Find(x => x.UserName == user.UserName).First();
                if (user.Password==userInDb.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Check your credentials!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDto user)
        {
            _um.Add(user);
            return RedirectToAction("Index", "Home");
        }
    }
}