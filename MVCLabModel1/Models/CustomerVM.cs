using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class CustomerVM
    {
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }
    }
}