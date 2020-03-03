<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Laps"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Pool Length"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Minutes"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Calories/Hour"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" />
        </div>
        <div>
            <asp:TextBox ID="TextBox5" runat="server" BorderStyle="None" ReadOnly="True" Rows="5" TextMode="MultiLine" CssClass="result" ></asp:TextBox>
        </div>
    </form>
</body>
</html>
