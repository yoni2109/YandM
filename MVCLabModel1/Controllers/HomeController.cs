using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YandM.Dal;
using YandM.Models;

namespace YandM.Controllers
{
    public class HomeController : Controller
    {
       

        public ActionResult About()
        {

            return View();
        }
        public ActionResult GetproductsJson()
        {
            ProductsDal dal = new ProductsDal();
            List<Products> products = dal.products.ToList<Products>();
            return Json(products,JsonRequestBehavior.AllowGet);
        }

        public ActionResult placeOrder()
        {
            int x = Convert.ToInt32(Request.Form["pid"]);
            ProductsDal dal = new ProductsDal();
            Products ordered = (from y in dal.products where y.productId.Equals(x) select y).ToList<Products>()[0];
            Users user = (Session["signedin"] as Users);
            if (user != null && ordered != null)
            {
                OrderDal odal = new OrderDal();
                odal.order.Add(new Order()
                {
                    Odate = DateTime.Now.ToString(),
                    Oemail = user.UserEmail,
                    Ofname = user.FirstName,
                    Olname = user.LastName,
                    Opid = ordered.productId.ToString(),
                    Opname = ordered.product_name,
                    Ousername = user.UserName

                });
                try
                {
                    odal.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    //handle exception
                }
                ViewBag.succeded = "order submited succesfully, our team will contact you soon";
            }
            return ShowHomePage();
        }

        public ActionResult ShowHomePage()
        {
            ProductsDal dal = new ProductsDal();
            ProductsVM products = new ProductsVM();
            List<Products> dproducts =
                (from y in dal.products
                 select y).ToList<Products>();
            if (dproducts.Count > 0)
            {
                ViewBag.dogproducts = dproducts;
            }
            else return View();
            products.products_list = dproducts;


            return View("ShowHomePage",products);
        }
        
    }
}