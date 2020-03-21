<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingSqlDataSource.aspx.cs" Inherits="DataSourceApp.UsingSqlDataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" 
                              DataTextField="Name" DataValueField="Name" AutoPostBack="true"></asp:DropDownList>
        </div>
    </form>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:triathlonConnectionString %>" 
                   DeleteCommand="DELETE FROM [Athletes] WHERE [Name] = @Name" 
                   InsertCommand="INSERT INTO [Athletes] ([Name]) VALUES (@Name)" 
                   SelectCommand="SELECT * FROM [Athletes] ORDER BY [Name]">
    <DeleteParameters>
        <asp:Parameter Name="Name" Type="String" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="Name" Type="String" />
    </InsertParameters>
</asp:SqlDataSource>
</body>
</html>
