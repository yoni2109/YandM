using System;
using System.Collections.Generic;
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

        public ActionResult ShowHomePage()
        {
            ProductsDal dal = new ProductsDal();
            List<Products> dproducts =
                (from y in dal.products
                 select y).ToList<Products>();
            if (dproducts.Count > 0)
            {
                ViewBag.dogproducts = dproducts;
            }
            else ViewBag.dogproducts = null;


            return View();
        }
        
    }
}