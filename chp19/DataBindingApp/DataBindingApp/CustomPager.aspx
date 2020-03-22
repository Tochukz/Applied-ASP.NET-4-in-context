<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomPager.aspx.cs" Inherits="DataBindingApp.CustomPager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Pagination</title>
    <style type="text/css">
        span {
            width: 100px;
            float: left;
            margin: 5px;
        }
        div.data {
            clear: both;
        }
        td.button {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="data">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Type") %>' />
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("OverallTime") %>' />
                    </div>
                </ItemTemplate>
                <HeaderTemplate>
                    <div class="data">
                        <asp:Label ID="Label4" runat="server" Text="Date" />
                        <asp:Label ID="Label5" runat="server" Text="Type" />
                        <asp:Label ID="Label6" runat="server" Text="Time" />
                    </div>
                </HeaderTemplate>
            </asp:Repeater>
            <div style="clear: both">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Prev" CommandName="Prev" />
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="PagerLabel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" Text="Next" CommandName="Next" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
