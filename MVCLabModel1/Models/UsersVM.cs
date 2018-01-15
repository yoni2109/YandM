using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YandM.Models
{
    public class UsersVM
    {
        public Users user { get; set; }
        public List<Users> users_list { get; set; }
    }
}