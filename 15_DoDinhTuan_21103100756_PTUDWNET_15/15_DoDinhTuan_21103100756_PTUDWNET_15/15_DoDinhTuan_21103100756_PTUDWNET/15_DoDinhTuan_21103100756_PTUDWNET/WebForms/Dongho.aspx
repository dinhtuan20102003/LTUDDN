<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dongho.aspx.cs" Inherits="_15_DoDinhTuan_21103100756_PTUDWNET.WebForms.Dongho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            color: #0066FF;
        }
        .auto-style3 {
            width: 466px;
            font-size: large;
        }
        .auto-style4 {
            width: 247px;
            font-size: large;
        }
        .auto-style5 {
            width: 466px;
            height: 23px;
        }
        .auto-style6 {
            width: 247px;
            height: 23px;
            font-size: large;
        }
        .auto-style7 {
            height: 23px;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            color: #FF0000;
            font-size: x-large;
        }
        .auto-style10 {
            width: 466px;
            height: 26px;
        }
        .auto-style11 {
            width: 247px;
            height: 26px;
            font-size: large;
        }
        .auto-style12 {
            height: 26px;
        }
        .auto-style14 {
            font-size: large;
        }
        .auto-style15 {
            font-size: large;
            margin-left: 0px;
            background-color: #00CCFF;
        }
        .auto-style16 {
            font-size: large;
            background-color: #00CCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 class="auto-style2"><strong>QUẢN LÝ ĐỒNG HỒ</strong></h2>
        <table style="width:100%;">
            <tr>
                <td class="auto-style10"></td>
                <td class="auto-style11"><strong>Mã sản phẩm</strong></td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtmasp" runat="server" Width="428px" CssClass="auto-style14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6"><strong>Tên sản phẩm</strong></td>
                <td class="auto-style7">
                    <asp:TextBox ID="txttensp" runat="server" Width="428px" CssClass="auto-style14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><strong></strong></td>
                <td class="auto-style4"><strong>Phân loại</strong></td>
                <td>
                    <asp:DropDownList ID="drlphanloai" runat="server" Width="434px" CssClass="auto-style14">
                        <asp:ListItem>Đồng hồ nam</asp:ListItem>
                        <asp:ListItem>Đồng hồ nữ</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><strong></strong></td>
                <td class="auto-style4"><strong>Số lượng</strong></td>
                <td>
                    <asp:TextBox ID="txtsoluong" runat="server" Width="428px" CssClass="auto-style14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><strong></strong></td>
                <td class="auto-style4"><strong>Đơn giá</strong></td>
                <td>
                    <asp:TextBox ID="txtdongia" runat="server" Width="428px" CssClass="auto-style14"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><strong></strong></td>
                <td class="auto-style4"><strong>Hình ảnh</strong></td>
                <td>
                    <asp:FileUpload ID="filehinhanh" runat="server" Width="435px" CssClass="auto-style14" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="3">
                    <br />
                    <asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" CssClass="auto-style15" Height="30px" Width="82px" />
                    <span class="auto-style14">&nbsp;&nbsp;
                    </span>
                    <asp:Button ID="btnlammoi" runat="server" Text="Làm mới" OnClick="btnlammoi_Click" CssClass="auto-style16" Height="30px" />
                    <span class="auto-style14">&nbsp;&nbsp;
                    </span>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="3">
                    <br />
                    <span class="auto-style14"><strong>Nhập loại đồng hồ cần tìm</strong>&nbsp;&nbsp;&nbsp; </span>
                    <asp:TextBox ID="txttimkiem" runat="server" Width="316px" placeholder="Nhập phân loại đồng hồ cần tìm" CssClass="auto-style14"></asp:TextBox>
                   
                    <span class="auto-style14">&nbsp;&nbsp;
                    </span>
                    <asp:Button ID="btntimkiem" runat="server" Text="Tìm kiếm" OnClick="btntimkiem_Click" CssClass="auto-style16" Height="30px" />
                    <br class="auto-style14" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8" colspan="3">
                    <br />
                    <asp:Label ID="lbthongbao" runat="server" CssClass="auto-style9"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        <div>
        </div>
        <asp:GridView AllowPaging ="True" PageSize="5" DataKeyNames="Masp,Hinhanh" ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center" Width="1405px" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="auto-style14" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="Masp" HeaderText="Mã sản phẩm" ReadOnly="True" />
                <asp:TemplateField HeaderText="Tên sản phẩm">
                    <EditItemTemplate>
                        <asp:TextBox ID="txttensp" runat="server" Text='<%# Eval("Tensp") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tensp") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phân loại">
                    <EditItemTemplate>
                        <asp:DropDownList ID="drlphanloai" runat="server">
                            <asp:ListItem>Đồng hồ nam</asp:ListItem>
                            <asp:ListItem>Đồng hồ nữ</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Phanloai") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Số lượng">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtsoluong" runat="server" Text='<%# Eval("Soluong") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Soluong") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Đơn giá">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdongia" runat="server" Text='<%# Eval("Dongia") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Dongia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hình ảnh">
                    <EditItemTemplate>
                        <asp:FileUpload ID="filehinhanh" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image Width="150px" ID="Image1" runat="server" ImageUrl='<%# "~/Images/"+Eval("Hinhanh") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" DeleteText="Xoá" EditText="Sửa" HeaderText="Chức năng" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </form>
</body>
</html>
