<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timkiem.aspx.cs" Inherits="_27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms.Timkiem" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tìm kiếm thông tin xe máy</title>
    <style type="text/css">
        body {
            background-color: #f4f7f9;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
            padding: 20px;
        }

        .container {
            width: 100%;
            max-width: 1400px;
            padding: 40px;
            background-color: #ffffff;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            overflow: auto;
        }

        .center-text {
            text-align: center;
            margin-top: 20px;
        }

        .header-label {
            color: #0288D1;
            font-size: 26px;
            font-weight: bold;
            text-transform: uppercase;
        }

        .styled-button {
            background-color: #0288D1;
            color: white;
            border: none;
            padding: 8px 16px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s;
            margin-left: 10px;
        }

            .styled-button:hover {
                background-color: #0277BD;
            }

        .btn-back {
            background-color: #FF9800;
        }

            .btn-back:hover {
                background-color: #FB8C00;
            }

        .styled-textbox {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ced4da;
            border-radius: 4px;
            outline: none;
            width: 250px;
            transition: border-color 0.3s;
        }

            .styled-textbox:focus {
                border-color: #0288D1;
                box-shadow: 0 0 5px rgba(2, 136, 209, 0.3);
            }

        .grid-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
            gap: 20px;
            margin-top: 20px;
        }

        .card {
            width: 200px;
            padding: 15px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
            background-color: white;
            transition: transform 0.3s;
        }

            .card:hover {
                transform: translateY(-5px);
            }

            .card img {
                width: 100%;
                height: auto;
                border-radius: 8px;
                margin-bottom: 10px;
            }

        .card-title {
            font-weight: bold;
            color: #333;
            margin: 10px 0 5px;
        }

        .card-text {
            color: #555;
            font-size: 14px;
            margin-bottom: 10px;
        }

        .card-link {
            color: #0288D1;
            font-weight: bold;
            text-decoration: none;
            font-size: 14px;
        }

            .card-link:hover {
                text-decoration: underline;
            }

        .error-message {
            color: red;
            text-align: center;
            margin-top: 20px;
            font-size: 16pt;
            display: block;
        }

        .auto-style1 {
            font-size: 16pt;
        }

        .auto-style2 {
            color: #0066FF;
            font-size: 26px;
            font-weight: bold;
            text-transform: uppercase;
        }

        .auto-style3 {
            color: red;
            text-align: center;
            margin-top: 20px;
            font-size: 14pt;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="center-text">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style2" Text="TÌM KIẾM THÔNG TIN XE MÁY"></asp:Label>
            </div>

            <div class="center-text">
                <asp:Label ID="Label2" runat="server" Text="Nhập tên hãng sản xuất      " CssClass="auto-style1"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txttimkiem" runat="server" CssClass="styled-textbox" Placeholder="Nhập tên hãng sản xuất cần tìm"></asp:TextBox>
                <asp:Button ID="btntk" runat="server" CssClass="styled-button" Text="Tìm kiếm" OnClick="btntk_Click" />

            </div>

            <asp:Label ID="lbtb" runat="server" CssClass="auto-style3" Font-Size="16pt"></asp:Label>

            <div class="grid-container">
                <asp:Repeater ID="gvXemay" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <asp:Image ID="imgXe" runat="server" ImageUrl='<%# "~/Images/" + Eval("Hinhanh") %>' CssClass="grid-image" />
                            <div class="card-title">Tên xe máy: <%# Eval("Tenxe") %></div>
                            <div class="card-text">Hãng sản xuất: <%# Eval("HangSX") %></div>
                            <a href="#" class="card-link">Chi tiết sản phẩm</a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="center-text">
                <asp:Button ID="btnQuayLai" runat="server" CssClass="styled-button btn-back" Text="Quay lại" OnClick="btnQuayLai_Click" />
            </div>
        </div>
    </form>
</body>
</html>
