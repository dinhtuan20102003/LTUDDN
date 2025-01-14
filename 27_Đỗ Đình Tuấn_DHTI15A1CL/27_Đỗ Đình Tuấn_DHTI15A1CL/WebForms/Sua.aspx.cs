using _27_Đỗ_Đình_Tuấn_DHTI15A1CL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms
{
    public partial class Sua : System.Web.UI.Page
    {
        Database db = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bienso = Request.QueryString["bienso"];
                if (!string.IsNullOrEmpty(bienso))
                {
                    db.OpenData();
                    var xm = db.GetBienSo(bienso);
                    db.CloseData();
                    if (xm != null)
                    {
                        txtbienso.Text = xm.Bienso;
                        txttenxe.Text = xm.Tenxe;
                        txtmau.Text = xm.Mau;
                        txthangsx.Text = xm.Hangsx;
                        txtnsx.Text = xm.Namsx.ToString();
                        lbha.Text = "Hình ảnh hiện tại: " + xm.Hinhanh;
                        //imgHinhAnh.ImageUrl = "~/Images/" + xm.Hinhanh;
                        txtbienso.ReadOnly = true;
                    }
                }
            }
        }


        protected void btnsua_Click(object sender, EventArgs e)
        {
            db.OpenData();
            Models.Xemay xm = new Models.Xemay();
            xm.Bienso = txtbienso.Text.Trim();
            xm.Tenxe = txttenxe.Text.Trim();
            xm.Mau = txtmau.Text.Trim();
            xm.Hangsx = txthangsx.Text.Trim();

            int namSX;
            if (!int.TryParse(txtnsx.Text.Trim(), out namSX))
            {
                lbnsx.Text = "*Năm sản xuất phải là kiểu số!";
                db.CloseData();
                return;
            }
            xm.Namsx = namSX;

            if (FileUpload1.HasFile)
            {
                string hinhanh = FileUpload1.FileName;
                string filepath = MapPath("~/Images/" + hinhanh);  
                try
                {
                    FileUpload1.SaveAs(filepath);  
                    xm.Hinhanh = hinhanh;  
                }
                catch
                {
                    lbha.Text = "*Không thể lưu hình ảnh!";
                    db.CloseData();
                    return;
                }
            }
            else
            {
                var xmha = db.GetBienSo(xm.Bienso);  
                xm.Hinhanh = xmha.Hinhanh;
            }

            db.UpdateXM(xm);
            db.CloseData();
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Sửa dữ liệu thành công!'); window.location='Xemay.aspx';", true);
        }


        protected void btnql_Click(object sender, EventArgs e)
        {
            Response.Redirect("Xemay.aspx");
        }
    }
}