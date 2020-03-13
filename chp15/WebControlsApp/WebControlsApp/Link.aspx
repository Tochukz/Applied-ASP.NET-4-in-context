<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Link.aspx.cs" Inherits="WebControlsApp.Link" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server">Press Me!</asp:LinkButton>

            <!--The ontextchanged event will not be triggered until the form is submitted to the server and then it can be triggered if there was a change in the input text
                You can set the AutoPostBack property to true to have a post back when the event is triggered -->
            <asp:TextBox ID="TextBox1" ontextchanged="TextBox1Changed" runat="server" AutoPostBack="true">Test Box</asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Submit" />
            <div id="result" runat="server" />
        </div>
    </form>
</body>
</html>
