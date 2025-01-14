<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xemay.aspx.cs" Inherits="_27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms.Xemay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Danh sách thông tin xe máy</title>
    <style>
        body {
            background-color: #E1F5FE;
            color: #333;
            margin: 0;
            padding: 0;
            margin-bottom: 25px;
        }

        .container {
            width: 80%;
            margin: auto;
            padding-bottom: 40px;
            padding-top: 10px;
            padding-right: 70px;
            padding-left: 70px;
            background-color: #FFFFFF;
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            margin-top: 20px;
        }

        .header {
            text-align: center;
            color: #1E90FF;
            font-size: 24px;
            margin-bottom: 20px;
        }

        .button-container {
            text-align: center;
            margin-bottom: 15px;
        }

        .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            color: #FFF;
            font-size: 16px;
            margin: 0 5px;
        }

        .btn-add {
            background-color: #4CAF50;
        }

        .btn-search {
            background-color: #1E90FF;
        }


        .custom-grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.15);
            border-radius: 5px;
            overflow: hidden;
        }

            .custom-grid th,
            .custom-grid td {
                padding: 16px;
                border-bottom: 1px solid #ddd;
                text-align: center;
            }

            .custom-grid th {
                background-color: #1E90FF;
                color: #FFF;
                font-weight: bold;
                font-size: 18px;
            }


        .grid-view-row {
            background-color: #FFFFFF;
            font-size: 18px;
            color: #333;
        }


        .grid-view-row-alternating {
            background-color: #E3F2FD;
            font-size: 18px;
        }


            .grid-view-row:hover,
            .grid-view-row-alternating:hover {
                background-color: #B2EBF2;
                cursor: pointer;
                transition: background-color 0.3s ease;
            }

        .btn-action {
            padding: 6px 12px;
            font-size: 14px;
            border-radius: 4px;
            color: #FFF;
            cursor: pointer;
            border: none;
            transition: background-color 0.3s;
        }

        .btn-edit {
            background-color: #FF9800;
        }

        .btn-delete {
            background-color: #F44336;
        }

        .btn-edit:hover {
            background-color: #FB8C00;
        }

        .btn-delete:hover {
            background-color: #E53935;
        }

        .grid-image {
            width: 180px;
            height: 120px;
            border-radius: 8px; 
            border: 2px solid #87CEFA; 
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2); 
            transition: transform 0.3s ease, box-shadow 0.3s ease; 
        }


            .grid-image:hover {
                transform: scale(1.1);
            }

        .auto-style1 {
            text-align: center;
            color: #1E90FF;
            font-size: xx-large;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="auto-style1">DANH SÁCH THÔNG TIN XE MÁY</h2>

            <div class="button-container">
                <asp:Button ID="btnthem" runat="server" CssClass="btn btn-add" Text="Thêm xe máy" OnClick="btnthem_Click" />
                <asp:Button ID="btntk" runat="server" CssClass="btn btn-search" Text="Tìm kiếm" OnClick="btntk_Click" />
            </div>

            <div class="grid-view-container">
                <asp:GridView ID="gvXemay" DataKeyNames="Bienso" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="custom-grid" GridLines="None" OnPageIndexChanging="gvXemay_PageIndexChanging " AllowPaging="true" PageSize="5">
                    <AlternatingRowStyle CssClass="grid-view-row-alternating" />
                    <Columns>
                        <asp:BoundField DataField="Bienso" HeaderText="Biển số" DataFormatString="<span style='color: red;'><b>{0}</b></span>" HtmlEncode="false" />

                        <asp:BoundField DataField="Tenxe" HeaderText="Tên xe" />
                        <asp:BoundField DataField="Mau" HeaderText="Màu" />
                        <asp:BoundField DataField="HangSX" HeaderText="Hãng sản xuất" />
                        <asp:BoundField DataField="NamSX" HeaderText="Năm sản xuất" />
                        <asp:TemplateField HeaderText="Hình ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" CssClass="grid-image" ImageUrl='<%# "~/Images/" + Eval("Hinhanh") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác">
                            <ItemTemplate>
                                <asp:Button ID="btnsua" runat="server" CssClass="btn-action btn-edit" Text="Sửa" CommandArgument='<%# Eval("Bienso") %>' OnClick="btnsua_Click" />
                                <asp:Button ID="btnxoa" runat="server" CssClass="btn-action btn-delete" Text="Xóa" CommandArgument='<%# Eval("Bienso") %>' OnClick="btnxoa_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="grid-view-footer" />
                    <HeaderStyle CssClass="grid-view-header" />
                    <PagerStyle CssClass="grid-view-pager" />
                    <RowStyle CssClass="grid-view-row" />
                    <SelectedRowStyle CssClass="grid-view-row-selected" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
