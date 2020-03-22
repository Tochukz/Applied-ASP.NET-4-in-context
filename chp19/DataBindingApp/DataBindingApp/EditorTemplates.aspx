<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditorTemplates.aspx.cs" Inherits="DataBindingApp.EditorTemplates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editor Templates</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="FormView1" runat="server" DataSourceID="EntityDataSource1" DataKeyNames="ID" RenderOuterTable="true" AllowPaging="true">
                <%-- <PagerSettings Mode="Numeric" /> --%>
                <PagerTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Frist" CommandName="Page" CommandArgument="First" />
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="Prev" CommandName="Page" CommandArgument="Prev" />
                            </td>
                            <td>
                                <%# Container.PageIndex + 1 %> of <%# Container.PageCount %>
                            </td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="Next" CommandName="Page" CommandArgument="Next" />
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="Last" CommandName="Page" CommandArgument="Last" />
                            </td>
                        </tr>
                    </table>
                </PagerTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Date:" />
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Date", "{0:d}") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Types:" />
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Type") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("OverallTime") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" Text="Edit Record" CommandName="Edit" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="Label16" runat="server" Text="Date:" />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date", "{0:d}") %>' />
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" Text="Type:" />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Type") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label18" runat="server" Text="Time:" />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OverallTime") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="button">
                            <asp:Button ID="Button2" runat="server" Text="Save Changes" CommandName="Update" />
                        </td>                        
                        <td class="button">
                            <asp:Button ID="Button3" runat="server" Text="Cancel" CommandName="Cancel" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:FormView>
        </div>
    </form>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" 
                      DefaultContainerName="TrainingDataEntities" EnableDelete="True" EnableFlattening="False" 
                      EnableInsert="True" EnableUpdate="True" EntitySetName="Events"></asp:EntityDataSource>
</body>
</html>
