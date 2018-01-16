using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YandM.Models
{
    public class Products
    {
        [Required]
        public int price { get; set; }
        [Required]
        [Key]
        public int productId { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public string img_url { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string type { get; set; }

    }


}