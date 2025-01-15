using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DoDinhTuan_21103100756_DHTI15A1CL.Models;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Models
{
    public class user1
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên bắt buộc phải nhập")]
        [StringLength(30,MinimumLength = 2, ErrorMessage = "Tên phải từ 2 đến 30 kí tự ")]
        [DisplayName("Họ tên")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp")]
        [DataType(DataType.Password)]
        public string ReEnterPassword { get; set; }
        public bool Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        // [Range(18, 60)]
        [ScaffoldColumn(false)]
        //[ReadOnly(true)]
        public int Age { get; set; }
    }
}