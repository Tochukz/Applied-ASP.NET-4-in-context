<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WashShopAdminApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Login</h3>
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="Username" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="UsernameValidator" ControlToValidate="Username" Display="Dynamic" ErrorMessage="Please enter your username" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="Password" TextMode="Password" runat="server" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="PasswordValidator" ControlToValidate="Password" Display="Dynamic" ErrorMessage="Please enter your password" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Remember Me</td>
                <td colspan="2">
                    <asp:CheckBox ID="RememberMe" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left">
                    <asp:Button ID="LoginBtn" OnClick="LoginClick" Text="Login" runat="server" />
                </td>
            </tr>
        </table>
        <p>
            <asp:Label ID="ErrorMsg" ForeColor="Red" runat="server" />
        </p>
    </form>
</body>
</html>
