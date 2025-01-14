using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _03_12_BaiTongHop_DoDinhTuan_PTUD.Models
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
        }

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            string sql = "select *from XeMay";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public Boolean CheckMa(string bienso)
        {
            DataTable dt = new DataTable();
            string sql = " select *from XeMay where Bienso = @bienso";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@bienso", bienso);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            CloseData();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Insert(XeMay xm)
        {
            try
            {
                OpenData();
                string sql = "insert into Xemay values(@bienso, @tenxe, @mau, @hangsx, @ngaysx, @namsx, @hinhanh)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@bienso", xm.Bienso);
                cmd.Parameters.AddWithValue("@tenxe", xm.Tenxe);
                cmd.Parameters.AddWithValue("@mau", xm.Mau);
                cmd.Parameters.AddWithValue("@hangsx", xm.Hangsx);
                cmd.Parameters.AddWithValue("@ngaysx", xm.Ngaysx);
                cmd.Parameters.AddWithValue("@namsx", xm.Namsx);
                cmd.Parameters.AddWithValue("@hinhanh", xm.Hinhanh);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseData();
            }
        }
        public void Update(XeMay xm)
        {
            try
            {
                OpenData();
                string sql = "update Xemay set TenXe = @tenxe, Mau = @mau, HangSX = @hangsx, NgaySX =@ngaysx, NamSX =@namsx, Hinhanh =@hinhanh where Bienso = @bienso";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@tenxe", xm.Tenxe);
                cmd.Parameters.AddWithValue("@mau", xm.Mau);
                cmd.Parameters.AddWithValue("@hangsx", xm.Hangsx);
                cmd.Parameters.AddWithValue("@ngaysx", xm.Ngaysx);
                cmd.Parameters.AddWithValue("@namsx", xm.Namsx);
                if (xm.Hinhanh == null)
                {
                    cmd.Parameters.AddWithValue("@hinhanh", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@hinhanh", xm.Hinhanh);
                }
                cmd.Parameters.AddWithValue("@bienso", xm.Bienso);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseData();
            }
        }

        public void Delete(string bienso)
        {
            try
            {
                OpenData();
                string sql = "delete from XeMay where Bienso = @bienso";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseData();
            }
        }

        public DataTable Timkiem(string hangsx)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenData();
                string sql = "select *from XeMay where HangSX like @hangsx";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@hangsx", hangsx);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseData();
            }
            return dt;
        }
    }
}