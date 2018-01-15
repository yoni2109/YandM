using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}