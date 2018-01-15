using YandM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YandM.ModelBinders
{
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string customerFirstName = objContext.Request.Form["txtFirstName"];
            string customerLastName = objContext.Request.Form["txtLastName"];
            string customerCustomerNumber = objContext.Request.Form["txtCustomerNumber"];

            Customer obj = new Customer() {FirstName = customerFirstName,
                                            LastName = customerLastName,
                                            CustomerNumber = customerCustomerNumber};

            return obj;
        }
    }
}