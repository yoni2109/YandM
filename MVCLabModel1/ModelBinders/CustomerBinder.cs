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

            Users obj = new Users() {FirstName = customerFirstName,
                                            LastName = customerLastName
                                            };

            return obj;
        }
    }
}