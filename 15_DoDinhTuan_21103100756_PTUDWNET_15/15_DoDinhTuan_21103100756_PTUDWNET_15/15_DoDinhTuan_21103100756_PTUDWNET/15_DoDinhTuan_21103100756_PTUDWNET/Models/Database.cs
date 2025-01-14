using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static _15_DoDinhTuan_21103100756_PTUDWNET.Models.Dongho;

namespace _15_DoDinhTuan_21103100756_PTUDWNET.Models
{
    public class Database
    {
        SqlConnection sqlcon;
        public void OpenData()
        {
            string sql = "Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLDH;Integrated Security=True";
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
            string sql = "select *from Dongho";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public Boolean CheckMa(string masp)
        {
            DataTable dt = new DataTable();
            string sql = " select *from Dongho where Masp = @masp";
            OpenData();
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@masp", masp);
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

        public void InsertMa(Dongho dh)
        {
            try
            {
                OpenData();
                string sql = "insert into Dongho values(@masp, @tensp, @phanloai, @soluong, @dongia, @hinhanh)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@masp", dh.Masp);
                cmd.Parameters.AddWithValue("@tensp", dh.Tensp);
                cmd.Parameters.AddWithValue("@phanloai", dh.Phanloai);
                cmd.Parameters.AddWithValue("@soluong", dh.Soluong);
                cmd.Parameters.AddWithValue("@dongia", dh.Dongia);
                cmd.Parameters.AddWithValue("@hinhanh", dh.Hinhanh);
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
        public void UpdateMa(Dongho dh)
        {
            try
            {
                OpenData();
                string sql = "update Dongho set tensp = @tensp, phanloai = @phanloai, soluong = @soluong, dongia =@dongia, Hinhanh =@hinhanh where Masp = @masp";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@tensp",dh.Tensp);
                cmd.Parameters.AddWithValue("@phanloai",dh.Phanloai);
                cmd.Parameters.AddWithValue("@soluong",dh.Soluong);
                cmd.Parameters.AddWithValue("@dongia",dh.Dongia);
         
                if (dh.Hinhanh == null)
                {
                    cmd.Parameters.AddWithValue("@hinhanh", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@hinhanh",dh.Hinhanh);
                }
                cmd.Parameters.AddWithValue("@masp",dh.Masp);
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

        public void DeleteMa(string masp)
        {
            try
            {
                OpenData();
                string sql = "delete from Dongho where Masp like @masp";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@masp", masp);
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

        public DataTable Search(string phanloai)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenData();
                string sql = "select *from Dongho where Phanloai = @phanloai";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@phanloai", phanloai);
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