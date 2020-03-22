<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBoundTemplates.aspx.cs" Inherits="DataBindingApp.DataBoundTemplates" %>
<%@ Import Namespace="DataBindingApp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Bound Template</title>
    <style type="text/css">
        span {
            width: 100px;
            float: left;
            margin: 5px;
        }
        div.data {
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server" DataSourceID="EntityDataSource1">
                <ItemTemplate>
                    <div class="data">                                
                        <asp:Label id="Lable1a" runat="server" Text='<%# Container.ItemIndex + 1 %>' />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />      
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Type") %>' />  
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("OverallTime") %>' />
                    </div>
                </ItemTemplate>
                <HeaderTemplate>
                    <div class="data">
                        <asp:Label ID="Label4a" runat="server" Text="#" />
                        <asp:Label ID="Label4" runat="server" Text="Date" />
                        <asp:Label ID="Label5" runat="server" Text="Type" />
                        <asp:Label ID="Label6" runat="server" Text="Time" />
                    </div>
                </HeaderTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Repeater ID="Repeater2" runat="server" DataSourceID="EntityDataSource1">
                <ItemTemplate>
                    <div class="data">
                        <asp:Label ID="Label7" runat="server" Text='<%# ((IDataItemContainer)Container).DataItemIndex + 1 %>' />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />
                        <asp:Label ID="Label9" runat="server" Text='<%# ((Event)Container.DataItem).Type %>' />
                        <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OverallTime") %>' />
                    </div>
                </ItemTemplate>
                <HeaderTemplate>
                    <div class="data">
                        <asp:Label ID="Label11" runat="server" Text="#" />
                        <asp:Label ID="Label12" runat="server" Text="Date" />
                        <asp:Label ID="Label13" runat="server" Text="Type" />
                        <asp:Label ID="Label14" runat="server" Text="Time" />
                    </div>
                </HeaderTemplate>
            </asp:Repeater>
        </div>
    </form>

<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" 
                      DefaultContainerName="TrainingDataEntities" EnableFlattening="False" EntitySetName="Events"></asp:EntityDataSource>
</body>
</html>
