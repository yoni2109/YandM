using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class Order
    {
        [Required]
        [Key]
        public int Orderid { get; set; }
        [Required]
        public string Ousername { get; set; }
        [Required]
        public string Ofname { get; set; }
        [Required]
        public string Olname { get; set; }
        [Required]
        public string Opid { get; set; }
        [Required]
        public string Opname { get; set; }
        [Required]
        public string Oemail { get; set; }
        [Required]
        public string Odate { get; set; }
    }
}