﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataFirst_DDT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Diem
    {
        [DisplayName("Mã sinh viên")]
        [Key, Column(Order =0)]
        public int Masv { get; set; }
        [DisplayName("Mã môn học")]
        [Key, Column(Order = 0)]
        public int Mamh { get; set; }
        [DisplayName("Điểm")]
        public Nullable<decimal> Diemtb { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
    }
}
