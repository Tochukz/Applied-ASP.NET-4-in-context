<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormAuthApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login</h2>
    <p>Please enter your username and password.</p>
    <table>
        <tr>
            <td>Username:</td>
            <td>
                <input type="text" id="username" runat="server" />

            </td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <input type="password" id="password" runat="server"  />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <input type="submit" value="Log In" />
            </td>
        </tr>
    </table>
</asp:Content>
