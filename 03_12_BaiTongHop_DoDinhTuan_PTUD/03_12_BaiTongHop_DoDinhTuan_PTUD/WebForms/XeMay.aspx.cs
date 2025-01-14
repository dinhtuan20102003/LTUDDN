using _03_12_BaiTongHop_DoDinhTuan_PTUD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace _03_12_BaiTongHop_DoDinhTuan_PTUD.WebForms
{
    public partial class XeMay : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load();
            }
        }
        private void load()
        {
            db.OpenData();
            GridView1.DataSource = db.GetAll();
            GridView1.DataBind();
            db.CloseData();
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string ma = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.OpenData();
            db.Delete(ma);
            db.CloseData();
            load();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            load();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtbienso.Text = "";
            txttenxe.Text = "";
            txtmau.Text = "";
            txtnamsx.Text = "";
            txtngaysx.Text = "";
            drlhangsx.Text = "";
            txttimkiem.Text = "";
            lbThongbao.Text = "";
            txtbienso.Focus();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string bienso = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string tenxe = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttenxe")).Text;
            string mau = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtmau")).Text;
            string hangsx = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("drlhangsx")).SelectedValue;
            string ngaysx = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtngaysx")).Text;
            int nam;
            if (!int.TryParse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtnamsx")).Text, out nam))
            {
                lbThongbao.Text = "Năm sản xuất phải là kiểu số";
                return;
            }
            FileUpload HinhAnh = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload2");
            string tenanh;
            if (HinhAnh.HasFile)
            {
                tenanh = HinhAnh.FileName;
                HinhAnh.SaveAs(MapPath("~/Images/" + tenanh));
            }
            else
            {
                tenanh = GridView1.DataKeys[e.RowIndex]["Hinhanh"].ToString();
            }

            Models.XeMay xm = new Models.XeMay(bienso, tenxe, mau, hangsx, ngaysx, nam, tenanh);
            db.Update(xm);
            GridView1.EditIndex = -1;
            load();
            lbThongbao.Text = "Cập nhập xe máy thành công";
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
          
            db.OpenData();
            if (db.CheckMa(txtbienso.Text.Trim()))
            {
                lbThongbao.Text = "Trùng biển số";
                lbThongbao.Visible = true;
            }
            else if (txtbienso.Text.Trim() == "" || txtmau.Text.Trim() == "" || drlhangsx.Text.Trim() == "" || txtngaysx.Text.Trim() == "" || txtnamsx.Text.Trim() == "")
            {
                lbThongbao.Text = "Vui lòng điền đầy đủ thông tin";
            }
            else
            {
                int nam;
                if (!int.TryParse(txtnamsx.Text.Trim(), out nam))
                {
                    lbThongbao.Text = "Năm sản xuất là số";
                    lbThongbao.Visible = true;
                }
                else
                {
                    Models.XeMay xm = new Models.XeMay();
                    xm.Bienso = txtbienso.Text.Trim();
                    xm.Tenxe = txttenxe.Text.Trim();
                    xm.Mau = txtmau.Text.Trim();
                    xm.Hangsx = drlhangsx.SelectedValue;
                    xm.Ngaysx = txtngaysx.Text;
                    xm.Namsx = Convert.ToInt32(txtnamsx.Text);
                    if (FileUpload1.HasFile)
                    {
                        string tenanh = FileUpload1.FileName;
                        string filePath = MapPath("~/Images/" + tenanh);
                        FileUpload1.SaveAs(filePath);
                        xm.Hinhanh = tenanh;
                        db.Insert(xm);
                        lbThongbao.Text = "Thêm xe mới thành công.";
                        btnReset_Click(sender, e);
                        load();
                    }
                    else
                    {
                        lbThongbao.Text = "Bạn phải chọn 1 hình";
                    }
                }
            }
        }

        protected void btntimkiem_Click(object sender, EventArgs e)
        {

            string timkiem = txttimkiem.Text.Trim();
            DataTable kq = db.Timkiem(timkiem);
            if (kq.Rows.Count > 0)
            {
                GridView1.DataSource = kq;
                GridView1.DataBind();
                lbThongbao.Text = "Tìm kiếm thành công";
            }
            else if (txttimkiem.Text.Trim() == "")
            {
                lbThongbao.Text = "Vui lòng nhập hãng xe máy cần tìm";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lbThongbao.Text = "Không tìm thấy xe máy";
            }


        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            db.OpenData();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk1");
                if (chk != null && chk.Checked)
                {
                    db.Delete(row.Cells[1].Text);
                }
            }
            db.CloseData();
            load();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }
         
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        { 
            CheckBox chkHeader = (CheckBox)sender;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk1");
                if (chk != null)
                {
                    chk.Checked = chkHeader.Checked;
                }
            }

        }
    }
}