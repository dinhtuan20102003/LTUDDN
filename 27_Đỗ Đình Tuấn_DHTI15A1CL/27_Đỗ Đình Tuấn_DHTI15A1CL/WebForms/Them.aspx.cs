using _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms
{
   
    public partial class Them : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnql_Click(object sender, EventArgs e)
        {
            Response.Redirect("Xemay.aspx");
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
          
            db.OpenData();

            bool isValid = true;
            int namsx = 0;
            if (string.IsNullOrWhiteSpace(txtbs.Text))
            {
                lbbs.Text = "*Vui lòng nhập biển số";
                lbbs.Visible = true;
                isValid = false;
            }
            else if (db.CheckMA(txtbs.Text.Trim()))
            {
                lbbs.Text = "*Biển số đã tồn tại";
                lbbs.Visible = true;
                isValid = false;
            }
            else
            {
                lbbs.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txttxm.Text))
            {
                lbtxm.Text = "*Vui lòng nhập tên xe";
                lbtxm.Visible = true;
                isValid = false;
            }
            else
            {
                lbtxm.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtmau.Text))
            {
                lbmau.Text = "*Vui lòng nhập màu xe";
                lbmau.Visible = true;
                isValid = false;
            }
            else
            {
                lbmau.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txthsx.Text))
            {
                lbhsx.Text = "*Vui lòng nhập hãng sản xuất";
                lbhsx.Visible = true;
                isValid = false;
            }
            else
            {
                lbhsx.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtnsx.Text))
            {
                lbnsx.Text = "*Vui lòng nhập năm sản xuất";
                lbnsx.Visible = true;
                isValid = false;
            }
            else if (!int.TryParse(txtnsx.Text.Trim(), out namsx))
            {
                lbnsx.Text = "*Năm sản xuất là kiểu số";
                lbnsx.Visible = true;
                isValid = false;
            }
            else
            {
                lbnsx.Visible = false;
            }
            if (!FileUpload1.HasFile)
            {
                lbha.Text = "*Bạn phải chọn 1 ảnh";
                lbha.Visible = true;
                isValid = false;
            }
            else
            {
                lbha.Visible = false;
            }

            if (isValid)
            {
                Models.Xemay ma = new Models.Xemay
                {
                    Bienso = txtbs.Text.Trim(),
                    Tenxe = txttxm.Text.Trim(),
                    Mau = txtmau.Text.Trim(),
                    Hangsx = txthsx.Text.Trim(),
                    Namsx = namsx,
                    Hinhanh = FileUpload1.FileName
                };

                string filepath = MapPath("~/Images/" + ma.Hinhanh);
                FileUpload1.SaveAs(filepath);

                db.InsertXM(ma); 
                db.CloseData();

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Thêm xe máy thành công!'); window.location='Xemay.aspx';", true);
            }
            else
            {
                db.CloseData();
            }
        }

    }
}