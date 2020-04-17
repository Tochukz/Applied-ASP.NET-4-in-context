<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListViewStructure.aspx.cs" Inherits="RichDataControls.ListViewStructure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ListView</title>
    <style type="text/css">
        .group {
            border: thin solid black;
            background-color: Gray;
            color: white;
            padding: 2px; 
            text-align: center;
        }
        .item {
            background-color: aqua;
        }
        .emptyitem { background-color: fuchsia;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource1" GroupItemCount="3">
                <LayoutTemplate>
                    <table border="1">
                        <tr>
                            <th colspan="3">LayoutTemplate</th>
                        </tr>
                        <tr ID="groupPlaceholder" runat="server" />
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="Button1" runat="server" Text="Sort Asc" CommandName="Sort" CommandArgument="Name" />
                                <asp:Button ID="Button2" runat="server" Text="Sort Desc" CommandName="Sort" CommandArgument="Name DESC" />
                                <%-- 
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="3">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowLastPageButton="true" />
                                    </Fields>
                                </asp:DataPager>
                                --%>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <th colspan="3" class="group">GroupTemplate</th>
                    </tr>
                    <tr>
                        <td ID="itemPlaceHolder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td class="item"><%# Eval("Name") %></td>
                </ItemTemplate>
                <EmptyItemTemplate>
                    <td class="emptyitem">Empty</td>
                </EmptyItemTemplate>
            </asp:ListView>
        </div>
    </form>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="RichDataControls.ListViewStructure"
         EntityTypeName="" OrderBy="Name" Select="new (Name)" TableName="DataItems"></asp:LinqDataSource>
</body>
</html>
