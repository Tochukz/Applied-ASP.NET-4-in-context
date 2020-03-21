<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingEntityDataSource.aspx.cs" Inherits="DataSourceApp.UsingEntityDataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource1" 
                              DataTextField="Name" DataValueField="Name"></asp:DropDownList>
        </div>
    </form>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" DefaultContainerName="TrainingDataEntities" EnableFlattening="False" EntitySetName="Athletes"></asp:EntityDataSource>
</body>
</html>
