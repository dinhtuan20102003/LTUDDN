using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Quanlysanpham.Models
{
    public class Database
    {
        SqlConnection sqlcon;
        public void OpenData()
        {
            string sql = "Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLSP;Integrated Security=True";
            sqlcon = new SqlConnection(sql);
            sqlcon.Open();
        }
        public void CloseData()
        {
            sqlcon.Close();
            sqlcon.Dispose();
        }

        public DataTable GetAllSP()
        {
            DataTable tb = new DataTable();
            string sql = "select *from Sanpham";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader rd = cmd.ExecuteReader();
            tb.Load(rd);
            CloseData();
            return tb;
        }

        public Boolean CheckMA(string masp)
        {
            DataTable tb = new DataTable();
            string sql = "select *from Sanpham where masp = @masp";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("masp", masp);
            SqlDataReader rd = cmd.ExecuteReader();
            tb.Load(rd);
            CloseData();
            if (tb.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void InsertMA(Sanpham ma)
        {
            OpenData();
            string sql = "insert into Sanpham values(@masp, @tensp,@hangsx, @mota, @dongia, @ngaydang, @hinhanh)";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("masp", ma.Masp);
            cmd.Parameters.AddWithValue("tensp", ma.Tensp);
            cmd.Parameters.AddWithValue("hangsx", ma.Hangsx);
            cmd.Parameters.AddWithValue("mota", ma.Mota);
            cmd.Parameters.AddWithValue("dongia", ma.Dongia);
            cmd.Parameters.AddWithValue("ngaydang", ma.Ngaydang);
            cmd.Parameters.AddWithValue("hinhanh", ma.Hinhanh);
            cmd.ExecuteNonQuery();
            CloseData();
        }
        public void UpdateMA(Sanpham ma)
        {
            OpenData();
            string sql = "update Sanpham set tensp = @tensp, hangsx = @hangsx, mota = @mota, dongia=@dongia, ngaydang =@ngaydang, hinhanh=@hinhanh where masp = @masp";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("tensp", ma.Tensp);
            cmd.Parameters.AddWithValue("hangsx", ma.Hangsx);
            cmd.Parameters.AddWithValue("mota", ma.Mota);
            cmd.Parameters.AddWithValue("dongia", ma.Dongia);
            cmd.Parameters.AddWithValue("ngaydang", ma.Ngaydang);
            if (ma.Hinhanh == "")
            {
                cmd.Parameters.AddWithValue("hinhanh", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("hinhanh", ma.Hinhanh);
            }
            cmd.Parameters.AddWithValue("masp", ma.Masp);
            cmd.ExecuteNonQuery();
            CloseData();
        }
        public void DeleteMA(string masp)
        {
            string sql = "delete from Sanpham where Masp = @masp";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("masp", masp);
            cmd.ExecuteNonQuery();
            CloseData();
        }
        public DataTable SearchMA(string search)
        {
            DataTable tb = new DataTable();
            string sql = "select *from Sanpham where masp like @search  or tensp like @search";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            SqlDataReader rd = cmd.ExecuteReader();
            tb.Load(rd);
            CloseData();
            return tb;
        }
    }
}