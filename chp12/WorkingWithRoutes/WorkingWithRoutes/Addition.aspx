<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Addition.aspx.cs" Inherits="WorkingWithRoutes.Addition" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <h3>Variable number of route variable segments</h3>
        <p>Append numbers to the end of the url to get their sum like this <em>http://localhost:58023/Add/5/10/5</em></p>
        <div class="col-sm-6">
            <p id="result" runat="server"></p>
        </div>
    </div>
</asp:Content>
