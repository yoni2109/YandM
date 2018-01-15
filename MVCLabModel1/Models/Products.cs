using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabModel1.Models
{
    public class Products
    {
        public int price { get; set; }
        public string product_name { get; set; }
        public string img_url { get; set; }
        public string description { get; set; }
    }
}