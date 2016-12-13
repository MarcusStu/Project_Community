using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Identity_Sample.Models
{
    public class UserRoleViewModel
    {
        public string Users { get; set; }
        public List<string> Roles { get; set; }
    }
}