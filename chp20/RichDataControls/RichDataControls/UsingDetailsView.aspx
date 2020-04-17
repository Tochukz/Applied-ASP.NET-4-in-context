<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingDetailsView.aspx.cs" Inherits="RichDataControls.UsingDetailsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using DetailsView Data Control</title>
    <style type="text/css">
        .hf {
            text-align: center;
            color: white;
            background-color: gray;
        }
        td {
            padding: 3px;
        }
        .command {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="true" AutoGenerateRows="false" DataKeyNames="ID" DataSourceID="EntityDataSource1">
                <HeaderTemplate>
                    <tr>
                        <td colspan="2" class="hf">Header</td>
                    </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    <tr>
                        <td colspan="2" class="hf">Footer</td>
                    </tr>
                </FooterTemplate>
                <PagerTemplate>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="Button1" runat="server" Text="Prev" CommandName="Page" CommandArgument="Prev" />
                            <%# Container.PageIndex + 1 %> of <%# Container.PageCount %>
                            <asp:Button ID="Button2" runat="server" Text="Next" CommandName="Page" CommandArgument="Next" />
                        </td>
                    </tr>
                </PagerTemplate>
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" SortExpression="ID" Visible="false" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="Athlete" SortExpression="Athlete">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource1" SelectedValue='<%# Bind("Athlete") %>' DataTextField="Name" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:DropDownList ID="DropDownList" runat="server" DataSourceID="LinqDataSource1" SelectedValue='<%# Bind("Athlete") %>' DataTextField="Name" />
                        </InsertItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lable1" runat="server" Text='<%# Eval("Athlete") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" InsertVisible="False" />
                    <asp:BoundField DataField="SwimTime" HeaderText="SwimTime" SortExpression="SwimTime" />
                    <asp:BoundField DataField="CycleTime" HeaderText="CycleTime" SortExpression="CycleTime" />
                    <asp:BoundField DataField="RunTime" HeaderText="RunTime" SortExpression="RunTime" />
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" ShowInsertButton="true" ButtonType="Button">
                        <ItemStyle CssClass="command" />
                    </asp:CommandField>
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" DefaultContainerName="TrainingDataEntities" 
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True" EntitySetName="Events" AutoGenerateOrderByClause="True">
    </asp:EntityDataSource>
    
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="RichDataControls.TrainingDataEntities" 
        EntityTypeName="" Select="new (Name)" TableName="Athletes">
    </asp:LinqDataSource>
</body>
</html>
