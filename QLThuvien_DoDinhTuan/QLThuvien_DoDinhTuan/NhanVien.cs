using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuvien_DoDinhTuan
{
    internal class NhanVien
    {
        private KetNoi ketnoi;
        public NhanVien()
        {
            ketnoi = new KetNoi();
        }
        public DataTable DSNV()
        {
            string sql = "SELECT NhanVien.MaNhanVien, NhanVien.HoTenNhanVien,NhanVien.NgaySinh, NhanVien.DiaChi, NhanVien.DienThoai, BangCap.TenBangCap " +
                "FROM NhanVien " +
                "JOIN BangCap ON NhanVien.MaBangCap = BangCap.MaBangCap";
            return ketnoi.ReadData(sql);
        }

        public DataTable BangCap()
        {
            string sql = "SELECT MaBangCap, TenBangCap FROM BANGCAP";
            return ketnoi.ReadData(sql);
        }

        public bool ThemNhanVien(string hoTen, DateTime ngaySinh, string diaChi, string dienThoai, int maBangCap)
        {
            string sql = "INSERT INTO NhanVien (HoTenNhanVien, NgaySinh, DiaChi, DienThoai, MaBangCap) " +
                         "VALUES (N'" + hoTen + "', '" + ngaySinh.ToString("yyyy-MM-dd") + "', N'" + diaChi + "', '" + dienThoai + "', " + maBangCap + ")";

            try
            {
                ketnoi.CreateUpdateDelete(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SuaNhanVien(int maNhanVien, string hoTen, DateTime ngaySinh, string diaChi, string dienThoai, int maBangCap)
        {
            string sql = "UPDATE NhanVien SET HoTenNhanVien = N'" + hoTen + "', NgaySinh = '" + ngaySinh.ToString("yyyy-MM-dd") + "', " +
                         "DiaChi = N'" + diaChi + "', DienThoai = '" + dienThoai + "', MaBangCap = " + maBangCap + " " +
                         "WHERE MaNhanVien = " + maNhanVien;

            try
            {
                ketnoi.CreateUpdateDelete(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaNhanVien(int maNhanVien)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNhanVien = " + maNhanVien;

            try
            {
                ketnoi.CreateUpdateDelete(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
