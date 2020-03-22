<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataBoundControls.aspx.cs" Inherits="DataBindingApp.DataBoundControls" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Bound Controls</title>
    <style type="text/css">
        .dataitem {
            margin: 10px;
            width: 140px;
            float: left;
        }
        code {
            vertical-align: top;
            margin-bottom: 5px;
            clear: both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="dataitem">
                <code>BulletedList</code>
                <asp:BulletedList ID="BulletedList1" runat="server" DataSourceId="LinqDataSource1" DataTextField="Name" DataValueField="Name"></asp:BulletedList>
            </div>
            <div class="dataitem">
                <code>CheckBoxList</code>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="Name"></asp:CheckBoxList>
            </div>
            <div class="dataitem">
                <code>DropDownList</code>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="Name"></asp:DropDownList>
            </div>
            <div class="dataitem">
                <code>ListBox</code>
                <asp:ListBox ID="ListBox1" runat="server" DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="Name"></asp:ListBox>
            </div>
            <div class="dataitem">
                <code>RadioButtonList</code>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="LinqDataSource1" DataTextField="Name" DataValueField="Name"></asp:RadioButtonList>
            </div>
        </div>
    </form>
    
<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataBindingApp.TrainingDataEntities" EntityTypeName="" Select="new (Name)" TableName="EventTypes"></asp:LinqDataSource>
</body>
</html>
