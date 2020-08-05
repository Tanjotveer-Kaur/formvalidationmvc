using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormsAuthenticationProject.Models;
using System.Web.Security;

namespace FormsAuthenticationProject.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User user)
        {
            if(user.Password=="1234")
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Home");
            }
            //ModelState.AddModelError("error", "Invalid username or password");
            ViewBag.ErrorMessage="Invalid username or password";
            return View();

        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();  //clear cookies
            return RedirectToAction("Login");
        }


    }
}