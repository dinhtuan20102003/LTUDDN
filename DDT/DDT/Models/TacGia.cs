using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDT.Models
{
    public class TacGia
    {
        [Key]
        [DisplayName("Mã tác giả")]
        public int MaTG { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        [DisplayName("Họ tên")]
        [MinLength(3, ErrorMessage = "Họ tên phải có ít nhất 3 kí tự")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [DisplayName("Số điện thoại")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})\b", ErrorMessage ="Số điện thoại không hợp lệ")]
        public string DT { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập ngày sinh")]
        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập đơn vị")]
        [DisplayName("Đơn vị")]
        public string DonVi { get; set; }


    }
}