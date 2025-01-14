<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="_27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms.ChiTiet" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi tiết sản phẩm</title>
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
            max-width: 800px; 
            padding: 40px; 
            background-color: #ffffff;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        .header-title {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            color: #0288D1;
            margin-bottom: 20px;
        }

        .product-image {
            width: 100%;
            border-radius: 10px;
            margin-bottom: 20px;
        }

        .product-details {
            font-size: 18px;
            color: #333;
            margin-bottom: 10px;
        }

        .back-button {
            background-color: #0288D1;
            color: white;
            border: none;
            padding: 10px 15px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s;
            display: block;
            margin: 20px auto 0;
            text-align: center;
        }

        .back-button:hover {
            background-color: #0277BD;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header-title">Chi tiết sản phẩm</div>
            <asp:Image ID="imgXe" runat="server" CssClass="product-image" />
            <div class="product-details">
                <strong>Tên xe máy:</strong> <asp:Label ID="lblTenXe" runat="server"></asp:Label>
            </div>
            <div class="product-details">
                <strong>Hãng sản xuất:</strong> <asp:Label ID="lblHangSX" runat="server"></asp:Label>
            </div>
            <div class="product-details">
                <strong>Mô tả:</strong> <asp:Label ID="lblMoTa" runat="server"></asp:Label>
            </div>
            <asp:Button ID="btnBack" runat="server" CssClass="back-button" Text="Quay lại" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
