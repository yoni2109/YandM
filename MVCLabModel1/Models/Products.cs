using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class Products
    {
        public int price { get; set; }
        public string product_name { get; set; }
        public string img_url { get; set; }
        public string description { get; set; }
        public string type { get; set; }
    }
}