using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YandM.Models
{
    public class Products
    {
        [Required(ErrorMessage="Enter Price")]
        public int price { get; set; }
        [Required(ErrorMessage = "Enter Product ID")]
        [Key]
        public int productId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string product_name { get; set; }
        [Required(ErrorMessage = "Enter URL Image")]
        public string img_url { get; set; }
        [Required(ErrorMessage = "Enter Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Choose Dogs Or Cats")]
        public string type { get; set; }

    }


}