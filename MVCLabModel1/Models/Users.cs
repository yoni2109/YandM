using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class Users
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10,MinimumLength =2)]
        public string  LastName { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$")]
        public string UserPN { get; set; }

        [Required]
        [Key]
        [StringLength(15,MinimumLength =3)]
        public string UserName { get; set; }

        [Required]
        //[RegularExpression("^[a-zA-Z0-9]*@[a-zA-Z0-9]*.[a-zA-Z]")]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(15,MinimumLength =6)]
        public string UserPassword { get; set; }
    }
}