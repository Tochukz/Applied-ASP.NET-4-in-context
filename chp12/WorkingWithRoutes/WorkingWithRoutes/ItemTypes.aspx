<%@ Page Title="Item Types" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ItemTypes.aspx.cs" Inherits="WorkingWithRoutes.ItemTypes" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-6">
            <h3>Item Types</h3>
            <table class="table table-bordered table-striped table-condensed table-hover">
                <tr>
                    <th>ID</th>
                    <th>Item Type</th>
                    <th>Price</th>
                </tr>                
                <%
                    foreach(var item in ItemList)
                    {
                        Response.Write(string.Format("<tr><td>{0}</td><td>{1}</td><td>R{2}</td></tr>", item.Id, item.Type, item.Price));                        
                    }
                %>                
            </table>
        </div>
    </div>
</asp:Content>
