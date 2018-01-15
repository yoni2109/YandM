using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YandM.Models;
using YandM.Dal;

namespace MVCLabModel1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Submit()
        {
            UsersVM cvm = new UsersVM();
            Users userobj = new Users();
            UsersDal dal = new UsersDal();

            userobj.FirstName = Request.Form["User.FirstName"];
            userobj.LastName = Request.Form["User.LastName"];
            userobj.UserPN = Request.Form["User.UserPN"];
            userobj.UserName = Request.Form["User.UserName"];
            userobj.UserEmail = Request.Form["User.UserEmail"];
            userobj.UserPassword = Request.Form["User.UserPassword"];

            if (ModelState.IsValid)
            {
                dal.users.Add(userobj);
                dal.SaveChanges();
                cvm.user = new Users();
            }
            else
                cvm.user = userobj;


            cvm.users_list = dal.users.ToList<Users>();

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
           
        }
    }
}