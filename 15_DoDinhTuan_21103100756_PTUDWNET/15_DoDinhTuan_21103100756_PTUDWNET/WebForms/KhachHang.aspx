<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KhachHang.aspx.cs" Inherits="_15_DoDinhTuan_21103100756_PTUDWNET.WebForms.KhachHang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            color: #3366FF;
        }
        .auto-style5 {
            text-align: center;
            height: 82px;
        }
        .auto-style6 {
            text-align: center;
            height: 56px;
        }
        .auto-style7 {
            width: 203px;
        }
        .auto-style8 {
            width: 438px;
        }
        .auto-style9 {
            color: #FF6666;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3 class="auto-style2"><strong>QUẢN LÝ KHÁCH HÀNG</strong></h3>
        <div>
            <div>
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Mã khách hàng</td>
                        <td>
                            <asp:TextBox ID="txtmakh" runat="server" Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Tên khách hàng</td>
                        <td>
                            <asp:TextBox ID="txttenkh" runat="server" Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Email</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Giới tính </td>
                        <td>
                            <asp:DropDownList ID="txtgioitinh" runat="server" Width="341px">
                                <asp:ListItem>Nam</asp:ListItem>
                                <asp:ListItem>Nữ</asp:ListItem>
                                <asp:ListItem>Khác</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Số tài khoản</td>
                        <td>
                            <asp:TextBox ID="txtstk" runat="server" Width="335px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">Hình ảnh</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" Width="340px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6" colspan="3">
                            <asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" />
&nbsp;&nbsp;
                            <asp:Button ID="btnlammoi" runat="server" Text="Làm mới" OnClick="btnlammoi_Click" />
&nbsp;&nbsp;
                            <asp:Button ID="btnxoa" runat="server" Text="Xóa" Width="56px" OnClick="btnxoa_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" colspan="3">
                            <br />
                            Nhập thông tin tìm kiếm&nbsp;&nbsp;
                            <asp:TextBox ID="txttimkiem" runat="server" Width="268px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btntimkiem" runat="server" Text="Tìm kiếm" Width="84px" OnClick="btntimkiem_Click" />
                            <br />
                            <br />
                            <asp:Label ID="lbthongbao" runat="server" CssClass="auto-style9"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <asp:GridView AllowPaging="true" PageSize="3" ID="GridView1" DataKeyNames="MaKH,HinhAnh" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="GridView1_RowDeleting" Width="1025px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkheader" runat="server" OnCheckedChanged="chkheader_CheckedChanged"  AutoPostBack="true"/>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox  ID="chk" runat="server" OnCheckedChanged="chk_CheckedChanged " />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MaKH" HeaderText="Mã khách hàng" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Tên khách hàng">
                            <EditItemTemplate>
                                <asp:TextBox ID="txttenkh" runat="server" Text='<%# Eval("TenKH") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenKH") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtemail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Giới tính">
                            <EditItemTemplate>
                                <asp:DropDownList ID="txtgioitinh" runat="server">
                                    <asp:ListItem>Nam</asp:ListItem>
                                    <asp:ListItem>Nữ</asp:ListItem>
                                    <asp:ListItem>Khác</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("GioiTinh") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Số tài khoản">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtstk" runat="server" Text='<%# Eval("SoTK") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("SoTK") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <EditItemTemplate>
                                <asp:FileUpload ID="txtfile" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Width="150px" ImageUrl='<%# "~/Images/" +Eval("HinhAnh") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField DeleteText="Xóa" EditText="Sửa" HeaderText="Thao tác" ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
