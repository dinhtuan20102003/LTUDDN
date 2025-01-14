using _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms
{
    public partial class Xemay : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load();
            }
        }
        public void load()
        {
            db.OpenData();
            gvXemay.DataSource = db.GetAll();
            gvXemay.DataBind();
            db.CloseData();

        }

       

        protected void btnthem_Click(object sender, EventArgs e)
        {
            Response.Redirect("Them.aspx");
        }

        protected void btntk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Timkiem.aspx");
        }

        protected void btnsua_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string bienso = btn.CommandArgument;
            Response.Redirect($"Sua.aspx?bienso={bienso}");
        }
        protected void btnxoa_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            string bienso = btnDelete.CommandArgument;
            db.DeleteXM(bienso);
            load();
            string script = $"alert('Xóa xe máy có biển số {bienso} thành công!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void gvXemay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvXemay.PageIndex = e.NewPageIndex;
            load();
        }
    }
}