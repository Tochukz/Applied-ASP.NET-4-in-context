<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingGridView.aspx.cs" Inherits="RichDataControls.UsingGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                 AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="EntityDataSource1" PageSize="5">
                  <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" ButtonType="Button"/>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" Visible="false"/>
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" DataFormatString="{0:d}"/>
                    <asp:BoundField DataField="Athlete" HeaderText="Name" SortExpression="Athlete" />
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                    <asp:BoundField DataField="SwimTime" HeaderText="Swim" SortExpression="SwimTime" />
                    <asp:BoundField  DataField="CycleTime" HeaderText="Ride" SortExpression="CycleTime" />
                    <asp:BoundField DataField="RunTime" HeaderText="Run" SortExpression="RunTime" />
                    <asp:BoundField DataField="OverallTime" HeaderText="Total" SortExpression="OverallTime" />
                  </Columns>
            </asp:GridView>
        </div>
    </form>
<asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=TrainingDataEntities" 
        DefaultContainerName="TrainingDataEntities" EnableDelete="True" EnableFlattening="False" 
        EnableInsert="True" EnableUpdate="True"  EntitySetName="Events">
    </asp:EntityDataSource>
</body>
</html>
