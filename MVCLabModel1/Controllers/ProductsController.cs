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
            ProductsDal dal = new ProductsDal();
            List<Products> dproducts = 
                (from y in dal.products
                 where y.type.Equals("Dogs") select y).ToList<Products>();
            if (dproducts.Capacity > 0)
            {
                ViewBag.dogproducts = dproducts;
            }
            else ViewBag.dogproducts = null;
            return View("../Home/ShowHomePage");
        }
        public ActionResult Cats()
        {
            ProductsDal dal = new ProductsDal();
            List<Products> dproducts =
                (from y in dal.products
                 where y.type.Equals("Cats")
                 select y).ToList<Products>();
            if (dproducts.Capacity > 0)
            {
                ViewBag.dogproducts = dproducts;
            }
            else ViewBag.dogproducts = null;
            return View("../Home/ShowHomePage");
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
            productobj.img_url = Request.Form["img_url"];
            productobj.price = Convert.ToInt32(Request.Form["price"]);
            //productobj.productId = Convert.ToInt32(Request.Form["productId"]);
            productobj.description = Request.Form["description"];
            productobj.type = Request.Form["type"];



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
        public ActionResult search()
        {
            
            return View("");
        }
           
    }
}