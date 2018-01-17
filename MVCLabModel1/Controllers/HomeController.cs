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
        public ActionResult placeOrder()// this action is called whe pressing "buy now" on products
        {
            int pid = Convert.ToInt32(Request.Form["pid"]);
            ProductsDal dal = new ProductsDal();
            Products ordered = (from y in dal.products where y.productId.Equals(pid) select y).ToList<Products>()[0];//grabs the product that was "ordered" from the db into current variable
            Users user = (Session["signedin"] as Users);//the user who comiitted the "buy now" button
            if (user != null && ordered != null)
            {
                //inserting the order whith all its details to db
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

            return View("ShowHomePage",new ProductsVM() {
            products_list=((new ProductsDal()).products.ToList<Products>())});
        }
        
    }
}