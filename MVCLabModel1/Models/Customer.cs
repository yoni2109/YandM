using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class Customer
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10,MinimumLength =2)]
        public string  LastName { get; set; }

        [Required]
        [Key]
        [RegularExpression("^[0-9]{4}$")]
        public string CustomerNumber { get; set; }
    }
}