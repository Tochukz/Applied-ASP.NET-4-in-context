<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebControlsApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>

        <div id="myDiv" runat="server"></div>
        <asp:Panel ID="myPanel" runat="server"></asp:Panel>
        <div id="results" runat="server"></div>

        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
