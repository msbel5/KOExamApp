using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KOExamApp.BLL.Dtos;
using KOExamApp.BLL.Services;

namespace KOExamApp.UI.Controllers
{
    [HandleError(ExceptionType = typeof(DbUpdateException), View = "Error")]
    public class UsersController : Controller
    {
        private UserManager _um;

        public UsersController()
        {
            _um = new UserManager();
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
                if (_um.Get(user.UserName, user.Password)!=null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Check your credentials!");
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]//for publishing
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