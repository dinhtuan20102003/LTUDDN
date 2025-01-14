using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuvien_DoDinhTuan
{
    internal class KetNoi
    {
        public SqlConnection conn;
        public void openConnection()
        {
            conn = new SqlConnection("Data Source=DINHTUAN\\SQLEXPRESS;Initial Catalog=QLTHUVIEN;Integrated Security=True");
            conn.Open();
        }
        public void closeConnection()
        {
            conn.Close();
        }
   
        public DataTable ReadData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }
        public void CreateUpdateDelete(string sql)
        {
            try
            {
                openConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }

    }
}
