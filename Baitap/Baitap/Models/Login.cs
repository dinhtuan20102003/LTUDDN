using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baitap.Models
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool kiemtra()
        {
            return Username == "admin" && Password == "admin";
        }
    }
}