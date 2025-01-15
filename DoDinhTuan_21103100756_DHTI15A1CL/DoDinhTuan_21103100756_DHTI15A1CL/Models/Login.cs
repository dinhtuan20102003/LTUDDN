using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Bạn chưa nhập username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập password")]
        public string Password { get; set; }

        public bool kiemtra()
        {
            return Username == "admin" && Password == "admin";
        }
    }
}