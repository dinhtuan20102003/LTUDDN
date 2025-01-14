<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sua.aspx.cs" Inherits="_27_Đỗ_Đình_Tuấn_DHTI15A1CL.WebForms.Sua" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản Lý Xe Máy - Cập Nhật Thông Tin</title>
    <style type="text/css">
      
        body {
            background-color: #f1f5f9;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

      
        .container {
            width: 700px; 
            padding: 30px 50px;
            background-color: #ffffff;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
            border-radius: 10px;
            box-sizing: border-box;
            margin-top: 10px;
            margin-bottom: 10px;

        }

       
        .header {
            text-align: center;
            color: #005f99;
            font-size: 24px;
            margin-bottom: 20px;
            font-weight: bold;
            text-transform: uppercase;
        }

      
        table {
            width: 100%;
            border-spacing: 0 15px;
        }

        th, td {
            padding: 10px;
            text-align: left;
            vertical-align: middle;
        }

        .label {
            color: #333;
            font-size: 16px;
            font-weight: 600;
        }

        input[type="text"], .asp-textbox, .asp-fileupload {
            width: 100%;
            padding: 12px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            box-sizing: border-box;
            font-size: 15px;
            color: #333;
            outline: none;
            transition: border-color 0.3s, box-shadow 0.3s;
           
        }

        input[type="text"]:focus, .asp-textbox:focus, .asp-fileupload:focus {
            border-color: #007acc;
            box-shadow: 0 0 5px rgba(0, 122, 204, 0.3);
        }

        .error {
            color: #d9534f;
            font-size: 13px;
        }

       
        .button-container {
            text-align: center;
            margin-top: 30px;
        }

        .button-primary {
            background-color: #007acc;
            color: white;
            border: none;
            padding: 12px 30px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin: 0 10px;
            transition: background-color 0.3s;
            font-weight: bold;
        }

        .button-primary:hover {
            background-color: #005f99;
        }

        .button-secondary {
            background-color: #d9534f;
            color: white;
            border: none;
            padding: 12px 30px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin: 0 10px;
            transition: background-color 0.3s;
            font-weight: bold;
        }

        .button-secondary:hover {
            background-color: #c9302c;
        }
        .auto-style2 {
            color: #FF3300;
            font-size: large;
        }
        .auto-style3 {
            color: #333;
            font-size: large;
            font-weight: 600;
            white-space: nowrap;
             margin-right: 35px;
        }
        .auto-style4 {
            color: #0066FF;
        }
        .auto-style5 {
            height: 65px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
        <div class="container">
            <div class="header">
                <asp:Label ID="Label1" runat="server" Text="QUẢN LÝ XE MÁY - CẬP NHẬT THÔNG TIN" CssClass="auto-style4"></asp:Label>
            </div>
            <div>
                <table>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="Label7" runat="server" CssClass="auto-style3" Text="Biển Số"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtbienso" runat="server" CssClass="asp-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="auto-style3" Text="Tên Xe Máy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txttenxe" runat="server" CssClass="asp-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Màu"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtmau" runat="server" CssClass="asp-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="auto-style3" Text="Hãng Sản Xuất"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txthangsx" runat="server" CssClass="asp-textbox"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="auto-style3" Text="Năm Sản Xuất"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnsx" runat="server" CssClass="asp-textbox"></asp:TextBox>
                            <asp:Label ID="lbnsx" runat="server" CssClass="auto-style2"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="auto-style3" Text="Hình Ảnh"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="asp-fileupload" />
                            <asp:Label ID="lbha" runat="server" CssClass="auto-style2"></asp:Label>
                         <%--   <asp:Image ID="imgHinhAnh" runat="server" Width="200px" Height="150px" />--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="button-container">
                <asp:Button ID="btnsua" runat="server" OnClick="btnsua_Click" Text="Sửa" CssClass="button-primary" />
                <asp:Button ID="btnql" runat="server" OnClick="btnql_Click" Text="Quay lại" CssClass="button-secondary" />
            </div>
        </div>
    </form>
</body>
</html>
