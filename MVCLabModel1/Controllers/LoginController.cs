using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YandM.Models;
using YandM.Dal;
using System.Data.Entity.Infrastructure;

namespace YandM.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        public ActionResult Verify()
        {  
            string rcvUserName = Request.Form["user.UserName"];
            string rcvPassword = Request.Form["user.UserPassword"];
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
                Session["signedin"] = usrobj[0];
                return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));
            }
            ViewBag.message = "Wrong user name or password pls try again";
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session["signedin"] = null;
            Session["isadmin"] = false;

            return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));

        }
        public ActionResult SubmitSignup()
        {           
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
                try
                {
                    dal.users.Add(userobj);
                    dal.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    UsersVM passthis = new UsersVM();
                    passthis.user = userobj;
                    dal.users.Remove(userobj);
                    ViewBag.username = "this user name is already taken choose another";
                    return View("Signup", passthis);
                }
                
            }

            return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));
           
        }
    }
   
}