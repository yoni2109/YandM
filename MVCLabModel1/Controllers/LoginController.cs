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
            //AdminDal a = new AdminDal();
            //a.admin.Add(new Admin() { AUserName = "yoni2109" });
            //a.SaveChanges();
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Verify()
        {
            string rcvUserName = Request.Form["User.UserName"];
            string rcvPassword = Request.Form["User.UserPassword"];
            UsersDal dal = new UsersDal();
            List <Users> usrobj =     
               (from y in dal.users
               where y.UserName.Equals(rcvUserName)
                select y).ToList<Users>();

            if(usrobj[0].UserPassword == rcvPassword)
            {
                AdminDal adal = new AdminDal();
                List<Admin> adminlist = (from x in adal.admin where x.AUserName.Equals(rcvUserName) select x).ToList<Admin>();
                if (adminlist.Capacity>0) Session["isadmin"] = true;
                else Session["isadmin"] = false;
                ViewBag.signedin = usrobj[0];
                Session["signedin"] = usrobj[0];
                return View("../Products/Cats");
            }
            ViewBag.message = "Wrong user name or password pls try again";
            return View("Login");
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