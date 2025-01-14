using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Reflection;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models
{
    public class Database
    {
        SqlConnection sqlcon;
        public void OpenData()
        {
            string sql = "Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLXM;Integrated Security=True";
            sqlcon = new SqlConnection(sql);
            sqlcon.Open();
        }
        public void CloseData()
        {
            sqlcon.Close();
            sqlcon.Dispose();
        }

        public DataTable GetAll()
        {
            DataTable tb = new DataTable();
            string sql = "select *from Xemay";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader rd = cmd.ExecuteReader();
            tb.Load(rd);
            CloseData();
            return tb;
        }
        public Boolean CheckMA(string bienso)
        {
            DataTable tb = new DataTable();
            string sql = "select *from Xemay where Bienso = @bienso";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("bienso", bienso);
            SqlDataReader rd = cmd.ExecuteReader();
            tb.Load(rd);
            CloseData();
            if (tb.Rows.Count > 0)
                return true;
            else
                return false;
        }
       
        public void InsertXM(Xemay xm)
        {
            OpenData();
            string sql = "insert into Xemay values(@bienso, @tenxe, @mau, @hangsx, @namsx, @hinhanh)";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("bienso", xm.Bienso);
            cmd.Parameters.AddWithValue("tenxe", xm.Tenxe);
            cmd.Parameters.AddWithValue("mau", xm.Mau);
            cmd.Parameters.AddWithValue("hangsx", xm.Hangsx);
            cmd.Parameters.AddWithValue("namsx", xm.Namsx);
            cmd.Parameters.AddWithValue("hinhanh", xm.Hinhanh);

            cmd.ExecuteNonQuery();
            CloseData();
        }
        public void UpdateXM(Xemay xm)
        {
            OpenData();
            string sql = "update Xemay set Tenxe = @tenxe, Mau=@mau, Hangsx=@hangsx, Namsx =@namsx, Hinhanh = @hinhanh where Bienso = @bienso";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("tenxe", xm.Tenxe);
            cmd.Parameters.AddWithValue("mau", xm.Mau);
            cmd.Parameters.AddWithValue("hangsx", xm.Hangsx);
            cmd.Parameters.AddWithValue("namsx", xm.Namsx);
            if (xm.Hinhanh == "")
            {
                cmd.Parameters.AddWithValue("hinhanh", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("hinhanh", xm.Hinhanh);
            }
  
            cmd.Parameters.AddWithValue("bienso", xm.Bienso);
            cmd.ExecuteNonQuery();
            CloseData();
        }
        public Xemay GetBienSo(string bienso)
        {
           Xemay xemay = null;

            string sql = "SELECT * FROM XeMay WHERE BienSo = @bienSo";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@bienSo", bienso);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                xemay = new Xemay()
                {
                    Bienso = reader["Bienso"].ToString(),
                    Tenxe = reader["Tenxe"].ToString(),
                    Mau = reader["Mau"].ToString(),
                    Hangsx = reader["HangSX"].ToString(),
                    Namsx = Convert.ToInt32(reader["NamSX"]),
                    Hinhanh = reader["HinhAnh"].ToString()
                };
            }

            reader.Close();
            CloseData();
            return xemay;
        }
        public void DeleteXM(string bienso)
        {
            string sql = "delete from Xemay where Bienso = @bienso";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("bienso", bienso);
            cmd.ExecuteNonQuery();
            CloseData();
        }
        public DataTable SearchMA(string search)
        {
            DataTable tb = new DataTable();
            string sql = "select *from Xemay where Hangsx like @search ";
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