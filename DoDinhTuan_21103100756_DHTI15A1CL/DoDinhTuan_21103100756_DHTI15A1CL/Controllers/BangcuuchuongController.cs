using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoDinhTuan_21103100756_DHTI15A1CL.Controllers
{
    public class BangcuuchuongController : Controller
    {
        public string DoDinhTuan()
        {
          
            string thongtin = "<h1 style='text-align:center; color: red '>Thông tin sinh viên</h1>";
            thongtin += "<p style='font-size:20px; margin-left:20px' >Họ và tên: Đỗ Đình Tuấn</p>";
            thongtin += "<p style='font-size:20px;margin-left:20px'>Mã sinh viên: 21103100756</p>";
            thongtin += "<p style='font-size:20px;margin-left:20px '>Lớp: DHTI15A1CL</p>";


            string bangcuuchuong = "<h1 style='text-align:center; color: red; margin-left:20px'>Bảng cửu chương</h1>";
            for (int i = 1; i <= 10; i++)
            {
                bangcuuchuong += $"<h2 style='margin-left:20px'>Bảng cửu chương {i}</h2>";
                for (int j = 1; j <= 10; j++)
                {
                    bangcuuchuong += $"<a style='font-size:20px; margin-left:20px'>{i} x {j} = {i * j}</a><br/>";
                }
                bangcuuchuong += "<br/>";
            }
            return thongtin + bangcuuchuong;
        }
    }
}
