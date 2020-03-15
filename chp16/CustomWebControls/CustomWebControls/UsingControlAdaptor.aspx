<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingControlAdaptor.aspx.cs" Inherits="CustomWebControls.UsingControlAdaptor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>First Item</asp:ListItem>
                <asp:ListItem>Second Item</asp:ListItem>
                <asp:ListItem>Third Item</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </form>
</body>
</html>
