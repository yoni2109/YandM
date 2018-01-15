using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YandM.Models;
using YandM.Dal;

namespace MVCLabModel1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dogs()
        {

            return View("Dogs");
        }
        public ActionResult Cats()
        {
            return View("Cats");
        }
        public ActionResult AddProducts()
        {
            return View("AddProducts");
        }
        public ActionResult Submit()
        {

            Products productobj = new Products();
            ProductsDal dal = new ProductsDal();

            productobj.product_name = Request.Form["product_name"];
            productobj.price = Convert.ToInt32(Request.Form["price"]);
            
            productobj.img_url = Request.Form["img_url"];


            if (ModelState.IsValid)
            {
                dal.products.Add(productobj);
                dal.SaveChanges();
                //cvm.user = new Users();
            }
            //else
                //cvm.user = userobj;


            //cvm.users_list = dal.users.ToList<Users>();

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}