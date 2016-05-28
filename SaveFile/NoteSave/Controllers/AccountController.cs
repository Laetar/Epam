using NoteSave.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Web.Mvc;
using System.Web.Security;

namespace NoteSave.Controllers
{
    public class AccountController : Controller
    {

        UserDAL myUserDAL = new UserDAL(ConnectionString.GetConnectionString());

        public ActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                int userId = myUserDAL.GetUserId(User.Identity.Name);
                Request.Cookies.Remove(userId.ToString());
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index", "Home");
        }

        #region LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLogViewModel userAndPassword, string returnUrl)
        {
            if (myUserDAL.CheckUser(userAndPassword.User,userAndPassword.Password))
            {
                FormsAuthentication.SetAuthCookie(userAndPassword.User,false);

                return RedirectToAction("Index", "Home");
            }

            return View(userAndPassword);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserLogViewModel userAndPassword)
        {
            if (myUserDAL.RegistrationUser(userAndPassword.User, userAndPassword.Password))
            {
                FormsAuthentication.SetAuthCookie(userAndPassword.User, false);
                return RedirectToAction("Index", "Home");
            }
            else return View(userAndPassword);
        }

        #endregion
    }
}