<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingXMLDataSource.aspx.cs" Inherits="DataBindingApp.UsingXMLDataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML Data</title>
    <style type="text/css">
         .dataitem {
            margin: 10px;
            width: 140px;
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="dataitem">
                <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1">
                    <DataBindings>
                        <asp:TreeNodeBinding DataMember="Athlete" TextField="Rank" />
                        <asp:TreeNodeBinding DataMember="name" TextField="#InnerText" />
                        <asp:TreeNodeBinding DataMember="city" TextField="#InnerText" />
                    </DataBindings>
                </asp:TreeView>
            </div>
            <div class="dataitem">
                <asp:Menu ID="Menu1" runat="server" DataSourceID="XmlDataSource1">
                    <DataBindings>
                        <asp:MenuItemBinding DataMember="Athlete" TextField="Rank" />
                        <asp:MenuItemBinding DataMember="name" TextField="#InnerText" />
                        <asp:MenuItemBinding DataMember="city" TextField="#InnerText" />
                    </DataBindings>
                </asp:Menu>
            </div>
        </div>
    </form>
<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Data.xml" XPath="/Athletes/Athlete"></asp:XmlDataSource>
</body>
</html>
