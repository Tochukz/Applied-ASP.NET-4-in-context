<%@ Page Title="Customer List" Language="C#" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="WorkingWithRoutes.CustomerList" MasterPageFile="~/Site.Master" %>


<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="main" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-8">
            <h3>Customer List</h3>
            <table class="table table-striped table-bordered table-condensed table-hover table-responsive">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Address</th>
                    </tr>
                </thead>
                <tbody>
                    <%                
                        foreach(dynamic customer in Customers) 
                        {
                            Response.Write(string.Format("<tr onclick='location.href=\"/Customers/{0}\"'><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", customer.Id, customer.Firstname, customer.Lastname, customer.Email, customer.Phone, customer.Address));
                        }
                    %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
