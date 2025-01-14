using _15_DoDinhTuan_21103100756_PTUDWNET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _15_DoDinhTuan_21103100756_PTUDWNET.WebForms
{
    public partial class Dongho : System.Web.UI.Page
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
            GridView1.DataSource = db.GetAll();
            GridView1.DataBind();
            db.CloseData();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string masp = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.OpenData();
            db.DeleteMa(masp);
            db.CloseData();
            lbthongbao.Text = "Xoá đồng hồ thành công!";
            load();
        }

        protected void btntimkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txttimkiem.Text.Trim();
            DataTable kq = db.Search(timkiem);
            if (kq.Rows.Count > 0)
            {
                GridView1.DataSource = kq;
                GridView1.DataBind();
                lbthongbao.Text = "Tìm kiếm thành công!";
            }
            else if (txttimkiem.Text.Trim() == "")
            {
                lbthongbao.Text = "Vui lòng nhập phân loại đồng hồ cần tìm!";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lbthongbao.Text = "Không tìm thấy loại đồng hồ!";
            }
        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            db.OpenData();
            if (db.CheckMa(txtmasp.Text.Trim()))
            {
                lbthongbao.Text = "Trùng mã sản phẩm!";
                lbthongbao.Visible = true;
            }
            else if (txtmasp.Text.Trim() == "" || txttensp.Text.Trim() == "" || drlphanloai.Text.Trim() == "" || txtsoluong.Text.Trim() == "" || txtdongia.Text.Trim() == "")
            {
                lbthongbao.Text = "Vui lòng điền đầy đủ thông tin!";
            }
            else
            {
                int soluong;
                decimal dongia;
                if (!int.TryParse(txtsoluong.Text.Trim(), out soluong))
                {
                    lbthongbao.Text = "Số lượng phải là kiểu số!";
                    lbthongbao.Visible = true;
                }
               
                else if(!decimal.TryParse(txtsoluong.Text.Trim(), out dongia))
                {
                    lbthongbao.Text = "Đơn giá phải là kiểu số!";
                    lbthongbao.Visible = true;
                }

                else
                {
                    Models.Dongho dh = new Models.Dongho();
                    dh.Masp = txtmasp.Text.Trim();
                    dh.Tensp = txttensp.Text.Trim();
                    dh.Phanloai = drlphanloai.SelectedValue;
                    dh.Soluong = Convert.ToInt32(txtsoluong.Text.Trim());
                    dh.Dongia = Convert.ToDecimal(txtdongia.Text.Trim());

                    if (filehinhanh.HasFile)
                    {
                        string tenanh = filehinhanh.FileName;
                        string filePath = MapPath("~/Images/" + tenanh);
                        filehinhanh.SaveAs(filePath);
                        dh.Hinhanh = tenanh;
                        db.InsertMa(dh);
                        lbthongbao.Text = "Thêm đồng hồ mới thành công!";
                        btnlammoi_Click(sender, e);
                        load();
                    }
                    else
                    {
                        lbthongbao.Text = "Bạn phải chọn 1 hình!";
                    }
                }
            }
        }

        protected void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmasp.Focus();
            txtmasp.Text = "";
            txttensp.Text = "";
            txtsoluong.Text = "";
            txtdongia.Text = "";
            txttimkiem.Text = "";
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

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string masp = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string tensp = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttensp")).Text;
            string phanloai = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("drlphanloai")).SelectedValue;
            string soluong = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsoluong")).Text;
            string dongia = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdongia")).Text;
            int sl;
            if (!int.TryParse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtsoluong")).Text, out sl))
            {
                lbthongbao.Text = "Số lượng phải là kiểu số!";
                return;
            }
            decimal dg;
            if (!decimal.TryParse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtdongia")).Text, out dg))
            {
                lbthongbao.Text = "Đơn giá phải là kiểu số!";
                return;
            }
            FileUpload HinhAnh = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("filehinhanh");
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

            Models.Dongho dh = new Models.Dongho(masp, tensp, phanloai, sl, dg, tenanh);
            db.UpdateMa(dh);
            GridView1.EditIndex = -1;
            load();
            lbthongbao.Text = "Cập nhập đồng hồ thành công!";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }
    }
}