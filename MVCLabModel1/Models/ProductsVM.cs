using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class ProductsVM
    {
        public Products product { get; set; }
        public List<Products> products_list { get; set; }
    }
}