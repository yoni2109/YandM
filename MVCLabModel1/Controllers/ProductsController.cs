using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YandM.Models;
using YandM.Dal;
using System.Data.Entity.Infrastructure;

namespace MVCLabModel1.Controllers
{
    public class ProductsController : Controller
    {

        public ActionResult Dogs()//called when clicking the "dogs" label on page Layout
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.products_list =
                (from y in dal.products
                 where y.type.Equals("Dogs")
                 select y).ToList<Products>();
            return View("../Home/ShowHomePage", productsV);// returns Home page with list of products from Dogs type
        }
        public ActionResult Cats()//called when clicking the "cats" label on page Layout
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.products_list =
                (from y in dal.products
                 where y.type.Equals("Cats")
                 select y).ToList<Products>();

            return View("../Home/ShowHomePage", productsV);// returns Home page with list of products from Cats type
        }
        public ActionResult AddProducts()//called when manager clicks the Add product to catalog label on page layout and returns a view and sending the view the products that in db
        {
            bool admin = Convert.ToBoolean(Session["isadmin"]);
            if (!admin || admin == null)
            {
                return HttpNotFound();
            }
            return View(new ProductsVM() { products_list = (new ProductsDal()).products.ToList<Products>() });
        }
        public ActionResult Submit()//action result for submiiting an add product form (only admin)
        {
            Products productobj = new Products();
            ProductsDal dal = new ProductsDal();
            productobj.product_name = Request.Form["product.product_name"];
            productobj.img_url = Request.Form["product.img_url"];
            productobj.price = Convert.ToInt32(Request.Form["product.price"]);
            productobj.description = Request.Form["product.description"];
            productobj.type = Request.Form["product.type"];
            if (ModelState.IsValid)
            {
                dal.products.Add(productobj);
                try
                {
                    dal.SaveChanges();
                }
                catch(DbUpdateException)
                {
                    //handle exception
                }
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);// returns the calling view (add products view)
        }

        public ActionResult getordersJson()
        {
            OrderDal dal = new OrderDal();
            List<Order> orders = dal.order.ToList<Order>();        
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Orders()
        {
            bool admin = Convert.ToBoolean(Session["isadmin"]);
            if (!admin || admin == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult search()
        {
            string product_name = Request.Form["product_name"];
            ProductsDal dal = new ProductsDal();
            ProductsVM products = new ProductsVM();
            products.products_list =
                (from y in dal.products
                 where y.product_name.Contains(product_name) || y.type.Equals(product_name)  select y).ToList<Products>();
            return View("../Home/ShowHomePage", products);

        }
           
    }
}