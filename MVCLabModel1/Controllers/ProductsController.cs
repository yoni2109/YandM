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

        public ActionResult Dogs()
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.products_list =
                (from y in dal.products
                 where y.type.Equals("Dogs")
                 select y).ToList<Products>();
            return View("../Home/ShowHomePage", productsV);
        }
        public ActionResult Cats()
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM productsV = new ProductsVM();
            productsV.products_list =
                (from y in dal.products
                 where y.type.Equals("Cats")
                 select y).ToList<Products>();

            return View("../Home/ShowHomePage", productsV);
        }
        public ActionResult AddProducts()
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM products = new ProductsVM();
            products.products_list = dal.products.ToList<Products>();
            return View(products);
        }
        public ActionResult Submit()
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
                catch(DbUpdateException ex)
                {
                    //handle exception
                }
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult getordersJson()
        {
            OrderDal dal = new OrderDal();
            List<Order> orders = dal.order.ToList<Order>();
            return Json(orders, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Orders()
        {
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