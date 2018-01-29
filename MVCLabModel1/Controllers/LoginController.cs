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
        public ActionResult Verify()//action result for logging in
        {  
            string rcvUserName = Request.Form["user.UserName"];
            string rcvPassword = Request.Form["user.UserPassword"];
            UsersDal dal = new UsersDal();
            List <Users> usrobj =     
               (from y in dal.users
               where y.UserName.Equals(rcvUserName)
                select y).ToList<Users>();
            if(usrobj.Count > 0 && usrobj[0].UserPassword == rcvPassword) //checks for password equality in db
            {
                AdminDal adal = new AdminDal();
                List<Admin> adminlist = (from x in adal.admin where x.AUserName.Equals(rcvUserName) select x).ToList<Admin>();//checking if loged user is admin
                if (adminlist.Count>0) Session["isadmin"] = true;
                else Session["isadmin"] = false;
                Session["signedin"] = usrobj[0];
                return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));//returns to home page and loading products
            }
            ViewBag.message = "Wrong user name or password pls try again";// the login form will check for that message if called
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session["signedin"] = null;
            Session["isadmin"] = false;
            return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));//returns to home page and loading products

        }
        public ActionResult SubmitSignup()//action result for submiiting signup form
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
                dal.users.Add(userobj);
                try
                {
                    dal.SaveChanges();
                }
                catch(DbUpdateException)
                {
                    UsersVM passthis = new UsersVM(); //expecting for key violation exception coused by trying to signup with username which alrady exists
                    passthis.user = userobj;
                    dal.users.Remove(userobj);
                    ViewBag.username = "this user name is already taken choose another";
                    return View("Signup", passthis);//recalling signup view and passing the information user submitted to the form
                }                
            }
            return View("../Home/ShowHomePage", (new ProductsVM() { products_list = (new ProductsDal().products.ToList()) }));//returns to home page and loading products if sign up succeded

        }
    }
   
}