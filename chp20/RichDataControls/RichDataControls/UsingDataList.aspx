<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingDataList.aspx.cs" Inherits="RichDataControls.UsingDataList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="ID" DataSourceID="EntityDataSource1" RepeatColumns="3"
                RepeatDirection="Vertical" RepeatLayout="Table" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                <ItemTemplate>
                    <table style="border: thin solid black">
                        <tr>
                            <td>Index:</td>
                            <td><%# Container.ItemIndex %></td>
                        </tr>
                        <tr>
                            <td>Date:</td>
                            <td><%# Eval("Date", "{0:d}") %></td>
                        </tr>
                        <tr>
                            <td>Time:</td>
                            <td><%# Eval("OverallTime") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <table style="border:thin solid black; background-color: Grey; color: White">                  
                        <tr>
                            <td>Index:</td>
                            <td><%# Container.ItemIndex %></td>
                        </tr>
                        <tr>
                            <td>Date:</td>
                            <td><%# Eval("Date", "{0:d}") %></td>
                        </tr>
                        <tr>
                            <td>Time:</td>
                            <td><%# Eval("OverallTime") %></td>
                        </tr>
                    </table>
                </AlternatingItemTemplate>
                <SelectedItemTemplate>
                    <table style="border: thin solid black; background-color: Red; color: White">
                         <tr>
                            <td>Index:</td>
                            <td><%# Container.ItemIndex %></td>
                        </tr>
                        <tr>
                            <td>Date:</td>
                            <td><%# Eval("Date", "{0:d}") %></td>
                        </tr>
                        <tr>
                            <td>Time:</td>
                            <td><%# Eval("OverallTime") %></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Text="Select" />
                            </td>
                        </tr>
                    </table>
                </SelectedItemTemplate>
            </asp:DataList>
        </div>
    </form>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities"  
    DefaultContainerName="TrainingDataEntities" EnableDElete="true" EnableFlattening="false" 
    EnableInsert="true" EnableUpdate="true" EntitySetName="Events" AutoGenerateWhereClause="true"></asp:EntityDataSource>
</body>
</html>
