//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BanHang
    {
        public string manv { get; set; }
        public string masp { get; set; }
        public Nullable<short> dinhmuc { get; set; }
        public Nullable<short> slban { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
