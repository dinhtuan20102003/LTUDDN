using _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms
{
    
    public partial class Timkiem : System.Web.UI.Page
    {
        Database db =new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        public void load()
        {
            db.OpenData();
            gvXemay.DataSource = db.GetAll();
            gvXemay.DataBind();
            db.CloseData();

        }
        protected void btntk_Click(object sender, EventArgs e)
        {
            string search = txttimkiem.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                lbtb.Text = "Vui lòng nhập từ khóa để tìm kiếm.";
                lbtb.Visible = true; 
                return;
            }

            db.OpenData();
            DataTable results = db.SearchMA(search);

            if (results != null && results.Rows.Count > 0)
            {
                gvXemay.DataSource = results;
                gvXemay.DataBind();
                lbtb.Text = "";
            }
            else
            {
                gvXemay.DataSource = null;
                gvXemay.DataBind();
                lbtb.Text = "Không tìm thấy xe máy nào với tên hãng sản xuất đã nhập.";
                lbtb.Visible = true;
            }

            db.CloseData();
        }



        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("Xemay.aspx");
        }
    }
}