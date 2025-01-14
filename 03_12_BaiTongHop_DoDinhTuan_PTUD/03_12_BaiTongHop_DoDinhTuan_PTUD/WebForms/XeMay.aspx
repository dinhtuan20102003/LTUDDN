<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XeMay.aspx.cs" Inherits="_03_12_BaiTongHop_DoDinhTuan_PTUD.WebForms.XeMay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 349px;
        }
        .auto-style3 {
            width: 100%;
            height: 319px;
            font-size: 16pt;
        }
        .auto-style4 {
            width: 349px;
            height: 35px;
        }
        .auto-style5 {
            height: 35px;
        }
        .auto-style6 {
            width: 215px;
            height: 35px;
            font-size: medium;
        }
        .auto-style7 {
            width: 215px;
        }
        .auto-style8 {
            font-size: medium;
        }
        .auto-style9 {
            width: 349px;
            height: 31px;
        }
        .auto-style10 {
            width: 215px;
            height: 31px;
        }
        .auto-style11 {
            height: 31px;
        }
        .auto-style14 {
            height: 30px;
            text-align: center;
        }
        .auto-style16 {
            width: 215px;
            height: 39px;
        }
        .auto-style17 {
            width: 349px;
            height: 39px;
        }
        .auto-style18 {
            height: 39px;
        }
        .auto-style19 {
            text-align: center;
            height: 45px;
        }
        .auto-style20 {
            height: 34px;
            text-align: center;
        }
        .auto-style21 {
            color: #FF3300;
        }
        .auto-style22 {
            font-size: 14pt;
        }
        .auto-style23 {
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="auto-style1">
                <h2 class="auto-style23"><strong>QUẢN LÝ XE MÁY</strong></h2>
            </div>
        </div>
        <div>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style6">Biển số</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtbienso" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Tên xe</td>
                    <td>
                        <asp:TextBox ID="txttenxe" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style9"></td>
                    <td class="auto-style10">Màu</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txtmau" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Hãng sản xuất</td>
                    <td>
                        <asp:DropDownList ID="drlhangsx" runat="server" Width="305px">
                            <asp:ListItem>Yamaha</asp:ListItem>
                            <asp:ListItem>Honda</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Ngày sản xuất</td>
                    <td>
                        <asp:TextBox ID="txtngaysx" TextMode="Date" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style7">Năm sản xuất</td>
                    <td>
                        <asp:TextBox ID="txtnamsx" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style17"></td>
                    <td class="auto-style16">Hình ảnh</td>
                    <td class="auto-style18">
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="307px" />
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style14" colspan="3">
                        <br />
                        <asp:Button ID="btnthem" runat="server" Text="Thêm" OnClick="btnthem_Click" />
&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
                    &nbsp;
                        <asp:Button ID="btnxoa" runat="server" OnClick="btnxoa_Click" Text="Xóa" />
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style19" colspan="3">Tìm kiếm&nbsp;
                        <asp:TextBox ID="txttimkiem" runat="server" Width="395px"></asp:TextBox>
&nbsp;<asp:Button ID="btntimkiem" runat="server" Text="Tìm kiếm" OnClick="btntimkiem_Click" />
                    </td>
                </tr>
                <tr class="auto-style8">
                    <td class="auto-style20" colspan="3">
                        <asp:Label ID="lbThongbao" runat="server" CssClass="auto-style21"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView AllowPaging="true" PageSize="2" DataKeyNames="Bienso,Hinhanh"  ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style22" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Chọn">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Bienso" HeaderText="Biển số" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Tên xe">
                        <EditItemTemplate>
                            <asp:TextBox ID="txttenxe" runat="server" Text='<%# Eval("TenXe") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("TenXe") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Màu">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtmau" runat="server" Text='<%# Eval("Mau") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Mau") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hãng sản xuất">
                        <EditItemTemplate>
                            <asp:DropDownList ID="drlhangsx" runat="server" SelectedValue='<%# Eval("HangSX") %>'>
                                <asp:ListItem>Honda</asp:ListItem>
                                <asp:ListItem>Yamaha</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("HangSX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ngày sản xuất">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtngaysx" TextMode="Date" runat="server" Text='<%# Eval("NgaySX", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("NgaySX","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Năm sản xuất">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtnamsx" runat="server" Text='<%# Eval("NamSX") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("NamSX") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload2" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" ImageUrl='<%# "~/Images/"+Eval("Hinhanh") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" DeleteText="Xóa" EditText="Sửa" HeaderText="Chức năng" ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
