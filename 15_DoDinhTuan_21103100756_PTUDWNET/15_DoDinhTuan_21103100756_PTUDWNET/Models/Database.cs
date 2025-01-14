using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _15_DoDinhTuan_21103100756_PTUDWNET.Models
{
    public class Database
    {

        SqlConnection sqlcon;
        public void OpenData()
        {
            string sql = "Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLKH10;Integrated Security=True";
            sqlcon = new SqlConnection(sql);
            sqlcon.Open();
        }

        public void CloseData()
        {
            sqlcon.Close();
        }

        public DataTable GetAll()
        {
            OpenData();
            DataTable dt = new DataTable();
            string sql = "select *from KhachHang";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public Boolean CheckMa(string makh)
        {
            OpenData();
            DataTable dt = new DataTable();
            string sql = "select *  from KhachHang where MaKH = @makh";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@makh", makh);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Insert(KhachHang kh)
        {
            try
            {
                OpenData();
                string sql = "Insert into KhachHang values(@makh, @tenkh,@email, @gioitinh, @stk, @hinhanh)";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@makh", kh.Makh);
                cmd.Parameters.AddWithValue("@tenkh", kh.Tenkh);
                cmd.Parameters.AddWithValue("@email", kh.Email);
                cmd.Parameters.AddWithValue("@gioitinh", kh.Gioitinh);
                cmd.Parameters.AddWithValue("@stk", kh.Sotk);
                cmd.Parameters.AddWithValue("@hinhanh", kh.Hinhanh);
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

        public void Update(KhachHang kh)
        {
            try
            {
                OpenData();
                string sql = "Update KhachHang  set TenKH = @tenkh, Email = @email, GioiTinh =  @gioitinh,  SoTK = @stk, HinhAnh = @hinhanh where MaKH = @makh";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);

                cmd.Parameters.AddWithValue("@tenkh", kh.Tenkh);
                cmd.Parameters.AddWithValue("@email", kh.Email);
                cmd.Parameters.AddWithValue("@gioitinh", kh.Gioitinh);
                cmd.Parameters.AddWithValue("@stk", kh.Sotk);
                if (kh.Hinhanh == null)
                {
                    cmd.Parameters.AddWithValue("@hinhanh", "");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@hinhanh", kh.Hinhanh);
                }

                cmd.Parameters.AddWithValue("@makh", kh.Makh);
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

        public void Delete(string makh)
        {
            try
            {
                OpenData();
                string sql = "Delete from KhachHang where MaKH = @makh";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@makh", makh);
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

        public DataTable Search(string tenkh)
        {
            DataTable dt = new DataTable();
          
            try
            {

                OpenData();
                string sql = "select * from KhachHang where TenKH like @tenkh";
                SqlCommand cmd = new SqlCommand(sql,sqlcon);
                cmd.Parameters.AddWithValue("@tenkh", tenkh );
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
        //SqlConnection sqlcon;
        //public void OpenData()
        //{
        //    string sql = "Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLKH10;Integrated Security=True";
        //    sqlcon = new SqlConnection(sql);
        //    sqlcon.Open();

        //}
        //public void CloseData()
        //{
        //    sqlcon.Close();
        //}

        //public DataTable GetAll()
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "select *from KhachHang";
        //    OpenData();
        //    SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    dt.Load(reader);
        //    return dt;
        //}

        //public Boolean CheckMa(string makh)
        //{
        //    DataTable dt = new DataTable();
        //    string sql = "select *from KhachHang where MaKH = @makh";
        //    OpenData();
        //    SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //    cmd.Parameters.AddWithValue("@makh", makh);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    dt.Load(reader);
        //    CloseData();
        //    if (dt.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void Insert(KhachHang kh)
        //{
        //    try
        //    {
        //        OpenData();
        //        string sql = "insert into KhachHang values(@makh, @tenkh, @email, @gioitinh, @sotk, @hinhanh)";
        //        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //        cmd.Parameters.AddWithValue("@makh", kh.Makh);
        //        cmd.Parameters.AddWithValue("@tenkh", kh.Tenkh);
        //        cmd.Parameters.AddWithValue("@email", kh.Email);
        //        cmd.Parameters.AddWithValue("@gioitinh", kh.Gioitinh);
        //        cmd.Parameters.AddWithValue("@sotk", kh.Sotk);
        //        cmd.Parameters.AddWithValue("@hinhanh", kh.Hinhanh);
        //        cmd.ExecuteNonQuery();


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        CloseData();
        //    }
        //}
        //public void Update(KhachHang kh)
        //{
        //    try
        //    {
        //        OpenData();
        //        string sql = "update KhachHang set TenKH = @tenkh, Email =@email, GioiTinh = @gioitinh, SoTK = @stk, HinhAnh = @hinhanh where MaKH = @makh";
        //        SqlCommand cmd = new SqlCommand(sql, sqlcon);

        //        cmd.Parameters.AddWithValue("@tenkh", kh.Tenkh);
        //        cmd.Parameters.AddWithValue("@email", kh.Email);
        //        cmd.Parameters.AddWithValue("@gioitinh", kh.Gioitinh);
        //        cmd.Parameters.AddWithValue("@stk", kh.Sotk);
        //        if (kh.Hinhanh == null)
        //        {
        //            cmd.Parameters.AddWithValue("@hinhanh", "");
        //        }
        //        else
        //        {
        //            cmd.Parameters.AddWithValue("@hinhanh", kh.Hinhanh);
        //        }
        //        cmd.Parameters.AddWithValue("@makh", kh.Makh);
        //        cmd.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        CloseData();
        //    }
        //}
        //public void Delete(string makh)
        //{
        //    try
        //    {
        //        OpenData();
        //        string sql = "delete from KhachHang where MaKH  = @makh";
        //        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //        cmd.Parameters.AddWithValue("@makh", makh);
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally { CloseData(); }
        //}

        //public DataTable Search(string tenkh)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        OpenData();
        //        string sql = "select *from KhachHang where TenKH like @tenkh";
        //        SqlCommand cmd = new SqlCommand(sql, sqlcon);
        //        cmd.Parameters.AddWithValue("@tenkh", "%" + tenkh + "%");
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        dt.Load(reader);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally { CloseData(); }
        //    return dt;
        //}
    }
}