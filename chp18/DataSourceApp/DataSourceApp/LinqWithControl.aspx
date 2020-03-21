<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinqWithControl.aspx.cs" Inherits="DataSourceApp.LinqWithControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--
               Here we connect a DropDownList to a Listview so that changing the selected value of the drop down causes the ListView to change.
               This is done by using the value of the DropDown as a parameter in the "wehere clause"  of the data source of the ListView
            -->
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="Name" AutoPostBack="true"></asp:DropDownList>

            <asp:ListView ID="ListView1" runat="server" DataSourceID="LinqDataSource2">
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="TypeLabel" runat="server" Text='<%# Eval("Type") %>' />
                        </td>
                        <td>
                            <asp:Label ID="OverallTimeLabel" runat="server" Text='<%# Eval("OverallTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AthleteLabel" runat="server" Text='<%# Eval("Athlete") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="OverallTimeTextBox" runat="server" Text='<%# Bind("OverallTime") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AthleteTextBox" runat="server" Text='<%# Bind("Athlete") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="TypeTextBox" runat="server" Text='<%# Bind("Type") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="OverallTimeTextBox" runat="server" Text='<%# Bind("OverallTime") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DateTextBox" runat="server" Text='<%# Bind("Date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="AthleteTextBox" runat="server" Text='<%# Bind("Athlete") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="TypeLabel" runat="server" Text='<%# Eval("Type") %>' />
                        </td>
                        <td>
                            <asp:Label ID="OverallTimeLabel" runat="server" Text='<%# Eval("OverallTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AthleteLabel" runat="server" Text='<%# Eval("Athlete") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">Type</th>
                                        <th runat="server">OverallTime</th>
                                        <th runat="server">Date</th>
                                        <th runat="server">Athlete</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="TypeLabel" runat="server" Text='<%# Eval("Type") %>' />
                        </td>
                        <td>
                            <asp:Label ID="OverallTimeLabel" runat="server" Text='<%# Eval("OverallTime") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DateLabel" runat="server" Text='<%# Eval("Date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="AthleteLabel" runat="server" Text='<%# Eval("Athlete") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
        </div>
    </form>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataSourceApp.TrainingDataEntities" EntityTypeName="" Select="new (Name)" TableName="Athletes"></asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="DataSourceApp.TrainingDataEntities" EntityTypeName="" Select="new (Type, OverallTime, Date, Athlete)" TableName="Events" Where="Athlete == @Athlete">
        <WhereParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="Adam Freeman" Name="Athlete" PropertyName="SelectedValue" Type="String" />
        </WhereParameters>
    </asp:LinqDataSource>
</body>
</html>
