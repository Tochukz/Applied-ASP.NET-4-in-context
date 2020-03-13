<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bubble.aspx.cs" Inherits="WebControlsApp.Bubble" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button 1" CommandName="MyCommand" CommandArgument="MyCommandArg One" />
            <asp:Button ID="Button2" runat="server" Text="Button 2" CommandName="MyCommand Two" CommandArgument="MyCommandArg Two" />
            <asp:Button ID="Button3" runat="server" Text="Button 3" CommandName="MyCommand" CommandArgument="MyOtherCommandArg" />
        
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
