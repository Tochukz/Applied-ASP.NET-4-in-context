<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="WorkingWithRoutes.Models.Customer1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-sm-6">
            <h3>Customer Details</h3>
            <table class="table table-bordered table-striped table-condensed">             
                <tr>
                    <td>
                        <strong>ID</strong>
                    </td>
                    <td><% if (Customer != null) Response.Write(Customer.Id); %></td>
                </tr>
                <tr>
                    <td>
                        <strong>First Name</strong>
                    </td>
                    <td><% if (Customer != null) Response.Write(Customer.Firstname); %></td>
                </tr>
                <tr>
                    <td>
                        <strong>Last Name</strong>
                    </td>
                    <td><% if (Customer != null) Response.Write(Customer.Lastname); %></td>
                </tr>
                <tr>
                    <td>
                        <strong>Email</strong>
                    </td>
                    <td><% if(Customer != null) Response.Write(Customer.Email); %></td>
                </tr>
                <tr>
                    <td>
                        <strong>Phone</strong>
                    </td>
                    <td><% if(Customer != null) Response.Write(Customer.Phone); %></td>
                </tr>
                <tr>
                    <td>
                        <strong>Address</strong>
                    </td>
                    <td><% if(Customer != null) Response.Write(Customer.Address); %></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
