using YandM.Dal;
using YandM.ModelBinders;
using YandM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YandM.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer myCustomer = new Customer
                        {
                            FirstName = "Yaron",
                            LastName = "Shalo",
                            CustomerNumber = "123A"
                        };

            return View("Customer",myCustomer);
        }

        public ActionResult Enter()
        {
            CustomerDal dal = new CustomerDal();
            CustomerVM cvm = new CustomerVM();
            cvm.customer = new Customer();
            //cvm.customers = new List<Customer>();
            cvm.customers = dal.Customers.ToList<Customer>();
            return View(cvm);
        }

        public ActionResult ShowSearch()
        {
            CustomerVM cvm = new CustomerVM();
            cvm.customer = new Customer();
            cvm.customers = new List<Customer>();
            return View("SearchCustomer", cvm);
        }

        public ActionResult SearchCustomers()
        {
            CustomerDal dal = new CustomerDal();
            string searchValue = Request.Form["txtFirstName"];
            List<Customer> objCustomers =
                (from x in dal.Customers
                 where x.FirstName.Contains(searchValue)
                 select x).ToList<Customer>();
            CustomerVM cvm = new CustomerVM();
            cvm.customer = new Customer();
            cvm.customers = objCustomers;
            return View("SearchCustomer", cvm);
        }

      

        // public ActionResult Submit([ModelBinder(typeof(CustomerBinder))]Customer cust)
        public ActionResult Submit()
        {
            CustomerVM cvm = new CustomerVM();
            Customer objCustomer = new Customer();
            CustomerDal dal = new CustomerDal();

            objCustomer.FirstName = Request.Form["customer.FirstName"];
            objCustomer.LastName = Request.Form["customer.LastName"];
            objCustomer.CustomerNumber = Request.Form["customer.CustomerNumber"];

            if (ModelState.IsValid)
            {

                dal.Customers.Add(objCustomer); 
                dal.SaveChanges();
                cvm.customer = new Customer();
            }
            else
                cvm.customer = objCustomer;

            
            cvm.customers = dal.Customers.ToList<Customer>();

            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}