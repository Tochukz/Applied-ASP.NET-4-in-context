<%@ Page Title="Triathlon Events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventList.aspx.cs" Inherits="StylingContent.EventList" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Styles/Page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('td a').addClass('tableLink').css('text-decoration', 'none');

            $('td').filter(function () {
                return $(this).text() == 1;
            }).css({ 'color': 'green', 'font-weight': 'bold' });

            /* Style the first row*/
            //$('tr:has(th)').css({ 'background-color': '#007F7F', 'color': '#ffffff' });
            $('tr').first().css({ 'background-color': '#007F7F', 'color': '#ffffff' });

            /* Style every other row that is even*/
            //$('tr:has(td):even').css('background-color', '#11B1B1');
            $('tr:odd').css('background-color', '#11B1B1');
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table id="resultsTable" runat="server" rules="cols">
        <tr>
            <th>Date</th>
            <th>Athlete</th>
            <th>Event Type</th>
            <th>Swim</th>            
            <th>Cycle</th>
            <th>Run</th>
            <th>Overall</th>
            <th>Rank</th>
            <th>Ref Rank</th>
            <th>Edit</th>
            <th>Delete</th>
        </tr>
    </table>
    <div class="standardDiv">
        <label>Event Type:</label>
        <select id="eventSelector" runat="server">
            <option>All</option>
        </select>
    </div>

    <div class="standardDiv">
        <input type="submit" value="Submit" />
    </div>
    <div class="standardDiv">
        <a href="AddEvent.aspx">Add New Event</a>
    </div>
</asp:Content>
