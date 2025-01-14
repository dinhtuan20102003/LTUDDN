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
    public partial class KhachHang : System.Web.UI.Page
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
            string makh = GridView1.DataKeys[e.RowIndex].Value.ToString();
            db.OpenData();
            db.Delete(makh);
            db.CloseData();
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
            string makh = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string tenkh = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttenkh")).Text;
            string email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtemail")).Text;
            string gioitinh = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("txtgioitinh")).SelectedValue;
            int stk;
            if (!int.TryParse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtstk")).Text, out stk))
            {
                lbthongbao.Text = "Số tìa khoản phải là kiểu số";
                lbthongbao.Visible = false;
            }
            FileUpload Hinhanh = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("txtfile");
            string tenanh;
            if (Hinhanh.HasFiles)
            {
                tenanh = Hinhanh.FileName;
                Hinhanh.SaveAs(MapPath("~/Images/" + tenanh));
            }
            else
            {
                tenanh = GridView1.DataKeys[e.RowIndex]["HinhAnh"].ToString();
            }
            Models.KhachHang kh = new Models.KhachHang(makh,tenkh,email,gioitinh,stk,tenanh);
            db.Update(kh);
            GridView1.EditIndex = -1;
            load();
            lbthongbao.Text = "Cap nhat thanh cong";
            //string makh = GridView1.DataKeys[e.RowIndex].Value.ToString();
            //string tenkh = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txttenkh")).Text;
            //string email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtemail")).Text;
            //string gioitinh = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("txtgioitinh")).SelectedValue;

            //int sotk;
            //if (!int.TryParse(((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtstk")).Text, out sotk))
            //{

            //    lbthongbao.Text = "Số tài khoản phải là kiểu số";
            //    return;
            //}
            //FileUpload Hinhanh = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("txtfile");
            //string tenanh;
            //if (Hinhanh.HasFile)
            //{
            //    tenanh = Hinhanh.FileName;
            //    Hinhanh.SaveAs(MapPath("~/Images/" + tenanh));
            //}
            //else
            //{
            //    tenanh = GridView1.DataKeys[e.RowIndex]["HinhAnh"].ToString();
            //}
            //Models.KhachHang kh = new Models.KhachHang(makh, tenkh, email, gioitinh, sotk, tenanh);
            //db.Update(kh);
            //GridView1.EditIndex = -1;
            //load();
            //lbthongbao.Text = "Cập nhật thành công";



        }

        protected void btnlammoi_Click(object sender, EventArgs e)
        {
            txtmakh.Text = "";
            txttenkh.Text = "";
            txttenkh.Focus();
            txttenkh.Text = "";
            txtemail.Text = "";
            txtgioitinh.Text = "";
            txtstk.Text = "";
            txttimkiem.Text = "";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            load();
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void chkheader_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkhearder = (CheckBox)sender;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk != null)
                {
                    chk.Checked = chkhearder.Checked;
                }
            }
        }

        protected void btnxoa_Click(object sender, EventArgs e)
        {
            db.OpenData();
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk != null && chk.Checked)
                {
                    db.Delete(row.Cells[1].Text);
                }
            }
            db.CloseData();
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
                lbthongbao.Text = "Tìm kiếm thành công ";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lbthongbao.Text = "Không tìm thấy khách hàng";
            }

        }

        protected void btnthem_Click(object sender, EventArgs e)
        {
            db.OpenData();
            if (db.CheckMa(txtmakh.Text.Trim()))
            {
                lbthongbao.Text = "Trùng mã khách hàng";
                lbthongbao.Visible = true;
            }
            else if (txtmakh.Text.Trim() == "" || txttenkh.Text.Trim() == "" || txtemail.Text.Trim() == "" || txtgioitinh.Text.Trim() == "" || txtstk.Text.Trim() == "")
            {
                lbthongbao.Text = "Vui lòng nhập đầy đủ thông tin ";
                return;
            }
            else
            {
                int stk;
                if (!int.TryParse(txtstk.Text.Trim(), out stk))
                {
                    lbthongbao.Text = "So tai khoanb phai  la kieu so";
                    lbthongbao.Visible = true;
                }
                else
                {
                    Models.KhachHang kh = new Models.KhachHang();
                    kh.Makh = txtmakh.Text.Trim();
                    kh.Tenkh = txttenkh.Text.Trim();
                    kh.Email = txtemail.Text.Trim();
                    kh.Gioitinh = txtgioitinh.SelectedValue;
                    kh.Sotk = Convert.ToInt32(txtstk.Text.Trim());
                    if (FileUpload1.HasFile)
                    {
                        string tenanh = FileUpload1.FileName;
                        string file = MapPath("~/Images/" + tenanh);
                        FileUpload1.SaveAs(tenanh);
                        db.Insert(kh);
                        lbthongbao.Text = "Them thanh cong";
                        btnlammoi_Click(sender, e);
                        load();

                    }
                    else
                    {
                        lbthongbao.Text = " Ban phai chon 1 anh";
                    }
                }
            }
            //db.OpenData();
            //if (db.CheckMa(txtmakh.Text.Trim()))
            //{
            //    lbthongbao.Text = "Trùng mã khách hàng";
            //    lbthongbao.Visible = true;
            //}
            //else if (txtmakh.Text.Trim() == "" || txttenkh.Text.Trim() == "" || txtgioitinh.Text.Trim() == "" || txtemail.Text.Trim() == "" || txtstk.Text.Trim() == "")

            //{
            //    lbthongbao.Text = "Vui lòng nhập đầy đủ thông tin ";
            //}
            //else
            //{
            //    int stk;
            //    if (!int.TryParse(txtstk.Text.Trim(), out stk))
            //    {
            //        lbthongbao.Text = "Số tài khoản phải là kiểu số";
            //        lbthongbao.Visible = true;
            //    }
            //    else
            //    {
            //        Models.KhachHang kh = new Models.KhachHang();
            //        kh.Makh = txtmakh.Text.Trim();
            //        kh.Tenkh = txttenkh.Text.Trim();
            //        kh.Gioitinh = txtgioitinh.SelectedValue;
            //        kh.Email = txtemail.Text.Trim();
            //        kh.Sotk = Convert.ToInt32(txtstk.Text.Trim());
            //        if (FileUpload1.HasFile)
            //        {
            //            string tenanh = FileUpload1.FileName;
            //            string file = MapPath("~/Images/" + tenanh);
            //            FileUpload1.SaveAs(file);
            //            kh.Hinhanh = tenanh;
            //            db.Insert(kh);
            //            lbthongbao.Text = "Thêm thành công";
            //            btnlammoi_Click(sender, e);
            //            load();

            //        }
            //        else
            //        {
            //            lbthongbao.Text = "Bạn phải chọn 1 hình";
            //        }
            //    }
            //}
        }
    }
}