<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sanpham.aspx.cs" Inherits="Quanlysanpham.WebForms.Sanpham" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 34px;
            width: 425px;
        }
        .auto-style2 {
            width: 190px;
            text-align: left;
        }
        .auto-style3 {
            height: 34px;
            width: 190px;
            text-align: left;
            font-size: large;
            color: #0066FF;
        }
        .auto-style4 {
            height: 34px;
            text-align: center;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            height: 34px;
            text-align: left;
        }
        .auto-style7 {
            height: 34px;
            text-align: center;
            color: #0066FF;
            font-size: x-large;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            width: 425px;
        }
        .auto-style10 {
            text-align: center;
            font-size: large;
        }
        .auto-style11 {
            font-size: large;
        }
        .auto-style12 {
            width: 425px;
            font-size: large;
        }
        .auto-style13 {
            width: 190px;
            text-align: left;
            font-size: large;
            color: #0066FF;
        }
        .auto-style14 {
            width: 425px;
            font-size: large;
            color: #0066FF;
        }
        .auto-style15 {
            text-align: center;
            font-size: large;
            color: #0066FF;
        }
        .auto-style16 {
            font-size: large;
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="auto-style7">
       <strong>QUẢN LÝ SẢN PHẨM</strong></div>
   <div class="auto-style8">
       <br />
       <table class="auto-style4">
           <tr>
               <td class="auto-style9"></td>
               <td class="auto-style2"><strong>
                   <asp:Label ID="Label1" runat="server" CssClass="auto-style15" Text="Tìm kiếm"></asp:Label>
                   </strong></td>
               <td class="auto-style5">
                   <asp:TextBox ID="txttimkiem" runat="server" Width="455px" CssClass="auto-style11"></asp:TextBox>
                   <asp:Button ID="btntimkiem" runat="server" CssClass="auto-style16" OnClick="btntimkiem_Click" Text="Tìm kiếm" style="font-size: large" Width="97px" />
               </td>
           </tr>
           <tr>
               <td class="auto-style14">&nbsp;</td>
               <td class="auto-style13"><strong>Mã sản phẩm</strong></td>
               <td class="auto-style5">
                   <asp:TextBox ID="txtmasp" runat="server" Width="306px" CssClass="auto-style11" ></asp:TextBox>
                   <asp:Label ID="lbmasp" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style9"></td>
               <td class="auto-style13"><strong>Tên sản phẩm</strong></td>
               <td class="auto-style6">
                   <asp:TextBox ID="txttensp" runat="server" Width="306px" CssClass="auto-style11"></asp:TextBox>
                   <asp:Label ID="lbtensp" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style1"></td>
               <td class="auto-style3"><strong>Hãng sản xuất</strong></td>
               <td class="auto-style6">
                   <asp:TextBox ID="txthangsx" runat="server" Width="306px" CssClass="auto-style11"></asp:TextBox>
                   <asp:Label ID="lbhangsx" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style14">&nbsp;</td>
               <td class="auto-style13"><strong>Mô tả</strong></td>
               <td class="auto-style5">
                   <asp:TextBox ID="txtmota" runat="server" Width="306px" CssClass="auto-style11"></asp:TextBox>
                   <asp:Label ID="lbmota" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style14">&nbsp;</td>
               <td class="auto-style13"><strong>Đơn giá</strong></td>
               <td class="auto-style5">
                   <asp:TextBox ID="txtdongia" runat="server" Width="306px" CssClass="auto-style11"></asp:TextBox>
                   <asp:Label ID="lbdongia" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style14">&nbsp;</td>
               <td class="auto-style13"><strong>Ngày đăng </strong></td>
               <td class="auto-style5">
                   <asp:TextBox ID="dsngay" runat="server" Width="304px" TextMode="Date" CssClass="auto-style11"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td class="auto-style14">&nbsp;</td>
               <td class="auto-style13"><strong>Hình ảnh</strong></td>
               <td class="auto-style5">
                   <asp:FileUpload ID="filehinhanh" runat="server" Width="312px" CssClass="auto-style11" />
                   <asp:Label ID="lbfile" runat="server" CssClass="auto-style15" style="font-size: large"></asp:Label>
               </td>
           </tr>
           <tr>
               <td class="auto-style12">&nbsp;</td>
               <td colspan="2">
       <br class="auto-style11" />
       <div class="auto-style11">
           <asp:Button ID="btnthem" runat="server" CssClass="auto-style11" Text="Thêm" OnClick="btnthem_Click" style="font-size: large" Width="75px" />
           <asp:Button ID="btnlammoi" runat="server" CssClass="auto-style10" OnClick="btnlammoi_Click" Text="Làm mới" />
           <asp:Button ID="btnxoanhieu" runat="server" CssClass="auto-style10" OnClick="btnxoanhieu_Click" Text="Xóa" />
       </div>
               </td>
           </tr>
           </table>
       <div class="auto-style8">
       <br />
       </div>
   </div>
        <div style="text-align:center">
            <div class="auto-style8">
            <asp:GridView DataKeyNames="Masp" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" CssClass="auto-style11" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkma" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Masp" HeaderText="Mã sản phẩm" ReadOnly="True" />
                    <asp:BoundField DataField="Tensp" HeaderText="Tên sản phẩm" />
                    <asp:BoundField DataField="Hangsx" HeaderText="Hãng sản xuất" />
                    <asp:BoundField DataField="Mota" HeaderText="Mô tả" />
                    <asp:TemplateField HeaderText="Ngày đăng">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Ngaydang") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="160px" Height="180px" ImageUrl='<%# "~/Images/"+Eval("Hinhanh") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" DeleteText="Xóa" EditText="Sửa" HeaderText="Thao tác" ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
