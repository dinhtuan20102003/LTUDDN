using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_Tuan4.Models
{
    public class Login
    {
        public string Username  { get; set; }
        public string Password { get; set; }
        public bool kiemtra()
        {
            return Username == "admin" && Password == "admin";
        }
    }
}