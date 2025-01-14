using Quanlysanpham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quanlysanpham.WebForms
{
    public partial class Sanpham : System.Web.UI.Page
    {
        Database db = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            db.OpenData();
            GridView1.DataSource = db.GetAllSP();
            GridView1.DataBind();
            db.CloseData();
        }

        protected void btntimkiem_Click(object sender, EventArgs e)
        {
            string search = txttimkiem.Text.Trim();
            db.OpenData();
           GridView1.DataSource = db.SearchMA(search);
           GridView1.DataBind();
            db.CloseData();
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            db.OpenData();
            if (db.CheckMA(txtmasp.Text.Trim()))
            {
               lbmasp.Text = "*Trùng mã sản phẩm";
            }
            else
            {
               lbmasp.Visible = false;
                Models.Sanpham ma = new Models.Sanpham();
                ma.Masp = Convert.ToInt32(txtmasp.Text.Trim());
                ma.Tensp =txttensp.Text.Trim();
                ma.Hangsx = txthangsx.Text.Trim();
                ma.Mota = txtmota.Text.Trim();
                try
                {

                    ma.Dongia = Convert.ToDouble(txtdongia.Text.Trim());
                    lbdongia.Visible = false;
                }
                catch
                {
                    lbdongia.Text = "*Đơn giá phải là kiểu số";
                }
                ma.Ngaydang = dsngay.Text.Trim();

                string tenanh = "";
                if (filehinhanh.HasFile)
                {
                    tenanh = filehinhanh.FileName;
                    string filepath = MapPath("~/Images/" + tenanh);
                    filehinhanh.SaveAs(filepath);
                    ma.Hinhanh = tenanh;
                    db.InsertMA(ma);
                    db.CloseData();
                    lbfile.Visible = false;
                 
                }
                else
                {
                    lbfile.Text = "*Bạn phải chọn 1 ảnh";
                }

                load();
            }
            db.CloseData();
        }

        protected void btnlammoi_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnxoanhieu_Click(object sender, EventArgs e)
        {
            db.OpenData();

            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkma");
                if (chk != null && chk.Checked)
                {
                    db.DeleteMA(row.Cells[1].Text);
                }
            }
            db.CloseData();
            load();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string ma = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.OpenData();
            db.DeleteMA(ma);
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
            load();
        }
    }
}